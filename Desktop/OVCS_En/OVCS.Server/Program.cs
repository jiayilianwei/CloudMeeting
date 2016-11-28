using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESPlus.Rapid;
using System.Configuration;
using ESPlus.Application.Group.Server;
using ESPlus.Application.Group;
using ESPlus.Core;
using ESPlus.Application.CustomizeInfo;
using ESFramework.Boost.DynamicGroup.Server;
using ESFramework.Boost.NetworkDisk.Server;
using OMCS.Passive;
using System.IO;
using Oraycn.MFile;
using OMCS.Passive.MultiChat;
using OMCS.Contracts;
using ESBasic;
using System.Threading;
using System.Drawing;
using OMCS.Boost.Forms;

namespace OVCS.Server
{
    static class Program
    {
        static IRapidServerEngine RapidServerEngine = RapidEngineFactory.CreateServerEngine();
        static OMCS.Server.IMultimediaServer MultimediaServer;
        static OMCS.Passive.Audio.MicrophoneConnector MicrophoneConnector1;
        static OMCS.Passive.Video.DynamicCameraConnector DynamicCameraConnector1;
        static OMCS.Passive.Audio.MicrophoneConnector MicrophoneConnector2;
        static OMCS.Passive.Video.DynamicCameraConnector DynamicCameraConnector2;
        static OMCS.Passive.Audio.MicrophoneConnector MicrophoneConnector3;
        static OMCS.Passive.Video.DynamicCameraConnector DynamicCameraConnector3;
        static OMCS.Passive.Audio.MicrophoneConnector MicrophoneConnector4;
        static OMCS.Passive.Video.DynamicCameraConnector DynamicCameraConnector4;
        static IMultimediaManager MultimediaManager;
        static SilenceVideoFileMaker SilenceVideoFileMaker1;
        static SilenceVideoFileMaker SilenceVideoFileMaker2;
        static SilenceVideoFileMaker SilenceVideoFileMaker3;
        static SilenceVideoFileMaker SilenceVideoFileMaker4;
        static AudioFileMaker AudioFileMaker1;
        static AudioFileMaker AudioFileMaker2;
        static AudioFileMaker AudioFileMaker3;
        static AudioFileMaker AudioFileMaker4;
        static System.Threading.Timer Timer1;
        static System.Threading.Timer Timer2;
        static System.Threading.Timer Timer3;
        static System.Threading.Timer Timer4;
        static IChatGroup ChatGroupA;
        static IChatGroup ChatGroupB;
       
        /// <summary>
        /// 应用程序的主入口点.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                ESPlus.GlobalUtil.SetMaxLengthOfUserID(byte.Parse(ConfigurationManager.AppSettings["MaxLengthOfUserID"]));
                ESPlus.GlobalUtil.SetAuthorizedUser("FreeUser", "");

                //Timer timer = new Timer();
                //timer.Interval = 1000;
                //timer.Tick += new System.EventHandler(Program.Test);

                Program.SilenceVideoFileMaker1 = new Oraycn.MFile.SilenceVideoFileMaker();
                Program.SilenceVideoFileMaker2 = new Oraycn.MFile.SilenceVideoFileMaker();
                Program.SilenceVideoFileMaker3 = new Oraycn.MFile.SilenceVideoFileMaker();
                Program.SilenceVideoFileMaker4 = new Oraycn.MFile.SilenceVideoFileMaker();    
                Program.AudioFileMaker1 = new Oraycn.MFile.AudioFileMaker();
                Program.AudioFileMaker2 = new Oraycn.MFile.AudioFileMaker();
                Program.AudioFileMaker3 = new Oraycn.MFile.AudioFileMaker();
                Program.AudioFileMaker4 = new Oraycn.MFile.AudioFileMaker();

                DynamicGroupManager dynamicGroupManager = new DynamicGroupManager();//视频会议Room管理、即动态组管理
                Program.RapidServerEngine.HeartbeatTimeoutInSecs = int.Parse(ConfigurationManager.AppSettings["HeartbeatTimeoutInSecs"]);
                Program.RapidServerEngine.UseAsP2PServer = true;
                Program.RapidServerEngine.GroupManager = dynamicGroupManager;


                Program.RapidServerEngine.SecurityLogEnabled = false;
                CustomizeInfoHandler customizeInfoHandler = new CustomizeInfoHandler();
               
                DynamicGroupHandler groupHandler = new DynamicGroupHandler();

                NDiskHandler nDiskHandler = new NDiskHandler();

                ComplexCustomizeHandler complexHandler = new ComplexCustomizeHandler(customizeInfoHandler, groupHandler, nDiskHandler);
                Program.RapidServerEngine.Initialize(int.Parse(ConfigurationManager.AppSettings["Port"]), complexHandler);
                Program.RapidServerEngine.GroupController.GroupNotifyEnabled = true;
                Program.RapidServerEngine.UserManager.RelogonMode = ESFramework.Server.UserManagement.RelogonMode.IgnoreNew;               
                groupHandler.Initialize(Program.RapidServerEngine.UserManager, Program.RapidServerEngine.CustomizeController, dynamicGroupManager);
                NetworkDisk networkDisk = new NetworkDisk(new NDiskPathManager(), Program.RapidServerEngine.FileController);
                nDiskHandler.Initialize(Program.RapidServerEngine.FileController, networkDisk);
                Program.RapidServerEngine.UserManager.SomeOneConnected += new ESBasic.CbGeneric<ESFramework.Server.UserManagement.UserData>(UserManager_SomeOneConnected);
                Program.RapidServerEngine.UserManager.SomeOneDisconnected += new ESBasic.CbGeneric<ESFramework.Server.UserManagement.UserData, ESFramework.Server.DisconnectedType>(UserManager_SomeOneDisconnected);

                #region OMCS Server设置
                OMCS.GlobalUtil.SetMaxLengthOfUserID(byte.Parse(ConfigurationManager.AppSettings["MaxLengthOfUserID"]));
                OMCS.OMCSConfiguration config = new OMCS.OMCSConfiguration();

                //用于验证登录用户的帐密
                OMCS.Server.DefaultUserVerifier userVerifier = new OMCS.Server.DefaultUserVerifier();
                Program.MultimediaServer = OMCS.Server.MultimediaServerFactory.CreateMultimediaServer(int.Parse(ConfigurationManager.AppSettings["OMCS_Port"]), userVerifier, config, bool.Parse(ConfigurationManager.AppSettings["SecurityLogEnabled"]));
                Program.MultimediaServer.MaxChannelCacheSize = 50;
                Program.MultimediaServer.UncompletedSendingCount4Busy = 2;                
                #endregion

                OmcsServerForm form = new OmcsServerForm(Program.MultimediaServer);
                form.Text = "CloudMeeting.Server"; 
             
                Program.DynamicCameraConnector1 = new OMCS.Passive.Video.DynamicCameraConnector();
                Program.MicrophoneConnector1 = new OMCS.Passive.Audio.MicrophoneConnector();
                Program.DynamicCameraConnector2 = new OMCS.Passive.Video.DynamicCameraConnector();
                Program.MicrophoneConnector2 = new OMCS.Passive.Audio.MicrophoneConnector();
                Program.DynamicCameraConnector3 = new OMCS.Passive.Video.DynamicCameraConnector();
                Program.MicrophoneConnector3 = new OMCS.Passive.Audio.MicrophoneConnector();
                Program.DynamicCameraConnector4 = new OMCS.Passive.Video.DynamicCameraConnector();
                Program.MicrophoneConnector4 = new OMCS.Passive.Audio.MicrophoneConnector();

                Program.MultimediaManager = MultimediaManagerFactory.GetSingleton();
                Program.MultimediaManager.Initialize("_server", "", "127.0.0.1", Program.MultimediaServer.Port);
                Program.ChatGroupA = Program.MultimediaManager.ChatGroupEntrance.Join(ChatType.Video, "Room1");
                Program.ChatGroupB = Program.MultimediaManager.ChatGroupEntrance.Join(ChatType.Video, "Room2");
                Program.ChatGroupA.SomeoneJoin += new ESBasic.CbGeneric<IChatUnit>(ChatGroupA_SomeoneJoin);
                Program.ChatGroupA.SomeoneExit += new ESBasic.CbGeneric<string>(ChatGroupA_SomeoneExit);
                Program.ChatGroupB.SomeoneJoin += new ESBasic.CbGeneric<IChatUnit>(ChatGroupB_SomeoneJoin);
                Program.ChatGroupB.SomeoneExit += new ESBasic.CbGeneric<string>(ChatGroupB_SomeoneExit);
                    
                Program.DynamicCameraConnector1.ConnectEnded += new ESBasic.CbGeneric<ConnectResult>(DynamicCameraConnector1_ConnectEnded);
                Program.MicrophoneConnector1.ConnectEnded += new ESBasic.CbGeneric<ConnectResult>(MicrophoneConnector1_ConnectEnded);
                Program.DynamicCameraConnector2.ConnectEnded += new ESBasic.CbGeneric<ConnectResult>(DynamicCameraConnector2_ConnectEnded);
                Program.MicrophoneConnector2.ConnectEnded += new ESBasic.CbGeneric<ConnectResult>(MicrophoneConnector2_ConnectEnded);
                Program.DynamicCameraConnector3.ConnectEnded += new ESBasic.CbGeneric<ConnectResult>(DynamicCameraConnector3_ConnectEnded);
                Program.MicrophoneConnector3.ConnectEnded += new ESBasic.CbGeneric<ConnectResult>(MicrophoneConnector3_ConnectEnded);
                Program.DynamicCameraConnector4.ConnectEnded += new ESBasic.CbGeneric<ConnectResult>(DynamicCameraConnector4_ConnectEnded);
                Program.MicrophoneConnector4.ConnectEnded += new ESBasic.CbGeneric<ConnectResult>(MicrophoneConnector4_ConnectEnded);

                Program.DynamicCameraConnector1.Disconnected += new CbGeneric<ConnectorDisconnectedType>(DynamicCameraConnector1_Disconnected);
                Program.MicrophoneConnector1.Disconnected += new CbGeneric<ConnectorDisconnectedType>(MicrophoneConnector1_Disconnected);
                Program.DynamicCameraConnector2.Disconnected += new CbGeneric<ConnectorDisconnectedType>(DynamicCameraConnector2_Disconnected);
                Program.MicrophoneConnector2.Disconnected += new CbGeneric<ConnectorDisconnectedType>(MicrophoneConnector2_Disconnected);
                Program.DynamicCameraConnector3.Disconnected += new CbGeneric<ConnectorDisconnectedType>(DynamicCameraConnector3_Disconnected);
                Program.MicrophoneConnector3.Disconnected += new CbGeneric<ConnectorDisconnectedType>(MicrophoneConnector3_Disconnected);
                Program.DynamicCameraConnector4.Disconnected += new CbGeneric<ConnectorDisconnectedType>(DynamicCameraConnector4_Disconnected);
                Program.MicrophoneConnector4.Disconnected += new CbGeneric<ConnectorDisconnectedType>(MicrophoneConnector4_Disconnected);
                
                
                Program.MicrophoneConnector1.AudioDataReceived += new CbGeneric<byte[]>(MicrophoneConnector1_AudioDataReceived);
                Program.MicrophoneConnector2.AudioDataReceived += new CbGeneric<byte[]>(MicrophoneConnector2_AudioDataReceived);
                Program.MicrophoneConnector3.AudioDataReceived += new CbGeneric<byte[]>(MicrophoneConnector3_AudioDataReceived);
                Program.MicrophoneConnector4.AudioDataReceived += new CbGeneric<byte[]>(MicrophoneConnector4_AudioDataReceived);
                
                string path1= string.Format("VideoFile\\{0}", Program.ChatGroupA.GroupID);
                string path2 = string.Format("VideoFile\\{0}", Program.ChatGroupB.GroupID);
                Directory.CreateDirectory(path1);
                Directory.CreateDirectory(path2);
                string path3 = string.Format("AudioFile\\{0}", Program.ChatGroupA.GroupID);
                string path4 = string.Format("AudioFile\\{0}", Program.ChatGroupB.GroupID);
                Directory.CreateDirectory(path3);
                Directory.CreateDirectory(path4);

                Application.Run(form);
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
        }

        static void MicrophoneConnector4_Disconnected(ConnectorDisconnectedType obj)
        {
            try
            {
                Thread.Sleep(500);
                Program.AudioFileMaker4.Close(true);
                Program.AudioFileMaker4.Dispose();
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
           
        }

        static void DynamicCameraConnector4_Disconnected(ConnectorDisconnectedType obj)
        {
            try
            {
                Thread.Sleep(500);
                Program.SilenceVideoFileMaker4.Close(true);
                Program.SilenceVideoFileMaker4.Dispose();
                Program.Timer4.Dispose();
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
           
        }

        static void MicrophoneConnector3_Disconnected(ConnectorDisconnectedType obj)
        {
            try
            {
                Thread.Sleep(500);
                Program.AudioFileMaker3.Close(true);
                Program.AudioFileMaker3.Dispose();
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
          
        }

        static void DynamicCameraConnector3_Disconnected(ConnectorDisconnectedType obj)
        {
            try
            {
                Thread.Sleep(500);
                Program.SilenceVideoFileMaker3.Close(true);
                Program.SilenceVideoFileMaker3.Dispose();
                Program.Timer3.Dispose();
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
          
        }

        static void MicrophoneConnector2_Disconnected(ConnectorDisconnectedType obj)
        {
            try
            {
                Thread.Sleep(500);
                Program.AudioFileMaker2.Close(true);
                Program.AudioFileMaker2.Dispose();
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
          
        }

        static void DynamicCameraConnector2_Disconnected(ConnectorDisconnectedType obj)
        {
            try
            {
                Thread.Sleep(500);
                Program.SilenceVideoFileMaker2.Close(true);
                Program.SilenceVideoFileMaker2.Dispose();
                Program.Timer2.Dispose();
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
           
        }

        static void MicrophoneConnector1_Disconnected(ConnectorDisconnectedType obj)
        {
            try
            {
                Thread.Sleep(500);
                Program.AudioFileMaker1.Close(true);
                Program.AudioFileMaker1.Dispose();
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }          
        }

        static void DynamicCameraConnector1_Disconnected(ConnectorDisconnectedType obj)
        {
            try
            {
                Thread.Sleep(500);
                Program.SilenceVideoFileMaker1.Close(true);
                Program.SilenceVideoFileMaker1.Dispose();
                Program.Timer1.Dispose();
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }           
        }


        static void MicrophoneConnector4_AudioDataReceived(byte[] audio)
        {
            try
            {
                Program.AudioFileMaker4.AddAudioFrame(audio);
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
           
        }

        static void MicrophoneConnector3_AudioDataReceived(byte[] audio)
        {
            try
            {
                Program.AudioFileMaker3.AddAudioFrame(audio);
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
          
        }

        static void MicrophoneConnector2_AudioDataReceived(byte[] audio)
        {
            try
            {
                Program.AudioFileMaker2.AddAudioFrame(audio);
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
          
        }

        static void MicrophoneConnector1_AudioDataReceived(byte[] audio)
        {
            try
            {
                Program.AudioFileMaker1.AddAudioFrame(audio);
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
          
        }


        static void ChatGroupB_SomeoneExit(string userID)
        {
            try
            {
                if (userID.Contains("1"))
                {
                    Program.DynamicCameraConnector1.Disconnect();
                    Program.MicrophoneConnector1.Disconnect();
                }
                if (userID.Contains("2"))
                {
                    Program.DynamicCameraConnector2.Disconnect();
                    Program.MicrophoneConnector2.Disconnect();
                }
                if (userID.Contains("3"))
                {
                    Program.DynamicCameraConnector3.Disconnect();
                    Program.MicrophoneConnector3.Disconnect();
                }
                if (userID.Contains("4"))
                {
                    Program.DynamicCameraConnector4.Disconnect();
                    Program.MicrophoneConnector4.Disconnect();
                }
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
           
        }

        static void ChatGroupB_SomeoneJoin(IChatUnit userData)
        {
            try
            {
                if (userData.MemberID.Contains("1"))
                {
                    Program.DynamicCameraConnector1.BeginConnect(userData.MemberID);
                    Program.MicrophoneConnector1.BeginConnect(userData.MemberID);
                }
                if (userData.MemberID.Contains("2"))
                {
                    Program.DynamicCameraConnector2.BeginConnect(userData.MemberID);
                    Program.MicrophoneConnector2.BeginConnect(userData.MemberID);
                }
                if (userData.MemberID.Contains("3"))
                {
                    Program.DynamicCameraConnector3.BeginConnect(userData.MemberID);
                    Program.MicrophoneConnector3.BeginConnect(userData.MemberID);
                }
                if (userData.MemberID.Contains("4"))
                {
                    Program.DynamicCameraConnector4.BeginConnect(userData.MemberID);
                    Program.MicrophoneConnector4.BeginConnect(userData.MemberID);
                }
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
  
        }

        static void ChatGroupA_SomeoneExit(string userID)
        {
            try
            {
                if (userID.Contains("1"))
                {
                    Program.DynamicCameraConnector1.Disconnect();
                    Program.MicrophoneConnector1.Disconnect();
                }
                if (userID.Contains("2"))
                {
                    Program.DynamicCameraConnector2.Disconnect();
                    Program.MicrophoneConnector2.Disconnect();
                }
                if (userID.Contains("3"))
                {
                    Program.DynamicCameraConnector3.Disconnect();
                    Program.MicrophoneConnector3.Disconnect();
                }
                if (userID.Contains("4"))
                {
                    Program.DynamicCameraConnector4.Disconnect();
                    Program.MicrophoneConnector4.Disconnect();
                }
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
        }

        static void ChatGroupA_SomeoneJoin(IChatUnit userData)
        {
            try
            {
                if (userData.MemberID.Contains("1"))
                {
                    Program.DynamicCameraConnector1.BeginConnect(userData.MemberID);
                    Program.MicrophoneConnector1.BeginConnect(userData.MemberID);
                }
                if (userData.MemberID.Contains("2"))
                {
                    Program.DynamicCameraConnector2.BeginConnect(userData.MemberID);
                    Program.MicrophoneConnector2.BeginConnect(userData.MemberID);
                }
                if (userData.MemberID.Contains("3"))
                {
                    Program.DynamicCameraConnector3.BeginConnect(userData.MemberID);
                    Program.MicrophoneConnector3.BeginConnect(userData.MemberID);
                }
                if (userData.MemberID.Contains("4"))
                {
                    Program.DynamicCameraConnector4.BeginConnect(userData.MemberID);
                    Program.MicrophoneConnector4.BeginConnect(userData.MemberID);
                }
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
           
        }


        static void MicrophoneConnector4_ConnectEnded(ConnectResult result)
        {
            try
            {
                if (result != ConnectResult.Succeed)
                {
                    File.AppendAllText("AudioConnectLog.txt", DateTime.Now.ToString() + "\r\n" + Program.MicrophoneConnector4.OwnerID + ":" + result.ToString() + "\r\n");
                    if (result == ConnectResult.OwnerNotInitialized)
                    {
                        Program.MicrophoneConnector4.BeginConnect(Program.MicrophoneConnector4.OwnerID);
                    }
                    return;
                }
                if (Program.GetRoomID("004") == null)
                {
                    return;
                }
                Thread.Sleep(500);
                string path = string.Format("AudioFile\\{0}\\{4}.mp3", Program.GetRoomID("004"), "004");
                Program.AudioFileMaker4.Initialize(path, AudioCodecType.MP3, 16000, 1);
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
          
        }

        static void DynamicCameraConnector4_ConnectEnded(ConnectResult result)
        {
            try
            {
                if (result != ConnectResult.Succeed)
                {
                    File.AppendAllText("VideoConnectLog.txt", DateTime.Now.ToString() + "\r\n" + Program.DynamicCameraConnector4.OwnerID + ":" + result.ToString() + "\r\n");
                    if (result == ConnectResult.OwnerNotInitialized)
                    {
                        Program.DynamicCameraConnector4.BeginConnect(Program.DynamicCameraConnector4.OwnerID);
                    }
                    return;
                }
                if (Program.GetRoomID("004") == null)
                {
                    return;
                }
                Thread.Sleep(500);
                string path = string.Format("VideoFile\\{0}\\{4}.mp4", Program.GetRoomID("004"), "004");
                Program.SilenceVideoFileMaker4.Initialize(path, VideoCodecType.H264, Program.DynamicCameraConnector4.VideoSize.Width, Program.DynamicCameraConnector4.VideoSize.Height, 10, VideoQuality.High);
                Program.Timer4 = new System.Threading.Timer(new System.Threading.TimerCallback(Program.Callback4), null, 0, 100);
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
           
        }

        static void MicrophoneConnector3_ConnectEnded(ConnectResult result)
        {
            try
            {
                if (result != ConnectResult.Succeed)
                {
                    File.AppendAllText("AudioConnectLog.txt", DateTime.Now.ToString() + "\r\n" + Program.MicrophoneConnector3.OwnerID + ":" + result.ToString() + "\r\n");
                    if (result == ConnectResult.OwnerNotInitialized)
                    {
                        Program.MicrophoneConnector3.BeginConnect(Program.MicrophoneConnector3.OwnerID);
                    }
                    return;
                }
                if (Program.GetRoomID("003") == null)
                {
                    return;
                }
                Thread.Sleep(500);
                string path = string.Format("AudioFile\\{0}\\{3}.mp3", Program.GetRoomID("003"), "003");
                Program.AudioFileMaker3.Initialize(path, AudioCodecType.MP3, 16000, 1);
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
         
        }

        static void DynamicCameraConnector3_ConnectEnded(ConnectResult result)
        {
            try
            {
                if (result != ConnectResult.Succeed)
                {
                    File.AppendAllText("VideoConnectLog.txt", DateTime.Now.ToString() + "\r\n" + Program.DynamicCameraConnector3.OwnerID + ":" + result.ToString() + "\r\n");
                    if (result == ConnectResult.OwnerNotInitialized)
                    {
                        Program.DynamicCameraConnector3.BeginConnect(Program.DynamicCameraConnector3.OwnerID);
                    }
                    return;
                }
                if (Program.GetRoomID("003") == null)
                {
                    return;
                }
                Thread.Sleep(500);
                string path = string.Format("VideoFile\\{0}\\{3}.mp4", Program.GetRoomID("003"), "003");
                Program.SilenceVideoFileMaker3.Initialize(path, VideoCodecType.H264, Program.DynamicCameraConnector3.VideoSize.Width, Program.DynamicCameraConnector3.VideoSize.Height, 10, VideoQuality.High);
                Program.Timer3 = new System.Threading.Timer(new System.Threading.TimerCallback(Program.Callback3), null, 0, 100);
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
            
        }

        static void MicrophoneConnector2_ConnectEnded(ConnectResult result)
        {
            try
            {
                if (result != ConnectResult.Succeed)
                {
                    File.AppendAllText("AudioConnectLog.txt", DateTime.Now.ToString() + "\r\n" + Program.MicrophoneConnector2.OwnerID + ":" + result.ToString() + "\r\n");
                    if (result == ConnectResult.OwnerNotInitialized)
                    {
                        Program.MicrophoneConnector2.BeginConnect(Program.MicrophoneConnector2.OwnerID);
                    }
                    return;
                }
                if (Program.GetRoomID("002") == null)
                {
                    return;
                }
                Thread.Sleep(500);
                string path = string.Format("AudioFile\\{0}\\{2}.mp3", Program.GetRoomID("002"), "002");
                Program.AudioFileMaker2.Initialize(path, AudioCodecType.MP3, 16000, 1);
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
          
        }

        static void DynamicCameraConnector2_ConnectEnded(ConnectResult result)
        {
            try
            {
                if (result != ConnectResult.Succeed)
                {
                    File.AppendAllText("VideoConnectLog.txt", DateTime.Now.ToString() + "\r\n" + Program.DynamicCameraConnector2.OwnerID + ":" + result.ToString() + "\r\n");
                    if (result == ConnectResult.OwnerNotInitialized)
                    {
                        Program.DynamicCameraConnector2.BeginConnect(Program.DynamicCameraConnector2.OwnerID);
                    }
                    return;
                }
                if (Program.GetRoomID("002") == null)
                {
                    return;
                }
                Thread.Sleep(500);
                string path = string.Format("VideoFile\\{0}\\{2}.mp4", Program.GetRoomID("002"), "002");
                Program.SilenceVideoFileMaker2.Initialize(path, VideoCodecType.H264, Program.DynamicCameraConnector2.VideoSize.Width, Program.DynamicCameraConnector2.VideoSize.Height, 10, VideoQuality.High);
                Program.Timer2 = new System.Threading.Timer(new System.Threading.TimerCallback(Program.Callback2), null, 0, 100);
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
           
        }

        static void MicrophoneConnector1_ConnectEnded(ConnectResult result)
        {
            try
            {
                if (result != ConnectResult.Succeed)
                {
                    File.AppendAllText("AudioConnectLog.txt", DateTime.Now.ToString() + "\r\n" + Program.MicrophoneConnector1.OwnerID + ":" + result.ToString() + "\r\n");
                    if (result == ConnectResult.OwnerNotInitialized)
                    {
                        Program.MicrophoneConnector1.BeginConnect(Program.MicrophoneConnector1.OwnerID);
                    }
                    return;
                }
                if (Program.GetRoomID("001") == null)
                {
                    return;
                }
                Thread.Sleep(500);
                string path = string.Format("AudioFile\\{0}\\{1}.mp3", Program.GetRoomID("001"), "001");
                Program.AudioFileMaker1.Initialize(path, AudioCodecType.MP3, 16000, 1);
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
           
        }

        static void DynamicCameraConnector1_ConnectEnded(ConnectResult result)
        {
            try
            {
                if (result != ConnectResult.Succeed)
                {
                    File.AppendAllText("VideoConnectLog.txt", DateTime.Now.ToString() + "\r\n" + Program.DynamicCameraConnector1.OwnerID + ":" + result.ToString() + "\r\n");
                    if (result == ConnectResult.OwnerNotInitialized)
                    {
                        Program.DynamicCameraConnector1.BeginConnect(Program.DynamicCameraConnector1.OwnerID);
                    }
                    return;
                }
                if (Program.GetRoomID("001") == null)
                {
                    return;
                }
                Thread.Sleep(500);
                string path = string.Format("VideoFile\\{0}\\{1}.mp4", Program.GetRoomID("001"), "001");
                Program.SilenceVideoFileMaker1.Initialize(path, VideoCodecType.H264, Program.DynamicCameraConnector1.VideoSize.Width, Program.DynamicCameraConnector1.VideoSize.Height, 10, VideoQuality.High);
                Program.Timer1 = new System.Threading.Timer(new System.Threading.TimerCallback(Program.Callback1), null, 0, 100);
            }
            catch (Exception ee)
            {
                string exceptionDetail = string.Format
                ("Message:{0}\r\nSource:{1}\r\nStackTrace:{2}", ee.Message, ee.Source, ee.StackTrace);
                MessageBox.Show(exceptionDetail);
            }
        }

        static void Callback1(object state)
        {
            if (Program.SilenceVideoFileMaker1 != null)
            {
                Bitmap bm = Program.DynamicCameraConnector1.GetCurrentImage();
                if (bm != null)
                {                  
                    Program.SilenceVideoFileMaker1.AddVideoFrame(bm);                  
                }            
            } 
        }
        static void Callback2(object state)
        {
            if (Program.SilenceVideoFileMaker2 != null)
            {
                Bitmap bm = Program.DynamicCameraConnector2.GetCurrentImage();
                if (bm != null)
                {
                    Program.SilenceVideoFileMaker2.AddVideoFrame(bm);
                }
            } 
        }
        static void Callback3(object state)
        {
            if (Program.SilenceVideoFileMaker3 != null)
            {
                Bitmap bm = Program.DynamicCameraConnector3.GetCurrentImage();
                if (bm != null)
                {
                    Program.SilenceVideoFileMaker3.AddVideoFrame(bm);
                }
            } 
        }
        static void Callback4(object state)
        {
            if (Program.SilenceVideoFileMaker4 != null)
            {
                Bitmap bm = Program.DynamicCameraConnector4.GetCurrentImage();
                if (bm != null)
                {
                    Program.SilenceVideoFileMaker4.AddVideoFrame(bm);
                }
            } 
        }

        static string GetRoomID(string userID)
        {
            foreach (var item in Program.ChatGroupA.GetOtherMembers())
            {
                if (item.MemberID == userID)
                {
                    return Program.ChatGroupA.GroupID;
                }
            }
            foreach (var item in Program.ChatGroupB.GetOtherMembers())
            {
                if (item.MemberID == userID)
                {
                    return Program.ChatGroupB.GroupID;
                }
            }
            return null; 
        }        

        static void UserManager_SomeOneDisconnected(ESFramework.Server.UserManagement.UserData userData, ESFramework.Server.DisconnectedType obj2)
        {
            return;
        }

        static void UserManager_SomeOneConnected(ESFramework.Server.UserManagement.UserData userData)
        {
            int  i = Program.ChatGroupA.GetOtherMembers().Count;
        }

        static void Test(object sender, EventArgs e)
        {
            int i = Program.ChatGroupA.GetOtherMembers().Count;
            File.AppendAllText("iiii.txt", i.ToString());
        }
    }
}
