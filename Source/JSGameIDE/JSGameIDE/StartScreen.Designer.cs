namespace JSGameIDE
{
    partial class StartScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreen));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.recentTitle1 = new System.Windows.Forms.Label();
            this.recentPath1 = new System.Windows.Forms.Label();
            this.recentPanel1 = new System.Windows.Forms.Panel();
            this.recentPanel2 = new System.Windows.Forms.Panel();
            this.recentTitle2 = new System.Windows.Forms.Label();
            this.recentPath2 = new System.Windows.Forms.Label();
            this.recentPanel3 = new System.Windows.Forms.Panel();
            this.recentTitle3 = new System.Windows.Forms.Label();
            this.recentPath3 = new System.Windows.Forms.Label();
            this.recentPanel4 = new System.Windows.Forms.Panel();
            this.recentTitle4 = new System.Windows.Forms.Label();
            this.recentPath4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.recentPanel1.SuspendLayout();
            this.recentPanel2.SuspendLayout();
            this.recentPanel3.SuspendLayout();
            this.recentPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recently opened";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(-2, 58);
            this.label2.MaximumSize = new System.Drawing.Size(1280, 2);
            this.label2.MinimumSize = new System.Drawing.Size(0, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 2);
            this.label2.TabIndex = 5;
            // 
            // openButton
            // 
            this.openButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openButton.Location = new System.Drawing.Point(416, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(60, 35);
            this.openButton.TabIndex = 6;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(352, 12);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(60, 35);
            this.newButton.TabIndex = 7;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "JSGameIDE Project Files|*.JSGP";
            this.openFileDialog1.Title = "Please select the project to be opened";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.openButton);
            this.panel1.Controls.Add(this.newButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 57);
            this.panel1.TabIndex = 8;
            // 
            // recentTitle1
            // 
            this.recentTitle1.AutoSize = true;
            this.recentTitle1.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentTitle1.Location = new System.Drawing.Point(9, 9);
            this.recentTitle1.Name = "recentTitle1";
            this.recentTitle1.Size = new System.Drawing.Size(133, 30);
            this.recentTitle1.TabIndex = 8;
            this.recentTitle1.Tag = "1";
            this.recentTitle1.Text = "Lorem ipsum";
            this.recentTitle1.Click += new System.EventHandler(this.recentPanel_Click);
            this.recentTitle1.MouseEnter += new System.EventHandler(this.recentPanel_MouseEnter);
            this.recentTitle1.MouseLeave += new System.EventHandler(this.recentPanel_MouseLeave);
            // 
            // recentPath1
            // 
            this.recentPath1.AutoSize = true;
            this.recentPath1.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentPath1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.recentPath1.Location = new System.Drawing.Point(12, 39);
            this.recentPath1.Name = "recentPath1";
            this.recentPath1.Size = new System.Drawing.Size(158, 15);
            this.recentPath1.TabIndex = 9;
            this.recentPath1.Tag = "1";
            this.recentPath1.Text = "C:\\Lorem\\Ipsum\\project.JSGP";
            this.recentPath1.Click += new System.EventHandler(this.recentPanel_Click);
            this.recentPath1.MouseEnter += new System.EventHandler(this.recentPanel_MouseEnter);
            this.recentPath1.MouseLeave += new System.EventHandler(this.recentPanel_MouseLeave);
            // 
            // recentPanel1
            // 
            this.recentPanel1.Controls.Add(this.recentTitle1);
            this.recentPanel1.Controls.Add(this.recentPath1);
            this.recentPanel1.Location = new System.Drawing.Point(-2, 59);
            this.recentPanel1.Name = "recentPanel1";
            this.recentPanel1.Size = new System.Drawing.Size(488, 65);
            this.recentPanel1.TabIndex = 10;
            this.recentPanel1.Tag = "1";
            this.recentPanel1.Click += new System.EventHandler(this.recentPanel_Click);
            this.recentPanel1.MouseEnter += new System.EventHandler(this.recentPanel_MouseEnter);
            this.recentPanel1.MouseLeave += new System.EventHandler(this.recentPanel_MouseLeave);
            // 
            // recentPanel2
            // 
            this.recentPanel2.Controls.Add(this.recentTitle2);
            this.recentPanel2.Controls.Add(this.recentPath2);
            this.recentPanel2.Location = new System.Drawing.Point(-2, 125);
            this.recentPanel2.Name = "recentPanel2";
            this.recentPanel2.Size = new System.Drawing.Size(488, 65);
            this.recentPanel2.TabIndex = 11;
            this.recentPanel2.Tag = "2";
            this.recentPanel2.Click += new System.EventHandler(this.recentPanel_Click);
            this.recentPanel2.MouseEnter += new System.EventHandler(this.recentPanel_MouseEnter);
            this.recentPanel2.MouseLeave += new System.EventHandler(this.recentPanel_MouseLeave);
            // 
            // recentTitle2
            // 
            this.recentTitle2.AutoSize = true;
            this.recentTitle2.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentTitle2.Location = new System.Drawing.Point(9, 9);
            this.recentTitle2.Name = "recentTitle2";
            this.recentTitle2.Size = new System.Drawing.Size(133, 30);
            this.recentTitle2.TabIndex = 8;
            this.recentTitle2.Tag = "2";
            this.recentTitle2.Text = "Lorem ipsum";
            this.recentTitle2.Click += new System.EventHandler(this.recentPanel_Click);
            this.recentTitle2.MouseEnter += new System.EventHandler(this.recentPanel_MouseEnter);
            this.recentTitle2.MouseLeave += new System.EventHandler(this.recentPanel_MouseLeave);
            // 
            // recentPath2
            // 
            this.recentPath2.AutoSize = true;
            this.recentPath2.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentPath2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.recentPath2.Location = new System.Drawing.Point(12, 39);
            this.recentPath2.Name = "recentPath2";
            this.recentPath2.Size = new System.Drawing.Size(158, 15);
            this.recentPath2.TabIndex = 9;
            this.recentPath2.Tag = "2";
            this.recentPath2.Text = "C:\\Lorem\\Ipsum\\project.JSGP";
            this.recentPath2.Click += new System.EventHandler(this.recentPanel_Click);
            this.recentPath2.MouseEnter += new System.EventHandler(this.recentPanel_MouseEnter);
            this.recentPath2.MouseLeave += new System.EventHandler(this.recentPanel_MouseLeave);
            // 
            // recentPanel3
            // 
            this.recentPanel3.Controls.Add(this.recentTitle3);
            this.recentPanel3.Controls.Add(this.recentPath3);
            this.recentPanel3.Location = new System.Drawing.Point(-2, 191);
            this.recentPanel3.Name = "recentPanel3";
            this.recentPanel3.Size = new System.Drawing.Size(488, 65);
            this.recentPanel3.TabIndex = 12;
            this.recentPanel3.Tag = "3";
            this.recentPanel3.Click += new System.EventHandler(this.recentPanel_Click);
            this.recentPanel3.MouseEnter += new System.EventHandler(this.recentPanel_MouseEnter);
            this.recentPanel3.MouseLeave += new System.EventHandler(this.recentPanel_MouseLeave);
            // 
            // recentTitle3
            // 
            this.recentTitle3.AutoSize = true;
            this.recentTitle3.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentTitle3.Location = new System.Drawing.Point(9, 9);
            this.recentTitle3.Name = "recentTitle3";
            this.recentTitle3.Size = new System.Drawing.Size(133, 30);
            this.recentTitle3.TabIndex = 8;
            this.recentTitle3.Tag = "3";
            this.recentTitle3.Text = "Lorem ipsum";
            this.recentTitle3.Click += new System.EventHandler(this.recentPanel_Click);
            this.recentTitle3.MouseEnter += new System.EventHandler(this.recentPanel_MouseEnter);
            this.recentTitle3.MouseLeave += new System.EventHandler(this.recentPanel_MouseLeave);
            // 
            // recentPath3
            // 
            this.recentPath3.AutoSize = true;
            this.recentPath3.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentPath3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.recentPath3.Location = new System.Drawing.Point(12, 39);
            this.recentPath3.Name = "recentPath3";
            this.recentPath3.Size = new System.Drawing.Size(158, 15);
            this.recentPath3.TabIndex = 9;
            this.recentPath3.Tag = "3";
            this.recentPath3.Text = "C:\\Lorem\\Ipsum\\project.JSGP";
            this.recentPath3.Click += new System.EventHandler(this.recentPanel_Click);
            this.recentPath3.MouseEnter += new System.EventHandler(this.recentPanel_MouseEnter);
            this.recentPath3.MouseLeave += new System.EventHandler(this.recentPanel_MouseLeave);
            // 
            // recentPanel4
            // 
            this.recentPanel4.Controls.Add(this.recentTitle4);
            this.recentPanel4.Controls.Add(this.recentPath4);
            this.recentPanel4.Location = new System.Drawing.Point(-2, 257);
            this.recentPanel4.Name = "recentPanel4";
            this.recentPanel4.Size = new System.Drawing.Size(488, 65);
            this.recentPanel4.TabIndex = 13;
            this.recentPanel4.Tag = "4";
            this.recentPanel4.Click += new System.EventHandler(this.recentPanel_Click);
            this.recentPanel4.MouseEnter += new System.EventHandler(this.recentPanel_MouseEnter);
            this.recentPanel4.MouseLeave += new System.EventHandler(this.recentPanel_MouseLeave);
            // 
            // recentTitle4
            // 
            this.recentTitle4.AutoSize = true;
            this.recentTitle4.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentTitle4.Location = new System.Drawing.Point(9, 9);
            this.recentTitle4.Name = "recentTitle4";
            this.recentTitle4.Size = new System.Drawing.Size(133, 30);
            this.recentTitle4.TabIndex = 8;
            this.recentTitle4.Tag = "4";
            this.recentTitle4.Text = "Lorem ipsum";
            this.recentTitle4.Click += new System.EventHandler(this.recentPanel_Click);
            this.recentTitle4.MouseEnter += new System.EventHandler(this.recentPanel_MouseEnter);
            this.recentTitle4.MouseLeave += new System.EventHandler(this.recentPanel_MouseLeave);
            // 
            // recentPath4
            // 
            this.recentPath4.AutoSize = true;
            this.recentPath4.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentPath4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.recentPath4.Location = new System.Drawing.Point(12, 39);
            this.recentPath4.Name = "recentPath4";
            this.recentPath4.Size = new System.Drawing.Size(158, 15);
            this.recentPath4.TabIndex = 9;
            this.recentPath4.Tag = "4";
            this.recentPath4.Text = "C:\\Lorem\\Ipsum\\project.JSGP";
            this.recentPath4.Click += new System.EventHandler(this.recentPanel_Click);
            this.recentPath4.MouseEnter += new System.EventHandler(this.recentPanel_MouseEnter);
            this.recentPath4.MouseLeave += new System.EventHandler(this.recentPanel_MouseLeave);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 321);
            this.Controls.Add(this.recentPanel4);
            this.Controls.Add(this.recentPanel3);
            this.Controls.Add(this.recentPanel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.recentPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JSGameIDE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartScreen_FormClosing);
            this.Load += new System.EventHandler(this.StartScreen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.recentPanel1.ResumeLayout(false);
            this.recentPanel1.PerformLayout();
            this.recentPanel2.ResumeLayout(false);
            this.recentPanel2.PerformLayout();
            this.recentPanel3.ResumeLayout(false);
            this.recentPanel3.PerformLayout();
            this.recentPanel4.ResumeLayout(false);
            this.recentPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label recentTitle1;
        private System.Windows.Forms.Label recentPath1;
        private System.Windows.Forms.Panel recentPanel1;
        private System.Windows.Forms.Panel recentPanel2;
        private System.Windows.Forms.Label recentTitle2;
        private System.Windows.Forms.Label recentPath2;
        private System.Windows.Forms.Panel recentPanel3;
        private System.Windows.Forms.Label recentTitle3;
        private System.Windows.Forms.Label recentPath3;
        private System.Windows.Forms.Panel recentPanel4;
        private System.Windows.Forms.Label recentTitle4;
        private System.Windows.Forms.Label recentPath4;
    }
}