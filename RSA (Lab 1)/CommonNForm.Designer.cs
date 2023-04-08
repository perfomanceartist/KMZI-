namespace RSA__Lab_1_
{
    partial class CommonNForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommonNForm));
            this.labelCommonNPublicA = new System.Windows.Forms.Label();
            this.labelCommonNPrivateA = new System.Windows.Forms.Label();
            this.labelCommonNPublicB = new System.Windows.Forms.Label();
            this.buttonCommonNPublicA = new System.Windows.Forms.Button();
            this.buttonCommonNPrivateA = new System.Windows.Forms.Button();
            this.buttonCommonNPublicB = new System.Windows.Forms.Button();
            this.buttonCommonNAttack = new System.Windows.Forms.Button();
            this.labelCommonNP = new System.Windows.Forms.Label();
            this.labelCommonNQ = new System.Windows.Forms.Label();
            this.labelCommonND = new System.Windows.Forms.Label();
            this.textBoxCommonND = new System.Windows.Forms.TextBox();
            this.textBoxCommonNP = new System.Windows.Forms.TextBox();
            this.textBoxCommonNQ = new System.Windows.Forms.TextBox();
            this.groupBoxAttackResult = new System.Windows.Forms.GroupBox();
            this.buttonCommonNSavePrivateB = new System.Windows.Forms.Button();
            this.groupBoxCommonNKeyA = new System.Windows.Forms.GroupBox();
            this.groupBoxCommonNKeyB = new System.Windows.Forms.GroupBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxAttackResult.SuspendLayout();
            this.groupBoxCommonNKeyA.SuspendLayout();
            this.groupBoxCommonNKeyB.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCommonNPublicA
            // 
            this.labelCommonNPublicA.AutoSize = true;
            this.labelCommonNPublicA.Location = new System.Drawing.Point(7, 24);
            this.labelCommonNPublicA.Name = "labelCommonNPublicA";
            this.labelCommonNPublicA.Size = new System.Drawing.Size(108, 15);
            this.labelCommonNPublicA.TabIndex = 0;
            this.labelCommonNPublicA.Text = "Открытый ключ А";
            // 
            // labelCommonNPrivateA
            // 
            this.labelCommonNPrivateA.AutoSize = true;
            this.labelCommonNPrivateA.Location = new System.Drawing.Point(7, 53);
            this.labelCommonNPrivateA.Name = "labelCommonNPrivateA";
            this.labelCommonNPrivateA.Size = new System.Drawing.Size(107, 15);
            this.labelCommonNPrivateA.TabIndex = 1;
            this.labelCommonNPrivateA.Text = "Закрытый ключ А";
            // 
            // labelCommonNPublicB
            // 
            this.labelCommonNPublicB.AutoSize = true;
            this.labelCommonNPublicB.Location = new System.Drawing.Point(6, 24);
            this.labelCommonNPublicB.Name = "labelCommonNPublicB";
            this.labelCommonNPublicB.Size = new System.Drawing.Size(107, 15);
            this.labelCommonNPublicB.TabIndex = 2;
            this.labelCommonNPublicB.Text = "Открытый ключ Б";
            // 
            // buttonCommonNPublicA
            // 
            this.buttonCommonNPublicA.Location = new System.Drawing.Point(143, 20);
            this.buttonCommonNPublicA.Name = "buttonCommonNPublicA";
            this.buttonCommonNPublicA.Size = new System.Drawing.Size(75, 23);
            this.buttonCommonNPublicA.TabIndex = 3;
            this.buttonCommonNPublicA.Text = "Выбрать";
            this.buttonCommonNPublicA.UseVisualStyleBackColor = true;
            this.buttonCommonNPublicA.Click += new System.EventHandler(this.buttonCommonNPublicA_Click);
            // 
            // buttonCommonNPrivateA
            // 
            this.buttonCommonNPrivateA.Location = new System.Drawing.Point(143, 49);
            this.buttonCommonNPrivateA.Name = "buttonCommonNPrivateA";
            this.buttonCommonNPrivateA.Size = new System.Drawing.Size(75, 23);
            this.buttonCommonNPrivateA.TabIndex = 4;
            this.buttonCommonNPrivateA.Text = "Выбрать";
            this.buttonCommonNPrivateA.UseVisualStyleBackColor = true;
            this.buttonCommonNPrivateA.Click += new System.EventHandler(this.buttonCommonNPrivateA_Click);
            // 
            // buttonCommonNPublicB
            // 
            this.buttonCommonNPublicB.Location = new System.Drawing.Point(132, 20);
            this.buttonCommonNPublicB.Name = "buttonCommonNPublicB";
            this.buttonCommonNPublicB.Size = new System.Drawing.Size(75, 23);
            this.buttonCommonNPublicB.TabIndex = 5;
            this.buttonCommonNPublicB.Text = "Выбрать";
            this.buttonCommonNPublicB.UseVisualStyleBackColor = true;
            this.buttonCommonNPublicB.Click += new System.EventHandler(this.buttonCommonNPublicB_Click);
            // 
            // buttonCommonNAttack
            // 
            this.buttonCommonNAttack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCommonNAttack.Location = new System.Drawing.Point(14, 117);
            this.buttonCommonNAttack.Name = "buttonCommonNAttack";
            this.buttonCommonNAttack.Size = new System.Drawing.Size(498, 23);
            this.buttonCommonNAttack.TabIndex = 6;
            this.buttonCommonNAttack.Text = "Начать атаку";
            this.buttonCommonNAttack.UseVisualStyleBackColor = true;
            this.buttonCommonNAttack.Click += new System.EventHandler(this.buttonCommonNAttack_Click);
            // 
            // labelCommonNP
            // 
            this.labelCommonNP.AutoSize = true;
            this.labelCommonNP.Location = new System.Drawing.Point(10, 25);
            this.labelCommonNP.Name = "labelCommonNP";
            this.labelCommonNP.Size = new System.Drawing.Size(14, 15);
            this.labelCommonNP.TabIndex = 7;
            this.labelCommonNP.Text = "P";
            // 
            // labelCommonNQ
            // 
            this.labelCommonNQ.AutoSize = true;
            this.labelCommonNQ.Location = new System.Drawing.Point(10, 54);
            this.labelCommonNQ.Name = "labelCommonNQ";
            this.labelCommonNQ.Size = new System.Drawing.Size(16, 15);
            this.labelCommonNQ.TabIndex = 8;
            this.labelCommonNQ.Text = "Q";
            // 
            // labelCommonND
            // 
            this.labelCommonND.AutoSize = true;
            this.labelCommonND.Location = new System.Drawing.Point(10, 83);
            this.labelCommonND.Name = "labelCommonND";
            this.labelCommonND.Size = new System.Drawing.Size(137, 15);
            this.labelCommonND.TabIndex = 9;
            this.labelCommonND.Text = "Закрытый показатель Б";
            // 
            // textBoxCommonND
            // 
            this.textBoxCommonND.Location = new System.Drawing.Point(164, 80);
            this.textBoxCommonND.Name = "textBoxCommonND";
            this.textBoxCommonND.ReadOnly = true;
            this.textBoxCommonND.Size = new System.Drawing.Size(155, 23);
            this.textBoxCommonND.TabIndex = 10;
            // 
            // textBoxCommonNP
            // 
            this.textBoxCommonNP.Location = new System.Drawing.Point(164, 22);
            this.textBoxCommonNP.Name = "textBoxCommonNP";
            this.textBoxCommonNP.ReadOnly = true;
            this.textBoxCommonNP.Size = new System.Drawing.Size(155, 23);
            this.textBoxCommonNP.TabIndex = 11;
            // 
            // textBoxCommonNQ
            // 
            this.textBoxCommonNQ.Location = new System.Drawing.Point(164, 51);
            this.textBoxCommonNQ.Name = "textBoxCommonNQ";
            this.textBoxCommonNQ.ReadOnly = true;
            this.textBoxCommonNQ.Size = new System.Drawing.Size(155, 23);
            this.textBoxCommonNQ.TabIndex = 12;
            // 
            // groupBoxAttackResult
            // 
            this.groupBoxAttackResult.Controls.Add(this.buttonCommonNSavePrivateB);
            this.groupBoxAttackResult.Controls.Add(this.labelCommonNP);
            this.groupBoxAttackResult.Controls.Add(this.textBoxCommonNP);
            this.groupBoxAttackResult.Controls.Add(this.textBoxCommonNQ);
            this.groupBoxAttackResult.Controls.Add(this.labelCommonNQ);
            this.groupBoxAttackResult.Controls.Add(this.labelCommonND);
            this.groupBoxAttackResult.Controls.Add(this.textBoxCommonND);
            this.groupBoxAttackResult.Location = new System.Drawing.Point(14, 164);
            this.groupBoxAttackResult.Name = "groupBoxAttackResult";
            this.groupBoxAttackResult.Size = new System.Drawing.Size(498, 121);
            this.groupBoxAttackResult.TabIndex = 13;
            this.groupBoxAttackResult.TabStop = false;
            this.groupBoxAttackResult.Text = "Результаты атаки";
            this.groupBoxAttackResult.Visible = false;
            // 
            // buttonCommonNSavePrivateB
            // 
            this.buttonCommonNSavePrivateB.Location = new System.Drawing.Point(336, 21);
            this.buttonCommonNSavePrivateB.Name = "buttonCommonNSavePrivateB";
            this.buttonCommonNSavePrivateB.Size = new System.Drawing.Size(149, 23);
            this.buttonCommonNSavePrivateB.TabIndex = 13;
            this.buttonCommonNSavePrivateB.Text = "Сохранить ключ";
            this.buttonCommonNSavePrivateB.UseVisualStyleBackColor = true;
            this.buttonCommonNSavePrivateB.Click += new System.EventHandler(this.buttonCommonNSavePrivateB_Click);
            // 
            // groupBoxCommonNKeyA
            // 
            this.groupBoxCommonNKeyA.Controls.Add(this.labelCommonNPublicA);
            this.groupBoxCommonNKeyA.Controls.Add(this.labelCommonNPrivateA);
            this.groupBoxCommonNKeyA.Controls.Add(this.buttonCommonNPublicA);
            this.groupBoxCommonNKeyA.Controls.Add(this.buttonCommonNPrivateA);
            this.groupBoxCommonNKeyA.Location = new System.Drawing.Point(14, 18);
            this.groupBoxCommonNKeyA.Name = "groupBoxCommonNKeyA";
            this.groupBoxCommonNKeyA.Size = new System.Drawing.Size(234, 82);
            this.groupBoxCommonNKeyA.TabIndex = 14;
            this.groupBoxCommonNKeyA.TabStop = false;
            this.groupBoxCommonNKeyA.Text = "Ключ А";
            // 
            // groupBoxCommonNKeyB
            // 
            this.groupBoxCommonNKeyB.Controls.Add(this.labelCommonNPublicB);
            this.groupBoxCommonNKeyB.Controls.Add(this.buttonCommonNPublicB);
            this.groupBoxCommonNKeyB.Location = new System.Drawing.Point(292, 18);
            this.groupBoxCommonNKeyB.Name = "groupBoxCommonNKeyB";
            this.groupBoxCommonNKeyB.Size = new System.Drawing.Size(220, 82);
            this.groupBoxCommonNKeyB.TabIndex = 15;
            this.groupBoxCommonNKeyB.TabStop = false;
            this.groupBoxCommonNKeyB.Text = "Ключ Б (жертва)";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // GeneralNForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 300);
            this.Controls.Add(this.groupBoxCommonNKeyB);
            this.Controls.Add(this.groupBoxCommonNKeyA);
            this.Controls.Add(this.groupBoxAttackResult);
            this.Controls.Add(this.buttonCommonNAttack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeneralNForm";
            this.Text = "Атака на ключи с общим модулем";
            this.groupBoxAttackResult.ResumeLayout(false);
            this.groupBoxAttackResult.PerformLayout();
            this.groupBoxCommonNKeyA.ResumeLayout(false);
            this.groupBoxCommonNKeyA.PerformLayout();
            this.groupBoxCommonNKeyB.ResumeLayout(false);
            this.groupBoxCommonNKeyB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label labelCommonNPublicA;
        private Label labelCommonNPrivateA;
        private Label labelCommonNPublicB;
        private Button buttonCommonNPublicA;
        private Button buttonCommonNPrivateA;
        private Button buttonCommonNPublicB;
        private Button buttonCommonNAttack;
        private Label labelCommonNP;
        private Label labelCommonNQ;
        private Label labelCommonND;
        private TextBox textBoxCommonND;
        private TextBox textBoxCommonNP;
        private TextBox textBoxCommonNQ;
        private GroupBox groupBoxAttackResult;
        private Button buttonCommonNSavePrivateB;
        private GroupBox groupBoxCommonNKeyA;
        private GroupBox groupBoxCommonNKeyB;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
    }
}