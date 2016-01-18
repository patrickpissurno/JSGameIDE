﻿namespace JSGameIDE
{
    partial class UIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIForm));
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UIEditorButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.movableBox = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.createButton = new System.Windows.Forms.Button();
            this.createLabel = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.updateLabel = new System.Windows.Forms.Label();
            this.drawButton = new System.Windows.Forms.Button();
            this.drawLabel = new System.Windows.Forms.Label();
            this.keypressedButton = new System.Windows.Forms.Button();
            this.keyPressedLabel = new System.Windows.Forms.Label();
            this.keyreleasedButton = new System.Windows.Forms.Button();
            this.keyReleasedLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.destroyButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.createButton.SuspendLayout();
            this.updateButton.SuspendLayout();
            this.drawButton.SuspendLayout();
            this.keypressedButton.SuspendLayout();
            this.keyreleasedButton.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.destroyButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(194, 272);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 22;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(101, 272);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 21;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(0, 41);
            this.label2.MaximumSize = new System.Drawing.Size(1280, 2);
            this.label2.MinimumSize = new System.Drawing.Size(0, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(472, 2);
            this.label2.TabIndex = 15;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(61, 11);
            this.nameBox.MaxLength = 20;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(108, 20);
            this.nameBox.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name:";
            // 
            // UIEditorButton
            // 
            this.UIEditorButton.Font = new System.Drawing.Font("Segoe UI Light", 12.5F);
            this.UIEditorButton.Location = new System.Drawing.Point(302, 1);
            this.UIEditorButton.Name = "UIEditorButton";
            this.UIEditorButton.Size = new System.Drawing.Size(75, 39);
            this.UIEditorButton.TabIndex = 0;
            this.UIEditorButton.Text = "Edit";
            this.UIEditorButton.UseVisualStyleBackColor = true;
            this.UIEditorButton.Click += new System.EventHandler(this.UIEditorButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(369, 198);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "General";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.movableBox);
            this.groupBox2.Location = new System.Drawing.Point(3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(115, 186);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Global Settings";
            // 
            // movableBox
            // 
            this.movableBox.AutoSize = true;
            this.movableBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movableBox.Location = new System.Drawing.Point(16, 19);
            this.movableBox.Name = "movableBox";
            this.movableBox.Size = new System.Drawing.Size(78, 21);
            this.movableBox.TabIndex = 26;
            this.movableBox.Text = "Movable";
            this.movableBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.movableBox.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.destroyButton);
            this.tabPage1.Controls.Add(this.createButton);
            this.tabPage1.Controls.Add(this.updateButton);
            this.tabPage1.Controls.Add(this.drawButton);
            this.tabPage1.Controls.Add(this.keypressedButton);
            this.tabPage1.Controls.Add(this.keyreleasedButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(369, 198);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Events";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // createButton
            // 
            this.createButton.Controls.Add(this.createLabel);
            this.createButton.Font = new System.Drawing.Font("Segoe UI Light", 21F);
            this.createButton.Location = new System.Drawing.Point(9, 6);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(65, 65);
            this.createButton.TabIndex = 16;
            this.createButton.Text = "C";
            this.createButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // createLabel
            // 
            this.createLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.createLabel.AutoSize = true;
            this.createLabel.BackColor = System.Drawing.Color.Transparent;
            this.createLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createLabel.Location = new System.Drawing.Point(14, 43);
            this.createLabel.Name = "createLabel";
            this.createLabel.Size = new System.Drawing.Size(39, 13);
            this.createLabel.TabIndex = 29;
            this.createLabel.Text = "Create";
            this.createLabel.Click += new System.EventHandler(this.createButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Controls.Add(this.updateLabel);
            this.updateButton.Font = new System.Drawing.Font("Segoe UI Light", 21F);
            this.updateButton.Location = new System.Drawing.Point(151, 6);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(65, 65);
            this.updateButton.TabIndex = 17;
            this.updateButton.Text = "U";
            this.updateButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // updateLabel
            // 
            this.updateLabel.AutoSize = true;
            this.updateLabel.BackColor = System.Drawing.Color.Transparent;
            this.updateLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateLabel.Location = new System.Drawing.Point(12, 43);
            this.updateLabel.Name = "updateLabel";
            this.updateLabel.Size = new System.Drawing.Size(41, 13);
            this.updateLabel.TabIndex = 30;
            this.updateLabel.Text = "Update";
            this.updateLabel.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // drawButton
            // 
            this.drawButton.Controls.Add(this.drawLabel);
            this.drawButton.Font = new System.Drawing.Font("Segoe UI Light", 21F);
            this.drawButton.Location = new System.Drawing.Point(80, 6);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(65, 65);
            this.drawButton.TabIndex = 18;
            this.drawButton.Text = "Dr";
            this.drawButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // drawLabel
            // 
            this.drawLabel.AutoSize = true;
            this.drawLabel.BackColor = System.Drawing.Color.Transparent;
            this.drawLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drawLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawLabel.Location = new System.Drawing.Point(16, 43);
            this.drawLabel.Name = "drawLabel";
            this.drawLabel.Size = new System.Drawing.Size(33, 13);
            this.drawLabel.TabIndex = 33;
            this.drawLabel.Text = "Draw";
            this.drawLabel.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // keypressedButton
            // 
            this.keypressedButton.Controls.Add(this.keyPressedLabel);
            this.keypressedButton.Font = new System.Drawing.Font("Segoe UI Light", 21F);
            this.keypressedButton.Location = new System.Drawing.Point(222, 6);
            this.keypressedButton.Name = "keypressedButton";
            this.keypressedButton.Size = new System.Drawing.Size(65, 65);
            this.keypressedButton.TabIndex = 19;
            this.keypressedButton.Text = "KP";
            this.keypressedButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.keypressedButton.UseVisualStyleBackColor = true;
            this.keypressedButton.Click += new System.EventHandler(this.keypressedButton_Click);
            // 
            // keyPressedLabel
            // 
            this.keyPressedLabel.AutoSize = true;
            this.keyPressedLabel.BackColor = System.Drawing.Color.Transparent;
            this.keyPressedLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keyPressedLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyPressedLabel.Location = new System.Drawing.Point(14, 43);
            this.keyPressedLabel.Name = "keyPressedLabel";
            this.keyPressedLabel.Size = new System.Drawing.Size(33, 13);
            this.keyPressedLabel.TabIndex = 34;
            this.keyPressedLabel.Text = "Key P.";
            this.keyPressedLabel.Click += new System.EventHandler(this.keypressedButton_Click);
            // 
            // keyreleasedButton
            // 
            this.keyreleasedButton.Controls.Add(this.keyReleasedLabel);
            this.keyreleasedButton.Font = new System.Drawing.Font("Segoe UI Light", 21F);
            this.keyreleasedButton.Location = new System.Drawing.Point(293, 6);
            this.keyreleasedButton.Name = "keyreleasedButton";
            this.keyreleasedButton.Size = new System.Drawing.Size(65, 65);
            this.keyreleasedButton.TabIndex = 20;
            this.keyreleasedButton.Text = "KR";
            this.keyreleasedButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.keyreleasedButton.UseVisualStyleBackColor = true;
            this.keyreleasedButton.Click += new System.EventHandler(this.keyreleasedButton_Click);
            // 
            // keyReleasedLabel
            // 
            this.keyReleasedLabel.AutoSize = true;
            this.keyReleasedLabel.BackColor = System.Drawing.Color.Transparent;
            this.keyReleasedLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keyReleasedLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyReleasedLabel.Location = new System.Drawing.Point(13, 43);
            this.keyReleasedLabel.Name = "keyReleasedLabel";
            this.keyReleasedLabel.Size = new System.Drawing.Size(35, 13);
            this.keyReleasedLabel.TabIndex = 35;
            this.keyReleasedLabel.Text = "Key R.";
            this.keyReleasedLabel.Click += new System.EventHandler(this.keyreleasedButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 46);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(377, 224);
            this.tabControl1.TabIndex = 32;
            // 
            // destroyButton
            // 
            this.destroyButton.Controls.Add(this.label3);
            this.destroyButton.Font = new System.Drawing.Font("Segoe UI Light", 21F);
            this.destroyButton.Location = new System.Drawing.Point(9, 77);
            this.destroyButton.Name = "destroyButton";
            this.destroyButton.Size = new System.Drawing.Size(65, 65);
            this.destroyButton.TabIndex = 21;
            this.destroyButton.Text = "De";
            this.destroyButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.destroyButton.UseVisualStyleBackColor = true;
            this.destroyButton.Click += new System.EventHandler(this.destroyButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Destroy";
            this.label3.Click += new System.EventHandler(this.destroyButton_Click);
            // 
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 299);
            this.Controls.Add(this.UIEditorButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UI properties";
            this.Load += new System.EventHandler(this.UIForm_Load);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.createButton.ResumeLayout(false);
            this.createButton.PerformLayout();
            this.updateButton.ResumeLayout(false);
            this.updateButton.PerformLayout();
            this.drawButton.ResumeLayout(false);
            this.drawButton.PerformLayout();
            this.keypressedButton.ResumeLayout(false);
            this.keypressedButton.PerformLayout();
            this.keyreleasedButton.ResumeLayout(false);
            this.keyreleasedButton.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.destroyButton.ResumeLayout(false);
            this.destroyButton.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UIEditorButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label keyReleasedLabel;
        private System.Windows.Forms.Button keyreleasedButton;
        private System.Windows.Forms.Label keyPressedLabel;
        private System.Windows.Forms.Button keypressedButton;
        private System.Windows.Forms.Label drawLabel;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Label updateLabel;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label createLabel;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox movableBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button destroyButton;
        private System.Windows.Forms.Label label3;
    }
}