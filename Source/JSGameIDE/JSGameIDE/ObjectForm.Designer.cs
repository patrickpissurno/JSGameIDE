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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectForm));
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.keyreleasedButton = new System.Windows.Forms.Button();
            this.keyReleasedLabel = new System.Windows.Forms.Label();
            this.keypressedButton = new System.Windows.Forms.Button();
            this.keyPressedLabel = new System.Windows.Forms.Label();
            this.drawButton = new System.Windows.Forms.Button();
            this.drawLabel = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.updateLabel = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.createLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.destroyButton = new System.Windows.Forms.Button();
            this.destroyLabel = new System.Windows.Forms.Label();
            this.spriteBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.autoDrawBox = new System.Windows.Forms.CheckBox();
            this.mousereleasedButton = new System.Windows.Forms.Button();
            this.mouseReleasedLabel = new System.Windows.Forms.Label();
            this.mousepressedButton = new System.Windows.Forms.Button();
            this.mousePressedLabel = new System.Windows.Forms.Label();
            this.usePhysicsCheckbox = new System.Windows.Forms.CheckBox();
            this.bodyTypeBox = new System.Windows.Forms.ComboBox();
            this.lockRotationCheckbox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.restitutionBox = new System.Windows.Forms.NumericUpDown();
            this.frictionBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.densityBox1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.colliderTypeBox = new System.Windows.Forms.ComboBox();
            this.keyreleasedButton.SuspendLayout();
            this.keypressedButton.SuspendLayout();
            this.drawButton.SuspendLayout();
            this.updateButton.SuspendLayout();
            this.createButton.SuspendLayout();
            this.destroyButton.SuspendLayout();
            this.mousereleasedButton.SuspendLayout();
            this.mousepressedButton.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.restitutionBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frictionBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.densityBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(243, 275);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 22;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(144, 275);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 21;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // keyreleasedButton
            // 
            this.keyreleasedButton.Controls.Add(this.keyReleasedLabel);
            this.keyreleasedButton.Font = new System.Drawing.Font("Segoe UI Light", 21F);
            this.keyreleasedButton.Location = new System.Drawing.Point(374, 6);
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
            // keypressedButton
            // 
            this.keypressedButton.Controls.Add(this.keyPressedLabel);
            this.keypressedButton.Font = new System.Drawing.Font("Segoe UI Light", 21F);
            this.keypressedButton.Location = new System.Drawing.Point(303, 6);
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
            // drawButton
            // 
            this.drawButton.Controls.Add(this.drawLabel);
            this.drawButton.Font = new System.Drawing.Font("Segoe UI Light", 21F);
            this.drawButton.Location = new System.Drawing.Point(90, 6);
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
            // updateButton
            // 
            this.updateButton.Controls.Add(this.updateLabel);
            this.updateButton.Font = new System.Drawing.Font("Segoe UI Light", 21F);
            this.updateButton.Location = new System.Drawing.Point(161, 6);
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
            // createButton
            // 
            this.createButton.Controls.Add(this.createLabel);
            this.createButton.Font = new System.Drawing.Font("Segoe UI Light", 21F);
            this.createButton.Location = new System.Drawing.Point(19, 6);
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
            // destroyButton
            // 
            this.destroyButton.Controls.Add(this.destroyLabel);
            this.destroyButton.Font = new System.Drawing.Font("Segoe UI Light", 21F);
            this.destroyButton.Location = new System.Drawing.Point(232, 6);
            this.destroyButton.Name = "destroyButton";
            this.destroyButton.Size = new System.Drawing.Size(65, 65);
            this.destroyButton.TabIndex = 23;
            this.destroyButton.Text = "De";
            this.destroyButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.destroyButton.UseVisualStyleBackColor = true;
            this.destroyButton.Click += new System.EventHandler(this.destroyButton_Click);
            // 
            // destroyLabel
            // 
            this.destroyLabel.AutoSize = true;
            this.destroyLabel.BackColor = System.Drawing.Color.Transparent;
            this.destroyLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.destroyLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destroyLabel.Location = new System.Drawing.Point(11, 43);
            this.destroyLabel.Name = "destroyLabel";
            this.destroyLabel.Size = new System.Drawing.Size(43, 13);
            this.destroyLabel.TabIndex = 36;
            this.destroyLabel.Text = "Destroy";
            this.destroyLabel.Click += new System.EventHandler(this.destroyButton_Click);
            // 
            // spriteBox
            // 
            this.spriteBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spriteBox.Location = new System.Drawing.Point(339, 11);
            this.spriteBox.Name = "spriteBox";
            this.spriteBox.Size = new System.Drawing.Size(121, 21);
            this.spriteBox.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(288, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Sprite:";
            // 
            // autoDrawBox
            // 
            this.autoDrawBox.AutoSize = true;
            this.autoDrawBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoDrawBox.Location = new System.Drawing.Point(28, 19);
            this.autoDrawBox.Name = "autoDrawBox";
            this.autoDrawBox.Size = new System.Drawing.Size(81, 17);
            this.autoDrawBox.TabIndex = 26;
            this.autoDrawBox.Text = "Auto-draw";
            this.autoDrawBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.autoDrawBox.UseVisualStyleBackColor = true;
            // 
            // mousereleasedButton
            // 
            this.mousereleasedButton.Controls.Add(this.mouseReleasedLabel);
            this.mousereleasedButton.Font = new System.Drawing.Font("Segoe UI Light", 21F);
            this.mousereleasedButton.Location = new System.Drawing.Point(90, 77);
            this.mousereleasedButton.Name = "mousereleasedButton";
            this.mousereleasedButton.Size = new System.Drawing.Size(65, 65);
            this.mousereleasedButton.TabIndex = 28;
            this.mousereleasedButton.Text = "MR";
            this.mousereleasedButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.mousereleasedButton.UseVisualStyleBackColor = true;
            this.mousereleasedButton.Click += new System.EventHandler(this.mousereleasedButton_Click);
            // 
            // mouseReleasedLabel
            // 
            this.mouseReleasedLabel.AutoSize = true;
            this.mouseReleasedLabel.BackColor = System.Drawing.Color.Transparent;
            this.mouseReleasedLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mouseReleasedLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mouseReleasedLabel.Location = new System.Drawing.Point(7, 43);
            this.mouseReleasedLabel.Name = "mouseReleasedLabel";
            this.mouseReleasedLabel.Size = new System.Drawing.Size(50, 13);
            this.mouseReleasedLabel.TabIndex = 31;
            this.mouseReleasedLabel.Text = "Mouse R.";
            this.mouseReleasedLabel.Click += new System.EventHandler(this.mousereleasedButton_Click);
            // 
            // mousepressedButton
            // 
            this.mousepressedButton.Controls.Add(this.mousePressedLabel);
            this.mousepressedButton.Font = new System.Drawing.Font("Segoe UI Light", 21F);
            this.mousepressedButton.Location = new System.Drawing.Point(19, 77);
            this.mousepressedButton.Name = "mousepressedButton";
            this.mousepressedButton.Size = new System.Drawing.Size(65, 65);
            this.mousepressedButton.TabIndex = 27;
            this.mousepressedButton.Text = "MP";
            this.mousepressedButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.mousepressedButton.UseVisualStyleBackColor = true;
            this.mousepressedButton.Click += new System.EventHandler(this.mousepressedButton_Click);
            // 
            // mousePressedLabel
            // 
            this.mousePressedLabel.AutoSize = true;
            this.mousePressedLabel.BackColor = System.Drawing.Color.Transparent;
            this.mousePressedLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mousePressedLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mousePressedLabel.Location = new System.Drawing.Point(8, 43);
            this.mousePressedLabel.Name = "mousePressedLabel";
            this.mousePressedLabel.Size = new System.Drawing.Size(48, 13);
            this.mousePressedLabel.TabIndex = 32;
            this.mousePressedLabel.Text = "Mouse P.";
            this.mousePressedLabel.Click += new System.EventHandler(this.mousepressedButton_Click);
            // 
            // usePhysicsCheckbox
            // 
            this.usePhysicsCheckbox.AutoSize = true;
            this.usePhysicsCheckbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usePhysicsCheckbox.Location = new System.Drawing.Point(380, 6);
            this.usePhysicsCheckbox.Name = "usePhysicsCheckbox";
            this.usePhysicsCheckbox.Size = new System.Drawing.Size(82, 24);
            this.usePhysicsCheckbox.TabIndex = 29;
            this.usePhysicsCheckbox.Text = "Enabled";
            this.usePhysicsCheckbox.UseVisualStyleBackColor = true;
            // 
            // bodyTypeBox
            // 
            this.bodyTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bodyTypeBox.Location = new System.Drawing.Point(92, 20);
            this.bodyTypeBox.Name = "bodyTypeBox";
            this.bodyTypeBox.Size = new System.Drawing.Size(121, 21);
            this.bodyTypeBox.TabIndex = 30;
            // 
            // lockRotationCheckbox
            // 
            this.lockRotationCheckbox.AutoSize = true;
            this.lockRotationCheckbox.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lockRotationCheckbox.Location = new System.Drawing.Point(12, 21);
            this.lockRotationCheckbox.Name = "lockRotationCheckbox";
            this.lockRotationCheckbox.Size = new System.Drawing.Size(107, 17);
            this.lockRotationCheckbox.TabIndex = 31;
            this.lockRotationCheckbox.Text = "Freeze Rotation";
            this.lockRotationCheckbox.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 46);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(471, 224);
            this.tabControl1.TabIndex = 32;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.createButton);
            this.tabPage1.Controls.Add(this.updateButton);
            this.tabPage1.Controls.Add(this.drawButton);
            this.tabPage1.Controls.Add(this.keypressedButton);
            this.tabPage1.Controls.Add(this.mousereleasedButton);
            this.tabPage1.Controls.Add(this.keyreleasedButton);
            this.tabPage1.Controls.Add(this.mousepressedButton);
            this.tabPage1.Controls.Add(this.destroyButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(463, 198);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Events";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(463, 198);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "General";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.autoDrawBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 186);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Drawing settings";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.usePhysicsCheckbox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(463, 198);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Physics";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.colliderTypeBox);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.densityBox1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.bodyTypeBox);
            this.groupBox3.Location = new System.Drawing.Point(144, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 186);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Body Settings";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.restitutionBox);
            this.groupBox4.Controls.Add(this.frictionBox);
            this.groupBox4.Location = new System.Drawing.Point(6, 119);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(213, 61);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Physical Properties";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Friction";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(105, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Restitution";
            // 
            // restitutionBox
            // 
            this.restitutionBox.DecimalPlaces = 2;
            this.restitutionBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.restitutionBox.Location = new System.Drawing.Point(116, 32);
            this.restitutionBox.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.restitutionBox.Name = "restitutionBox";
            this.restitutionBox.Size = new System.Drawing.Size(43, 20);
            this.restitutionBox.TabIndex = 34;
            // 
            // frictionBox
            // 
            this.frictionBox.DecimalPlaces = 2;
            this.frictionBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.frictionBox.Location = new System.Drawing.Point(43, 32);
            this.frictionBox.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frictionBox.Name = "frictionBox";
            this.frictionBox.Size = new System.Drawing.Size(43, 20);
            this.frictionBox.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Density:";
            // 
            // densityBox1
            // 
            this.densityBox1.DecimalPlaces = 1;
            this.densityBox1.Location = new System.Drawing.Point(92, 74);
            this.densityBox1.Name = "densityBox1";
            this.densityBox1.Size = new System.Drawing.Size(121, 20);
            this.densityBox1.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Body type:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lockRotationCheckbox);
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 186);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transform settings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Collider type:";
            // 
            // colliderTypeBox
            // 
            this.colliderTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colliderTypeBox.Location = new System.Drawing.Point(92, 47);
            this.colliderTypeBox.Name = "colliderTypeBox";
            this.colliderTypeBox.Size = new System.Drawing.Size(121, 21);
            this.colliderTypeBox.TabIndex = 39;
            // 
            // ObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 307);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.spriteBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ObjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Object properties";
            this.Load += new System.EventHandler(this.ObjectForm_Load);
            this.keyreleasedButton.ResumeLayout(false);
            this.keyreleasedButton.PerformLayout();
            this.keypressedButton.ResumeLayout(false);
            this.keypressedButton.PerformLayout();
            this.drawButton.ResumeLayout(false);
            this.drawButton.PerformLayout();
            this.updateButton.ResumeLayout(false);
            this.updateButton.PerformLayout();
            this.createButton.ResumeLayout(false);
            this.createButton.PerformLayout();
            this.destroyButton.ResumeLayout(false);
            this.destroyButton.PerformLayout();
            this.mousereleasedButton.ResumeLayout(false);
            this.mousereleasedButton.PerformLayout();
            this.mousepressedButton.ResumeLayout(false);
            this.mousepressedButton.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.restitutionBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frictionBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.densityBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button mousereleasedButton;
        private System.Windows.Forms.Button mousepressedButton;
        private System.Windows.Forms.CheckBox usePhysicsCheckbox;
        private System.Windows.Forms.ComboBox bodyTypeBox;
        private System.Windows.Forms.CheckBox lockRotationCheckbox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label updateLabel;
        private System.Windows.Forms.Label createLabel;
        private System.Windows.Forms.Label destroyLabel;
        private System.Windows.Forms.Label keyReleasedLabel;
        private System.Windows.Forms.Label keyPressedLabel;
        private System.Windows.Forms.Label drawLabel;
        private System.Windows.Forms.Label mousePressedLabel;
        private System.Windows.Forms.Label mouseReleasedLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown densityBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown frictionBox;
        private System.Windows.Forms.NumericUpDown restitutionBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox colliderTypeBox;
    }
}