namespace JSGameIDE
{
    partial class RoomEditor
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adicionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instanceMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deletarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomSpace = new JSGameIDE.RoomGroupBox();
            this.menuStrip1.SuspendLayout();
            this.instanceMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adicionarToolStripMenuItem
            // 
            this.adicionarToolStripMenuItem.Name = "adicionarToolStripMenuItem";
            this.adicionarToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.adicionarToolStripMenuItem.Text = "Add";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridOptionsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // gridOptionsToolStripMenuItem
            // 
            this.gridOptionsToolStripMenuItem.Name = "gridOptionsToolStripMenuItem";
            this.gridOptionsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.gridOptionsToolStripMenuItem.Text = "Grid settings";
            this.gridOptionsToolStripMenuItem.Click += new System.EventHandler(this.gridOptionsToolStripMenuItem_Click);
            // 
            // instanceMenu
            // 
            this.instanceMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deletarToolStripMenuItem});
            this.instanceMenu.Name = "instanceMenu";
            this.instanceMenu.Size = new System.Drawing.Size(112, 26);
            // 
            // deletarToolStripMenuItem
            // 
            this.deletarToolStripMenuItem.Name = "deletarToolStripMenuItem";
            this.deletarToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.deletarToolStripMenuItem.Text = "Deletar";
            this.deletarToolStripMenuItem.Click += new System.EventHandler(this.deletarToolStripMenuItem_Click);
            // 
            // roomSpace
            // 
            this.roomSpace.BackColor = System.Drawing.SystemColors.ControlLight;
            this.roomSpace.Location = new System.Drawing.Point(12, 27);
            this.roomSpace.Name = "roomSpace";
            this.roomSpace.Size = new System.Drawing.Size(800, 600);
            this.roomSpace.TabIndex = 2;
            this.roomSpace.TabStop = false;
            // 
            // RoomEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.roomSpace);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "RoomEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoomEditor_FormClosing);
            this.Resize += new System.EventHandler(this.RoomEditor_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.instanceMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adicionarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip instanceMenu;
        private System.Windows.Forms.ToolStripMenuItem deletarToolStripMenuItem;
        //private System.Windows.Forms.GroupBox roomSpace;
        private RoomGroupBox roomSpace;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridOptionsToolStripMenuItem;
    }
}