namespace OVCS
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label_state = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_room = new System.Windows.Forms.ComboBox();
            this.comboBox_ID = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(112, 156);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 44);
            this.button2.TabIndex = 3;
            this.button2.Text = "登    录";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(75, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "登录号码：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Location = new System.Drawing.Point(5, 229);
            this.label_state.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(160, 15);
            this.label_state.TabIndex = 6;
            this.label_state.Text = "正在连接服务器......";
            this.label_state.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(75, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "房间号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox_room
            // 
            this.comboBox_room.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_room.FormattingEnabled = true;
            this.comboBox_room.Items.AddRange(new object[] {
            "Room1",
            "Room2"});
            this.comboBox_room.Location = new System.Drawing.Point(174, 51);
            this.comboBox_room.Name = "comboBox_room";
            this.comboBox_room.Size = new System.Drawing.Size(121, 23);
            this.comboBox_room.TabIndex = 7;
            // 
            // comboBox_ID
            // 
            this.comboBox_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ID.FormattingEnabled = true;
            this.comboBox_ID.Items.AddRange(new object[] {
            "001",
            "002",
            "003",
            "004"});
            this.comboBox_ID.Location = new System.Drawing.Point(173, 100);
            this.comboBox_ID.Name = "comboBox_ID";
            this.comboBox_ID.Size = new System.Drawing.Size(121, 23);
            this.comboBox_ID.TabIndex = 8;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.button2;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 244);
            this.Controls.Add(this.comboBox_ID);
            this.Controls.Add(this.comboBox_room);
            this.Controls.Add(this.label_state);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(438, 289);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(438, 289);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OVCS视频会议系统 2015";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_room;
        private System.Windows.Forms.ComboBox comboBox_ID;
    }
}