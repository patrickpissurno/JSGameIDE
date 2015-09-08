﻿namespace JSGameIDE
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Sprites");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Objects");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Rooms");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Scripts");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.projetoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opçõesDoProjetoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentsTree = new System.Windows.Forms.TreeView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.childMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deletarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.childMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.projetoToolStripMenuItem,
            this.novoToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(863, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem1,
            this.salvarToolStripMenuItem,
            this.salvarToolStripMenuItem1});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.arquivoToolStripMenuItem.Text = "File";
            // 
            // novoToolStripMenuItem1
            // 
            this.novoToolStripMenuItem1.Name = "novoToolStripMenuItem1";
            this.novoToolStripMenuItem1.Size = new System.Drawing.Size(157, 22);
            this.novoToolStripMenuItem1.Text = "New";
            this.novoToolStripMenuItem1.Click += new System.EventHandler(this.novoToolStripMenuItem1_Click);
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.salvarToolStripMenuItem.Text = "Open";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem1_Click);
            // 
            // salvarToolStripMenuItem1
            // 
            this.salvarToolStripMenuItem1.Name = "salvarToolStripMenuItem1";
            this.salvarToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.salvarToolStripMenuItem1.Text = "Save (CTRL+S)";
            this.salvarToolStripMenuItem1.Click += new System.EventHandler(this.salvarToolStripMenuItem1_Click);
            // 
            // projetoToolStripMenuItem
            // 
            this.projetoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarToolStripMenuItem,
            this.testarToolStripMenuItem,
            this.opçõesDoProjetoToolStripMenuItem});
            this.projetoToolStripMenuItem.Name = "projetoToolStripMenuItem";
            this.projetoToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projetoToolStripMenuItem.Text = "Project";
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.exportarToolStripMenuItem.Text = "Export";
            this.exportarToolStripMenuItem.Click += new System.EventHandler(this.exportarToolStripMenuItem_Click);
            // 
            // testarToolStripMenuItem
            // 
            this.testarToolStripMenuItem.Name = "testarToolStripMenuItem";
            this.testarToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.testarToolStripMenuItem.Text = "Export and run (CTRL+B)";
            this.testarToolStripMenuItem.Click += new System.EventHandler(this.testarToolStripMenuItem_Click);
            // 
            // opçõesDoProjetoToolStripMenuItem
            // 
            this.opçõesDoProjetoToolStripMenuItem.Name = "opçõesDoProjetoToolStripMenuItem";
            this.opçõesDoProjetoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.opçõesDoProjetoToolStripMenuItem.Text = "Project options";
            this.opçõesDoProjetoToolStripMenuItem.Click += new System.EventHandler(this.opçõesDoProjetoToolStripMenuItem_Click);
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spriteToolStripMenuItem,
            this.ObjectToolStripMenuItem,
            this.RoomToolStripMenuItem,
            this.scriptToolStripMenuItem});
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.novoToolStripMenuItem.Text = "New";
            // 
            // spriteToolStripMenuItem
            // 
            this.spriteToolStripMenuItem.Name = "spriteToolStripMenuItem";
            this.spriteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.spriteToolStripMenuItem.Text = "Sprite";
            this.spriteToolStripMenuItem.Click += new System.EventHandler(this.spriteToolStripMenuItem_Click);
            // 
            // ObjectToolStripMenuItem
            // 
            this.ObjectToolStripMenuItem.Name = "ObjectToolStripMenuItem";
            this.ObjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ObjectToolStripMenuItem.Text = "Object";
            this.ObjectToolStripMenuItem.Click += new System.EventHandler(this.ObjectToolStripMenuItem_Click);
            // 
            // RoomToolStripMenuItem
            // 
            this.RoomToolStripMenuItem.Name = "RoomToolStripMenuItem";
            this.RoomToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.RoomToolStripMenuItem.Text = "Room";
            this.RoomToolStripMenuItem.Click += new System.EventHandler(this.RoomToolStripMenuItem_Click);
            // 
            // scriptToolStripMenuItem
            // 
            this.scriptToolStripMenuItem.Name = "scriptToolStripMenuItem";
            this.scriptToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.scriptToolStripMenuItem.Text = "Script";
            this.scriptToolStripMenuItem.Click += new System.EventHandler(this.scriptToolStripMenuItem_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.ajudaToolStripMenuItem.Text = "Help";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.sobreToolStripMenuItem.Text = "About";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // componentsTree
            // 
            this.componentsTree.Location = new System.Drawing.Point(0, 27);
            this.componentsTree.Name = "componentsTree";
            treeNode13.Name = "Sprites";
            treeNode13.Text = "Sprites";
            treeNode13.ToolTipText = "All game sprites";
            treeNode14.Name = "Objects";
            treeNode14.Text = "Objects";
            treeNode14.ToolTipText = "All game objects";
            treeNode15.Name = "Rooms";
            treeNode15.Text = "Rooms";
            treeNode15.ToolTipText = "All game rooms";
            treeNode16.Name = "Scripts";
            treeNode16.Text = "Scripts";
            treeNode16.ToolTipText = "All the Scripts of the game";
            this.componentsTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16});
            this.componentsTree.Size = new System.Drawing.Size(121, 551);
            this.componentsTree.TabIndex = 1;
            this.componentsTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.componentsTree_NodeMouseDoubleClick);
            this.componentsTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.componentsTree_MouseUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "JSGameIDE Project Files|*.JSGP";
            this.openFileDialog1.Title = "Please select the project to be opened";
            // 
            // childMenu
            // 
            this.childMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deletarToolStripMenuItem});
            this.childMenu.Name = "contextMenuStrip1";
            this.childMenu.Size = new System.Drawing.Size(112, 26);
            // 
            // deletarToolStripMenuItem
            // 
            this.deletarToolStripMenuItem.Name = "deletarToolStripMenuItem";
            this.deletarToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.deletarToolStripMenuItem.Text = "Deletar";
            this.deletarToolStripMenuItem.Click += new System.EventHandler(this.deletarToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 575);
            this.Controls.Add(this.componentsTree);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JSGameIDE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.childMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projetoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.TreeView componentsTree;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip childMenu;
        private System.Windows.Forms.ToolStripMenuItem deletarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opçõesDoProjetoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptToolStripMenuItem;

    }
}

