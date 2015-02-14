namespace JSGameIDE
{
    partial class ObjectForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.keyreleasedButton = new System.Windows.Forms.Button();
            this.keypressedButton = new System.Windows.Forms.Button();
            this.drawButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.destroyButton = new System.Windows.Forms.Button();
            this.spriteBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.autoDrawBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(257, 171);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 22;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(138, 171);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 21;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // keyreleasedButton
            // 
            this.keyreleasedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyreleasedButton.Location = new System.Drawing.Point(188, 106);
            this.keyreleasedButton.Name = "keyreleasedButton";
            this.keyreleasedButton.Size = new System.Drawing.Size(93, 38);
            this.keyreleasedButton.TabIndex = 20;
            this.keyreleasedButton.Text = "Key Released";
            this.keyreleasedButton.UseVisualStyleBackColor = true;
            this.keyreleasedButton.Click += new System.EventHandler(this.keyreleasedButton_Click);
            // 
            // keypressedButton
            // 
            this.keypressedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keypressedButton.Location = new System.Drawing.Point(12, 106);
            this.keypressedButton.Name = "keypressedButton";
            this.keypressedButton.Size = new System.Drawing.Size(93, 38);
            this.keypressedButton.TabIndex = 19;
            this.keypressedButton.Text = "Key Pressed";
            this.keypressedButton.UseVisualStyleBackColor = true;
            this.keypressedButton.Click += new System.EventHandler(this.keypressedButton_Click);
            // 
            // drawButton
            // 
            this.drawButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawButton.Location = new System.Drawing.Point(365, 57);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(93, 38);
            this.drawButton.TabIndex = 18;
            this.drawButton.Text = "Draw";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.Location = new System.Drawing.Point(188, 57);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(93, 38);
            this.updateButton.TabIndex = 17;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // createButton
            // 
            this.createButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.Location = new System.Drawing.Point(12, 57);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(93, 38);
            this.createButton.TabIndex = 16;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(1, 44);
            this.label2.MaximumSize = new System.Drawing.Size(1280, 2);
            this.label2.MinimumSize = new System.Drawing.Size(0, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(471, 2);
            this.label2.TabIndex = 15;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(61, 13);
            this.nameBox.MaxLength = 20;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(108, 20);
            this.nameBox.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name:";
            // 
            // destroyButton
            // 
            this.destroyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destroyButton.Location = new System.Drawing.Point(365, 106);
            this.destroyButton.Name = "destroyButton";
            this.destroyButton.Size = new System.Drawing.Size(93, 38);
            this.destroyButton.TabIndex = 23;
            this.destroyButton.Text = "Destroy";
            this.destroyButton.UseVisualStyleBackColor = true;
            this.destroyButton.Click += new System.EventHandler(this.destroyButton_Click);
            // 
            // spriteBox
            // 
            this.spriteBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spriteBox.Location = new System.Drawing.Point(230, 12);
            this.spriteBox.Name = "spriteBox";
            this.spriteBox.Size = new System.Drawing.Size(121, 21);
            this.spriteBox.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(180, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "Sprite:";
            // 
            // autoDrawBox
            // 
            this.autoDrawBox.AutoSize = true;
            this.autoDrawBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoDrawBox.Location = new System.Drawing.Point(369, 13);
            this.autoDrawBox.Name = "autoDrawBox";
            this.autoDrawBox.Size = new System.Drawing.Size(97, 22);
            this.autoDrawBox.TabIndex = 26;
            this.autoDrawBox.Text = "Auto-Draw";
            this.autoDrawBox.UseVisualStyleBackColor = true;
            // 
            // ObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 201);
            this.Controls.Add(this.autoDrawBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.spriteBox);
            this.Controls.Add(this.destroyButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.keyreleasedButton);
            this.Controls.Add(this.keypressedButton);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ObjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Object properties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button keyreleasedButton;
        private System.Windows.Forms.Button keypressedButton;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button destroyButton;
        private System.Windows.Forms.ComboBox spriteBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox autoDrawBox;

    }
}