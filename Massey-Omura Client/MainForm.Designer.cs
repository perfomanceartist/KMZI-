namespace Massey_Omura_Client
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageInbox = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxInboxParams = new System.Windows.Forms.GroupBox();
            this.textBoxInboxPort = new System.Windows.Forms.TextBox();
            this.textBoxInboxIP = new System.Windows.Forms.TextBox();
            this.checkBoxListen = new System.Windows.Forms.CheckBox();
            this.labelInboxPort = new System.Windows.Forms.Label();
            this.labelInboxIP = new System.Windows.Forms.Label();
            this.tabPageNew = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBoxNewParams = new System.Windows.Forms.GroupBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxNewPort = new System.Windows.Forms.TextBox();
            this.textBoxNewIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControlMain.SuspendLayout();
            this.tabPageInbox.SuspendLayout();
            this.groupBoxInboxParams.SuspendLayout();
            this.tabPageNew.SuspendLayout();
            this.groupBoxNewParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageInbox);
            this.tabControlMain.Controls.Add(this.tabPageNew);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(274, 426);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageInbox
            // 
            this.tabPageInbox.Controls.Add(this.flowLayoutPanel);
            this.tabPageInbox.Controls.Add(this.groupBoxInboxParams);
            this.tabPageInbox.Location = new System.Drawing.Point(4, 24);
            this.tabPageInbox.Name = "tabPageInbox";
            this.tabPageInbox.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInbox.Size = new System.Drawing.Size(266, 398);
            this.tabPageInbox.TabIndex = 0;
            this.tabPageInbox.Text = "Входящие";
            this.tabPageInbox.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(6, 100);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(254, 292);
            this.flowLayoutPanel.TabIndex = 1;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // groupBoxInboxParams
            // 
            this.groupBoxInboxParams.Controls.Add(this.textBoxInboxPort);
            this.groupBoxInboxParams.Controls.Add(this.textBoxInboxIP);
            this.groupBoxInboxParams.Controls.Add(this.checkBoxListen);
            this.groupBoxInboxParams.Controls.Add(this.labelInboxPort);
            this.groupBoxInboxParams.Controls.Add(this.labelInboxIP);
            this.groupBoxInboxParams.Location = new System.Drawing.Point(6, 6);
            this.groupBoxInboxParams.Name = "groupBoxInboxParams";
            this.groupBoxInboxParams.Size = new System.Drawing.Size(254, 75);
            this.groupBoxInboxParams.TabIndex = 0;
            this.groupBoxInboxParams.TabStop = false;
            this.groupBoxInboxParams.Text = "Параметры";
            // 
            // textBoxInboxPort
            // 
            this.textBoxInboxPort.Location = new System.Drawing.Point(91, 37);
            this.textBoxInboxPort.Name = "textBoxInboxPort";
            this.textBoxInboxPort.Size = new System.Drawing.Size(54, 23);
            this.textBoxInboxPort.TabIndex = 4;
            this.textBoxInboxPort.Text = "9001";
            // 
            // textBoxInboxIP
            // 
            this.textBoxInboxIP.Location = new System.Drawing.Point(6, 37);
            this.textBoxInboxIP.Name = "textBoxInboxIP";
            this.textBoxInboxIP.Size = new System.Drawing.Size(68, 23);
            this.textBoxInboxIP.TabIndex = 3;
            this.textBoxInboxIP.Text = "127.0.0.1";
            // 
            // checkBoxListen
            // 
            this.checkBoxListen.AutoSize = true;
            this.checkBoxListen.Location = new System.Drawing.Point(163, 37);
            this.checkBoxListen.Name = "checkBoxListen";
            this.checkBoxListen.Size = new System.Drawing.Size(75, 19);
            this.checkBoxListen.TabIndex = 2;
            this.checkBoxListen.Text = "Слушать";
            this.checkBoxListen.UseVisualStyleBackColor = true;
            this.checkBoxListen.CheckedChanged += new System.EventHandler(this.checkBoxListen_CheckedChanged);
            // 
            // labelInboxPort
            // 
            this.labelInboxPort.AutoSize = true;
            this.labelInboxPort.Location = new System.Drawing.Point(91, 19);
            this.labelInboxPort.Name = "labelInboxPort";
            this.labelInboxPort.Size = new System.Drawing.Size(35, 15);
            this.labelInboxPort.TabIndex = 1;
            this.labelInboxPort.Text = "Порт";
            // 
            // labelInboxIP
            // 
            this.labelInboxIP.AutoSize = true;
            this.labelInboxIP.Location = new System.Drawing.Point(6, 19);
            this.labelInboxIP.Name = "labelInboxIP";
            this.labelInboxIP.Size = new System.Drawing.Size(53, 15);
            this.labelInboxIP.TabIndex = 0;
            this.labelInboxIP.Text = "IP-адрес";
            // 
            // tabPageNew
            // 
            this.tabPageNew.Controls.Add(this.richTextBox1);
            this.tabPageNew.Controls.Add(this.groupBoxNewParams);
            this.tabPageNew.Location = new System.Drawing.Point(4, 24);
            this.tabPageNew.Name = "tabPageNew";
            this.tabPageNew.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNew.Size = new System.Drawing.Size(266, 398);
            this.tabPageNew.TabIndex = 1;
            this.tabPageNew.Text = "Новое сообщение";
            this.tabPageNew.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 87);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(254, 293);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // groupBoxNewParams
            // 
            this.groupBoxNewParams.Controls.Add(this.buttonSend);
            this.groupBoxNewParams.Controls.Add(this.textBoxNewPort);
            this.groupBoxNewParams.Controls.Add(this.textBoxNewIP);
            this.groupBoxNewParams.Controls.Add(this.label1);
            this.groupBoxNewParams.Controls.Add(this.label2);
            this.groupBoxNewParams.Location = new System.Drawing.Point(6, 6);
            this.groupBoxNewParams.Name = "groupBoxNewParams";
            this.groupBoxNewParams.Size = new System.Drawing.Size(254, 75);
            this.groupBoxNewParams.TabIndex = 1;
            this.groupBoxNewParams.TabStop = false;
            this.groupBoxNewParams.Text = "Параметры";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(164, 36);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 5;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxNewPort
            // 
            this.textBoxNewPort.Location = new System.Drawing.Point(91, 37);
            this.textBoxNewPort.Name = "textBoxNewPort";
            this.textBoxNewPort.Size = new System.Drawing.Size(54, 23);
            this.textBoxNewPort.TabIndex = 4;
            this.textBoxNewPort.Text = "9001";
            // 
            // textBoxNewIP
            // 
            this.textBoxNewIP.Location = new System.Drawing.Point(6, 37);
            this.textBoxNewIP.Name = "textBoxNewIP";
            this.textBoxNewIP.Size = new System.Drawing.Size(68, 23);
            this.textBoxNewIP.TabIndex = 3;
            this.textBoxNewIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Порт";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "IP-адрес";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 450);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Massey-Omura Client";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageInbox.ResumeLayout(false);
            this.groupBoxInboxParams.ResumeLayout(false);
            this.groupBoxInboxParams.PerformLayout();
            this.tabPageNew.ResumeLayout(false);
            this.groupBoxNewParams.ResumeLayout(false);
            this.groupBoxNewParams.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControlMain;
        private TabPage tabPageInbox;
        private TabPage tabPageNew;
        private GroupBox groupBoxInboxParams;
        private TextBox textBoxInboxPort;
        private TextBox textBoxInboxIP;
        private CheckBox checkBoxListen;
        private Label labelInboxPort;
        private Label labelInboxIP;
        private GroupBox groupBoxNewParams;
        private Button buttonSend;
        private TextBox textBoxNewPort;
        private TextBox textBoxNewIP;
        private Label label1;
        private Label label2;
        private RichTextBox richTextBox1;
        private OpenFileDialog openFileDialog;
        private FlowLayoutPanel flowLayoutPanel;
    }
}