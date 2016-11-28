using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OMCS.Passive;
using System.Configuration;
using ESPlus.Rapid;
using ESPlus.Application.Basic;
using ESPlus.Application.CustomizeInfo.Passive;
using ESBasic.Security;
using System.Security.Cryptography;
using ESPlus.Application.CustomizeInfo;
using OMCS.Tools;

using System.Diagnostics;
using ESFramework.Boost.DynamicGroup.Passive;
using ESFramework.Boost.NetworkDisk.Passive;
using System.Threading;

namespace OVCS
{
    public partial class LoginForm : Form
    {
        #region RapidPassiveEngine
        private IRapidPassiveEngine rapidPassiveEngine = RapidEngineFactory.CreatePassiveEngine();

        public IRapidPassiveEngine RapidPassiveEngine
        {
            get { return rapidPassiveEngine; }
        } 
        #endregion

        private string roomID;
        public string RoomID
        {
            get { return roomID; }
        }

        #region UserID
        private string userID;
        public string UserID
        {
            get { return userID; }
        }
        #endregion

        #region MultimediaManager
        private IMultimediaManager multimediaManager = MultimediaManagerFactory.GetSingleton();
        public IMultimediaManager MultimediaManager
        {
            get { return multimediaManager; }
        } 
        #endregion     

        #region GroupOutter
        private DynamicGroupOutter groupOutter = new DynamicGroupOutter();
        public DynamicGroupOutter GroupOutter
        {
            get { return groupOutter; }
        }
        #endregion

        #region IsVisitor
        private bool isVisitor = true;
        public bool IsVisitor
        {
            get { return isVisitor; }
        } 
        #endregion
        
        private CustomizeHandler customizeHandler;       
        private string password = "";
        public LoginForm(CustomizeHandler _customizeHandler)
        {
            InitializeComponent();
            //this.button2.Enabled = !Program.IsReleaseVersion;

            this.customizeHandler = _customizeHandler;          

        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.isVisitor = true;
                Random random = new Random();
                this.userID = (random.Next(1000, 10000).ToString());
                this.label_state.Visible = true;
                this.Cursor = Cursors.WaitCursor;
                this.Refresh();
                if (!this.Login(true))
                {
                    this.label_state.Visible = false;
                    this.Cursor = Cursors.Default;
                    this.Refresh();
                    return;
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;                
            }
            catch (Exception ee)
            {
                this.label_state.Visible = false;
                this.Cursor = Cursors.Default;
                MessageBox.Show(ee.Message);
                Program.Logger.Log(ee, "LoginForm.button1_Click游客登录的处理", ESBasic.Loggers.ErrorLevel.High);
            }
        }

        //登录
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.isVisitor = false;
                if ((this.comboBox_ID.SelectedItem == null) || (this.comboBox_room.SelectedItem == null))
                {
                    MessageBox.Show("请先选择房间与账号！");
                    return;
                }
                this.userID = this.comboBox_ID.SelectedItem.ToString();
                this.roomID = this.comboBox_room.SelectedItem.ToString();
                this.label_state.Visible = true;
                this.Cursor = Cursors.WaitCursor;
                this.Refresh();
                if (!this.Login(false))
                {
                    this.label_state.Visible = false;
                    this.Cursor = Cursors.Default;
                    this.Refresh();
                    return;
                }

                UserConfiguration.Singleton.UserID = this.userID;
                UserConfiguration.Singleton.Password = this.password;
                UserConfiguration.Singleton.Save();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ee)
            {
                this.label_state.Visible = false;
                this.Cursor = Cursors.Default;
                string exceptionDetail = string.Format
 ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
                Program.Logger.Log(ee, "LoginForm.button2_Click登录的处理", ESBasic.Loggers.ErrorLevel.High);
            }
        }

        private bool Login(bool isVisitor)
        {       
            //业务逻辑服务器
            this.rapidPassiveEngine.WaitResponseTimeoutInSecs = 30;
            this.rapidPassiveEngine.HeartBeatSpanInSecs = 5;
            this.rapidPassiveEngine.SecurityLogEnabled = false;            
            
            groupOutter.TryP2PWhenGroupmateConnected = false;
            groupOutter.RapidPassiveEngine = this.rapidPassiveEngine;
            DynamicGroupPassiveHandler groupPassiveHandler = new DynamicGroupPassiveHandler();
            groupPassiveHandler.Initialize(groupOutter);

            NDiskPassiveHandler nDiskPassiveHandler = new NDiskPassiveHandler();

            ComplexCustomizeHandler handler = new ComplexCustomizeHandler(this.customizeHandler, groupPassiveHandler, nDiskPassiveHandler);
            this.rapidPassiveEngine.SystemToken = isVisitor ? "visitor" : "member";      
           

            //OMCS 参数设置            
            multimediaManager.ChannelMode = (OMCS.Passive.ChannelMode)Enum.Parse(typeof(OMCS.Passive.ChannelMode), ConfigurationManager.AppSettings["ChannelMode"]);
            multimediaManager.AutoReconnect = false;
            multimediaManager.SecurityLogEnabled = true;        
            multimediaManager.CameraDeviceIndex = 0;
            multimediaManager.MicrophoneDeviceIndex = int.Parse(ConfigurationManager.AppSettings["MicrophoneIndex"]);
            multimediaManager.SpeakerIndex = int.Parse(ConfigurationManager.AppSettings["SpeakerIndex"]);                    
            multimediaManager.AutoAdjustCameraEncodeQuality = false;
            multimediaManager.CameraEncodeQuality = 3;
            multimediaManager.MaxCameraFrameRate = 12;
            multimediaManager.MaxDesktopFrameRate = 3;           
            multimediaManager.Advanced.AllowDiscardFrameWhenBroadcast = false;
            multimediaManager.Advanced.MaxInterval4CameraKeyFrame = 20;
            multimediaManager.Advanced.MaxInterval4DesktopKeyFrame = 20;
            multimediaManager.Advanced.VideoQualityEnhanced = false;
            multimediaManager.Advanced.VideoBitrateControlType4Desktop = BitrateControlType.CQP;
            multimediaManager.Advanced.VideoBitrateControlType4Camera = BitrateControlType.ABR;
                     
            IList<CameraInformation> cameras = Camera.GetCameras();
            if (cameras.Count == 0 || cameras.Count < UserConfiguration.Singleton.WebcamIndex + 1)
            {
                UserConfiguration.Singleton.WebcamIndex = 0;
            }
            this.multimediaManager.CameraDeviceIndex = UserConfiguration.Singleton.WebcamIndex;
            try
            {
                string[] cameraSizeStr = ConfigurationManager.AppSettings["CameraVideoSize"].Split(',');
                multimediaManager.CameraVideoSize = new System.Drawing.Size(int.Parse(cameraSizeStr[0]), int.Parse(cameraSizeStr[1]));
            }
            catch { }
               
            multimediaManager.Initialize(userID, "", ConfigurationManager.AppSettings["ServerIP"], int.Parse(ConfigurationManager.AppSettings["OmcsPort"]));
            multimediaManager.OutputAudio = true;
           
            LogonResponse result = this.rapidPassiveEngine.Initialize(this.userID, this.password, ConfigurationManager.AppSettings["ServerIP"], int.Parse(ConfigurationManager.AppSettings["ServerPort"]), handler);
            if (result.LogonResult != LogonResult.Succeed)
            {
                if (result.LogonResult == LogonResult.HadLoggedOn)
                {
                    MessageBox.Show("已经在其它地方登录！");
                }
                else
                {
                    MessageBox.Show("用户或者密码错误！");
                }
                return false;
            }
            groupOutter.Initialize(this.rapidPassiveEngine.CurrentUserID);
            nDiskPassiveHandler.Initialize(this.rapidPassiveEngine.FileOutter, null);
            return true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.cnblogs.com/justnow");
        }
    }
    
}
