namespace JSGameIDE
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Sprites");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Objects");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Rooms");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Scripts");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projetoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadAssetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opçõesDoProjetoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hTML5ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buildAndRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.livePreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentsTree = new System.Windows.Forms.TreeView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.childMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deletarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.livePreview = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.childMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.novoToolStripMenuItem,
            this.projetoToolStripMenuItem,
            this.buildToolStripMenuItem,
            this.livePreviewToolStripMenuItem,
            this.editorToolStripMenuItem,
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
            this.novoToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.novoToolStripMenuItem1.Text = "New";
            this.novoToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem1_Click);
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.salvarToolStripMenuItem.Text = "Open";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // salvarToolStripMenuItem1
            // 
            this.salvarToolStripMenuItem1.Name = "salvarToolStripMenuItem1";
            this.salvarToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.salvarToolStripMenuItem1.Text = "Save";
            this.salvarToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spriteToolStripMenuItem,
            this.ObjectToolStripMenuItem,
            this.RoomToolStripMenuItem,
            this.scriptToolStripMenuItem});
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.novoToolStripMenuItem.Text = "Add";
            // 
            // spriteToolStripMenuItem
            // 
            this.spriteToolStripMenuItem.Name = "spriteToolStripMenuItem";
            this.spriteToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.spriteToolStripMenuItem.Text = "Sprite";
            this.spriteToolStripMenuItem.Click += new System.EventHandler(this.spriteToolStripMenuItem_Click);
            // 
            // ObjectToolStripMenuItem
            // 
            this.ObjectToolStripMenuItem.Name = "ObjectToolStripMenuItem";
            this.ObjectToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.ObjectToolStripMenuItem.Text = "Object";
            this.ObjectToolStripMenuItem.Click += new System.EventHandler(this.ObjectToolStripMenuItem_Click);
            // 
            // RoomToolStripMenuItem
            // 
            this.RoomToolStripMenuItem.Name = "RoomToolStripMenuItem";
            this.RoomToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.RoomToolStripMenuItem.Text = "Room";
            this.RoomToolStripMenuItem.Click += new System.EventHandler(this.RoomToolStripMenuItem_Click);
            // 
            // scriptToolStripMenuItem
            // 
            this.scriptToolStripMenuItem.Name = "scriptToolStripMenuItem";
            this.scriptToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.scriptToolStripMenuItem.Text = "Script";
            this.scriptToolStripMenuItem.Click += new System.EventHandler(this.scriptToolStripMenuItem_Click);
            // 
            // projetoToolStripMenuItem
            // 
            this.projetoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadAssetsToolStripMenuItem,
            this.opçõesDoProjetoToolStripMenuItem});
            this.projetoToolStripMenuItem.Name = "projetoToolStripMenuItem";
            this.projetoToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projetoToolStripMenuItem.Text = "Project";
            // 
            // reloadAssetsToolStripMenuItem
            // 
            this.reloadAssetsToolStripMenuItem.Name = "reloadAssetsToolStripMenuItem";
            this.reloadAssetsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.reloadAssetsToolStripMenuItem.Text = "Reimport Assets";
            this.reloadAssetsToolStripMenuItem.Click += new System.EventHandler(this.reloadAssetsToolStripMenuItem_Click);
            // 
            // opçõesDoProjetoToolStripMenuItem
            // 
            this.opçõesDoProjetoToolStripMenuItem.Name = "opçõesDoProjetoToolStripMenuItem";
            this.opçõesDoProjetoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.opçõesDoProjetoToolStripMenuItem.Text = "Project Settings";
            this.opçõesDoProjetoToolStripMenuItem.Click += new System.EventHandler(this.projectOptionsToolStripMenuItem_Click);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildToolStripMenuItem1,
            this.buildAndRunToolStripMenuItem});
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // buildToolStripMenuItem1
            // 
            this.buildToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hTML5ToolStripMenuItem1,
            this.windowsToolStripMenuItem1});
            this.buildToolStripMenuItem1.Name = "buildToolStripMenuItem1";
            this.buildToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.buildToolStripMenuItem1.Text = "Build";
            // 
            // hTML5ToolStripMenuItem1
            // 
            this.hTML5ToolStripMenuItem1.Name = "hTML5ToolStripMenuItem1";
            this.hTML5ToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.hTML5ToolStripMenuItem1.Text = "HTML5";
            this.hTML5ToolStripMenuItem1.Click += new System.EventHandler(this.hTML5ToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem1
            // 
            this.windowsToolStripMenuItem1.Name = "windowsToolStripMenuItem1";
            this.windowsToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.windowsToolStripMenuItem1.Text = "Windows";
            this.windowsToolStripMenuItem1.Click += new System.EventHandler(this.windowsToolStripMenuItem_Click);
            // 
            // buildAndRunToolStripMenuItem
            // 
            this.buildAndRunToolStripMenuItem.Name = "buildAndRunToolStripMenuItem";
            this.buildAndRunToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.buildAndRunToolStripMenuItem.Text = "Build and run";
            this.buildAndRunToolStripMenuItem.Click += new System.EventHandler(this.buildAndRunToolStripMenuItem_Click);
            // 
            // livePreviewToolStripMenuItem
            // 
            this.livePreviewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadToolStripMenuItem});
            this.livePreviewToolStripMenuItem.Name = "livePreviewToolStripMenuItem";
            this.livePreviewToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.livePreviewToolStripMenuItem.Text = "Live Preview";
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.editorToolStripMenuItem.Text = "Editor";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wikiToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.ajudaToolStripMenuItem.Text = "Help";
            // 
            // wikiToolStripMenuItem
            // 
            this.wikiToolStripMenuItem.Name = "wikiToolStripMenuItem";
            this.wikiToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.wikiToolStripMenuItem.Text = "Wiki";
            this.wikiToolStripMenuItem.Click += new System.EventHandler(this.wikiToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.sobreToolStripMenuItem.Text = "About";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // componentsTree
            // 
            this.componentsTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.componentsTree.Location = new System.Drawing.Point(0, 24);
            this.componentsTree.Name = "componentsTree";
            treeNode1.Name = "Sprites";
            treeNode1.Text = "Sprites";
            treeNode1.ToolTipText = "All game sprites";
            treeNode2.Name = "Objects";
            treeNode2.Text = "Objects";
            treeNode2.ToolTipText = "All game objects";
            treeNode3.Name = "Rooms";
            treeNode3.Text = "Rooms";
            treeNode3.ToolTipText = "All game rooms";
            treeNode4.Name = "Scripts";
            treeNode4.Text = "Scripts";
            treeNode4.ToolTipText = "All the Scripts of the game";
            this.componentsTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.componentsTree.Size = new System.Drawing.Size(138, 551);
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
            this.deletarToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // livePreview
            // 
            this.livePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.livePreview.Location = new System.Drawing.Point(138, 24);
            this.livePreview.Name = "livePreview";
            this.livePreview.Size = new System.Drawing.Size(725, 551);
            this.livePreview.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 575);
            this.Controls.Add(this.livePreview);
            this.Controls.Add(this.componentsTree);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JSGameIDE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
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
        private System.Windows.Forms.ToolStripMenuItem wikiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadAssetsToolStripMenuItem;
        private System.Windows.Forms.Panel livePreview;
        private System.Windows.Forms.ToolStripMenuItem livePreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem buildAndRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hTML5ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;

    }
}

