namespace JSGameIDE
{
    partial class ProjectOptionsForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.projectNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.viewHeightBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.viewWidthBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.authorBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.copyrightBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.iconBox = new System.Windows.Forms.PictureBox();
            this.selectIcon = new System.Windows.Forms.Button();
            this.openIconDialog = new System.Windows.Forms.OpenFileDialog();
            this.windowStyleBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(274, 301);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // projectNameBox
            // 
            this.projectNameBox.Location = new System.Drawing.Point(89, 18);
            this.projectNameBox.MaxLength = 20;
            this.projectNameBox.Name = "projectNameBox";
            this.projectNameBox.Size = new System.Drawing.Size(100, 20);
            this.projectNameBox.TabIndex = 1;
            this.projectNameBox.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Project Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Map Width:";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(329, 6);
            this.widthTextBox.MaxLength = 4;
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(50, 20);
            this.widthTextBox.TabIndex = 4;
            this.widthTextBox.Tag = "";
            this.widthTextBox.TextChanged += new System.EventHandler(this.Check_If_Int_On_TextChanged);
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(468, 6);
            this.heightTextBox.MaxLength = 4;
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(50, 20);
            this.heightTextBox.TabIndex = 6;
            this.heightTextBox.Tag = "";
            this.heightTextBox.TextChanged += new System.EventHandler(this.Check_If_Int_On_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(395, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Map Height:";
            // 
            // viewHeightBox
            // 
            this.viewHeightBox.Location = new System.Drawing.Point(468, 28);
            this.viewHeightBox.MaxLength = 4;
            this.viewHeightBox.Name = "viewHeightBox";
            this.viewHeightBox.Size = new System.Drawing.Size(50, 20);
            this.viewHeightBox.TabIndex = 10;
            this.viewHeightBox.Tag = "";
            this.viewHeightBox.TextChanged += new System.EventHandler(this.Check_If_Int_On_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(394, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "View Height:";
            // 
            // viewWidthBox
            // 
            this.viewWidthBox.Location = new System.Drawing.Point(329, 28);
            this.viewWidthBox.MaxLength = 4;
            this.viewWidthBox.Name = "viewWidthBox";
            this.viewWidthBox.Size = new System.Drawing.Size(50, 20);
            this.viewWidthBox.TabIndex = 8;
            this.viewWidthBox.Tag = "";
            this.viewWidthBox.TextChanged += new System.EventHandler(this.Check_If_Int_On_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "View Width:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Author:";
            // 
            // authorBox
            // 
            this.authorBox.Location = new System.Drawing.Point(15, 82);
            this.authorBox.MaxLength = 40;
            this.authorBox.Name = "authorBox";
            this.authorBox.Size = new System.Drawing.Size(174, 20);
            this.authorBox.TabIndex = 13;
            this.authorBox.Tag = "";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(0, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(620, 2);
            this.label8.TabIndex = 15;
            // 
            // copyrightBox
            // 
            this.copyrightBox.Location = new System.Drawing.Point(209, 82);
            this.copyrightBox.MaxLength = 40;
            this.copyrightBox.Name = "copyrightBox";
            this.copyrightBox.Size = new System.Drawing.Size(174, 20);
            this.copyrightBox.TabIndex = 17;
            this.copyrightBox.Tag = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(208, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Copyright:";
            // 
            // iconBox
            // 
            this.iconBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iconBox.Location = new System.Drawing.Point(537, 66);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(42, 42);
            this.iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconBox.TabIndex = 18;
            this.iconBox.TabStop = false;
            // 
            // selectIcon
            // 
            this.selectIcon.Location = new System.Drawing.Point(582, 66);
            this.selectIcon.Name = "selectIcon";
            this.selectIcon.Size = new System.Drawing.Size(27, 42);
            this.selectIcon.TabIndex = 21;
            this.selectIcon.Text = "...";
            this.selectIcon.UseVisualStyleBackColor = true;
            this.selectIcon.Click += new System.EventHandler(this.selectIcon_Click);
            // 
            // openIconDialog
            // 
            this.openIconDialog.DefaultExt = "ico";
            this.openIconDialog.Filter = "Icon files|*.ico";
            this.openIconDialog.Title = "Select an icon";
            // 
            // windowStyleBox
            // 
            this.windowStyleBox.FormattingEnabled = true;
            this.windowStyleBox.Items.AddRange(new object[] {
            "Auto",
            "Fixed",
            "Fullscreen"});
            this.windowStyleBox.Location = new System.Drawing.Point(535, 26);
            this.windowStyleBox.Name = "windowStyleBox";
            this.windowStyleBox.Size = new System.Drawing.Size(73, 21);
            this.windowStyleBox.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(534, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Window Style:";
            // 
            // ProjectOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 336);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.windowStyleBox);
            this.Controls.Add(this.selectIcon);
            this.Controls.Add(this.iconBox);
            this.Controls.Add(this.copyrightBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.authorBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.viewHeightBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.viewWidthBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.projectNameBox);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Settings";
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox projectNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox viewHeightBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox viewWidthBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox authorBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox copyrightBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox iconBox;
        private System.Windows.Forms.Button selectIcon;
        private System.Windows.Forms.OpenFileDialog openIconDialog;
        private System.Windows.Forms.ComboBox windowStyleBox;
        private System.Windows.Forms.Label label9;
    }
}