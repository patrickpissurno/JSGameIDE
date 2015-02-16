namespace JSGameIDE
{
    partial class SpriteForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.framesLabel = new System.Windows.Forms.Label();
            this.nextFrameButton = new System.Windows.Forms.Button();
            this.previousFrameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(71, 10);
            this.nameBox.MaxLength = 20;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 20);
            this.nameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "File:";
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(371, 42);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(25, 23);
            this.openFileButton.TabIndex = 3;
            this.openFileButton.Text = "...";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(127, 226);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(217, 226);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "JPEG|*.jpg|PNG|*.png|Todos os arquivos|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Please select the sprite file to be loaded";
            // 
            // pathBox
            // 
            this.pathBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pathBox.Location = new System.Drawing.Point(63, 43);
            this.pathBox.Name = "pathBox";
            this.pathBox.ReadOnly = true;
            this.pathBox.Size = new System.Drawing.Size(302, 20);
            this.pathBox.TabIndex = 6;
            // 
            // previewBox
            // 
            this.previewBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewBox.Location = new System.Drawing.Point(135, 69);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(151, 151);
            this.previewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.previewBox.TabIndex = 7;
            this.previewBox.TabStop = false;
            // 
            // framesLabel
            // 
            this.framesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.framesLabel.AutoSize = true;
            this.framesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.framesLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.framesLabel.Location = new System.Drawing.Point(337, 9);
            this.framesLabel.Name = "framesLabel";
            this.framesLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.framesLabel.Size = new System.Drawing.Size(75, 18);
            this.framesLabel.TabIndex = 8;
            this.framesLabel.Text = "Frames: 0";
            this.framesLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nextFrameButton
            // 
            this.nextFrameButton.Location = new System.Drawing.Point(292, 131);
            this.nextFrameButton.Name = "nextFrameButton";
            this.nextFrameButton.Size = new System.Drawing.Size(28, 28);
            this.nextFrameButton.TabIndex = 9;
            this.nextFrameButton.Text = ">>";
            this.nextFrameButton.UseVisualStyleBackColor = true;
            this.nextFrameButton.Click += new System.EventHandler(this.nextFrameButton_Click);
            // 
            // previousFrameButton
            // 
            this.previousFrameButton.Location = new System.Drawing.Point(101, 131);
            this.previousFrameButton.Name = "previousFrameButton";
            this.previousFrameButton.Size = new System.Drawing.Size(28, 28);
            this.previousFrameButton.TabIndex = 10;
            this.previousFrameButton.Text = "<<";
            this.previousFrameButton.UseVisualStyleBackColor = true;
            this.previousFrameButton.Click += new System.EventHandler(this.previousFrameButton_Click);
            // 
            // SpriteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 261);
            this.Controls.Add(this.previousFrameButton);
            this.Controls.Add(this.nextFrameButton);
            this.Controls.Add(this.framesLabel);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpriteForm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sprite properties";
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.Label framesLabel;
        private System.Windows.Forms.Button nextFrameButton;
        private System.Windows.Forms.Button previousFrameButton;
    }
}