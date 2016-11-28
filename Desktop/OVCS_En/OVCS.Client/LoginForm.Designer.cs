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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Lable3 = new System.Windows.Forms.Label();
            this.label_state = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_ID = new System.Windows.Forms.ComboBox();
            this.comboBox_RoomID = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(99, 17);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "随机帐号，Entrance测试Room";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(266, 176);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 39);
            this.button2.TabIndex = 3;
            this.button2.Text = "OK ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "UserID：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Lable3
            // 
            this.Lable3.Location = new System.Drawing.Point(5, 105);
            this.Lable3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lable3.Name = "Lable3";
            this.Lable3.Size = new System.Drawing.Size(91, 29);
            this.Lable3.TabIndex = 5;
            this.Lable3.Text = "RoomID：";
            this.Lable3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Location = new System.Drawing.Point(5, 229);
            this.label_state.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(160, 15);
            this.label_state.TabIndex = 6;
            this.label_state.Text = "ConnectingServer......";
            this.label_state.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(99, 162);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 19);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "记住密码";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "游客体验：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Visible = false;
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
            this.comboBox_ID.Location = new System.Drawing.Point(99, 62);
            this.comboBox_ID.Name = "comboBox_ID";
            this.comboBox_ID.Size = new System.Drawing.Size(121, 23);
            this.comboBox_ID.TabIndex = 8;
            // 
            // comboBox_RoomID
            // 
            this.comboBox_RoomID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RoomID.FormattingEnabled = true;
            this.comboBox_RoomID.Items.AddRange(new object[] {
            "Room1",
            "Room2"});
            this.comboBox_RoomID.Location = new System.Drawing.Point(99, 109);
            this.comboBox_RoomID.Name = "comboBox_RoomID";
            this.comboBox_RoomID.Size = new System.Drawing.Size(121, 23);
            this.comboBox_RoomID.TabIndex = 9;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.button2;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(420, 244);
            this.Controls.Add(this.comboBox_RoomID);
            this.Controls.Add(this.comboBox_ID);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label_state);
            this.Controls.Add(this.Lable3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(438, 289);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(438, 289);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CloudMeeting";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Lable3;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_ID;
        private System.Windows.Forms.ComboBox comboBox_RoomID;
    }
}