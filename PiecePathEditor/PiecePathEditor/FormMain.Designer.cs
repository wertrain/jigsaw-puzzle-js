namespace PiecePathEditor
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxCanvas = new System.Windows.Forms.PictureBox();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorFilesCommands = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorEditCommands = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemAutoContour = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewPoints = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPoint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelCanvas = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelCanvasUI = new System.Windows.Forms.TableLayoutPanel();
            this.trackBarCanvasScaling = new System.Windows.Forms.TrackBar();
            this.buttonSelectColor = new System.Windows.Forms.Button();
            this.tableLayoutPanelOutput = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).BeginInit();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tableLayoutPanelCanvas.SuspendLayout();
            this.tableLayoutPanelCanvasUI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCanvasScaling)).BeginInit();
            this.tableLayoutPanelOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxCanvas
            // 
            this.pictureBoxCanvas.BackColor = System.Drawing.Color.White;
            this.pictureBoxCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCanvas.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxCanvas.Name = "pictureBoxCanvas";
            this.pictureBoxCanvas.Size = new System.Drawing.Size(444, 397);
            this.pictureBoxCanvas.TabIndex = 0;
            this.pictureBoxCanvas.TabStop = false;
            this.pictureBoxCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCanvas_MouseDown);
            this.pictureBoxCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCanvas_MouseMove);
            this.pictureBoxCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCanvas_MouseUp);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemEdit});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(725, 24);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "File(&F)";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItemOpenImage,
            this.toolStripSeparatorFilesCommands,
            this.toolStripMenuItemExit});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(51, 20);
            this.toolStripMenuItemFile.Text = "File(&F)";
            // 
            // toolStripMenuItemOpenImage
            // 
            this.toolStripMenuItemOpenImage.Name = "toolStripMenuItemOpenImage";
            this.toolStripMenuItemOpenImage.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemOpenImage.Text = "Open Image(&O)";
            this.toolStripMenuItemOpenImage.Click += new System.EventHandler(this.toolStripMenuItemOpenImage_Click);
            // 
            // toolStripSeparatorFilesCommands
            // 
            this.toolStripSeparatorFilesCommands.Name = "toolStripSeparatorFilesCommands";
            this.toolStripSeparatorFilesCommands.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemExit.Text = "Exit(&E)";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUndo,
            this.toolStripMenuItemRedo,
            this.toolStripSeparatorEditCommands,
            this.toolStripMenuItemAutoContour});
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(53, 20);
            this.toolStripMenuItemEdit.Text = "Edit(&E)";
            // 
            // toolStripMenuItemUndo
            // 
            this.toolStripMenuItemUndo.Name = "toolStripMenuItemUndo";
            this.toolStripMenuItemUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.toolStripMenuItemUndo.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItemUndo.Text = "Undo(&U)";
            this.toolStripMenuItemUndo.Click += new System.EventHandler(this.toolStripMenuItemUndo_Click);
            // 
            // toolStripMenuItemRedo
            // 
            this.toolStripMenuItemRedo.Name = "toolStripMenuItemRedo";
            this.toolStripMenuItemRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.toolStripMenuItemRedo.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItemRedo.Text = "Redo(&R)";
            this.toolStripMenuItemRedo.Click += new System.EventHandler(this.toolStripMenuItemRedo_Click);
            // 
            // toolStripSeparatorEditCommands
            // 
            this.toolStripSeparatorEditCommands.Name = "toolStripSeparatorEditCommands";
            this.toolStripSeparatorEditCommands.Size = new System.Drawing.Size(158, 6);
            // 
            // toolStripMenuItemAutoContour
            // 
            this.toolStripMenuItemAutoContour.Name = "toolStripMenuItemAutoContour";
            this.toolStripMenuItemAutoContour.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItemAutoContour.Text = "Auto Contour(&K)";
            this.toolStripMenuItemAutoContour.Click += new System.EventHandler(this.toolStripMenuItemAutoContour_Click);
            // 
            // listViewPoints
            // 
            this.listViewPoints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderPoint});
            this.listViewPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPoints.HideSelection = false;
            this.listViewPoints.Location = new System.Drawing.Point(3, 3);
            this.listViewPoints.Name = "listViewPoints";
            this.listViewPoints.Size = new System.Drawing.Size(265, 218);
            this.listViewPoints.TabIndex = 0;
            this.listViewPoints.UseCompatibleStateImageBehavior = false;
            this.listViewPoints.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 77;
            // 
            // columnHeaderPoint
            // 
            this.columnHeaderPoint.Text = "Point";
            this.columnHeaderPoint.Width = 90;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 24);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.tableLayoutPanelCanvas);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tableLayoutPanelOutput);
            this.splitContainerMain.Size = new System.Drawing.Size(725, 440);
            this.splitContainerMain.SplitterDistance = 450;
            this.splitContainerMain.TabIndex = 2;
            this.splitContainerMain.TabStop = false;
            // 
            // tableLayoutPanelCanvas
            // 
            this.tableLayoutPanelCanvas.ColumnCount = 1;
            this.tableLayoutPanelCanvas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCanvas.Controls.Add(this.pictureBoxCanvas, 0, 0);
            this.tableLayoutPanelCanvas.Controls.Add(this.tableLayoutPanelCanvasUI, 0, 1);
            this.tableLayoutPanelCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCanvas.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelCanvas.Name = "tableLayoutPanelCanvas";
            this.tableLayoutPanelCanvas.RowCount = 2;
            this.tableLayoutPanelCanvas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.80723F));
            this.tableLayoutPanelCanvas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.192771F));
            this.tableLayoutPanelCanvas.Size = new System.Drawing.Size(450, 440);
            this.tableLayoutPanelCanvas.TabIndex = 1;
            // 
            // tableLayoutPanelCanvasUI
            // 
            this.tableLayoutPanelCanvasUI.ColumnCount = 2;
            this.tableLayoutPanelCanvasUI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 93.24324F));
            this.tableLayoutPanelCanvasUI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.756757F));
            this.tableLayoutPanelCanvasUI.Controls.Add(this.trackBarCanvasScaling, 0, 0);
            this.tableLayoutPanelCanvasUI.Controls.Add(this.buttonSelectColor, 1, 0);
            this.tableLayoutPanelCanvasUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCanvasUI.Location = new System.Drawing.Point(3, 406);
            this.tableLayoutPanelCanvasUI.Name = "tableLayoutPanelCanvasUI";
            this.tableLayoutPanelCanvasUI.RowCount = 1;
            this.tableLayoutPanelCanvasUI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCanvasUI.Size = new System.Drawing.Size(444, 31);
            this.tableLayoutPanelCanvasUI.TabIndex = 2;
            // 
            // trackBarCanvasScaling
            // 
            this.trackBarCanvasScaling.Location = new System.Drawing.Point(3, 3);
            this.trackBarCanvasScaling.Minimum = 1;
            this.trackBarCanvasScaling.Name = "trackBarCanvasScaling";
            this.trackBarCanvasScaling.Size = new System.Drawing.Size(407, 25);
            this.trackBarCanvasScaling.TabIndex = 1;
            this.trackBarCanvasScaling.TabStop = false;
            this.trackBarCanvasScaling.Value = 1;
            this.trackBarCanvasScaling.Scroll += new System.EventHandler(this.trackBarCanvasScaling_Scroll);
            // 
            // buttonSelectColor
            // 
            this.buttonSelectColor.BackColor = System.Drawing.Color.Black;
            this.buttonSelectColor.Location = new System.Drawing.Point(416, 3);
            this.buttonSelectColor.Name = "buttonSelectColor";
            this.buttonSelectColor.Size = new System.Drawing.Size(24, 23);
            this.buttonSelectColor.TabIndex = 2;
            this.buttonSelectColor.UseVisualStyleBackColor = false;
            this.buttonSelectColor.Click += new System.EventHandler(this.buttonSelectColor_Click);
            // 
            // tableLayoutPanelOutput
            // 
            this.tableLayoutPanelOutput.ColumnCount = 1;
            this.tableLayoutPanelOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelOutput.Controls.Add(this.listViewPoints, 0, 0);
            this.tableLayoutPanelOutput.Controls.Add(this.textBox1, 0, 1);
            this.tableLayoutPanelOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelOutput.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelOutput.Name = "tableLayoutPanelOutput";
            this.tableLayoutPanelOutput.RowCount = 2;
            this.tableLayoutPanelOutput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.98592F));
            this.tableLayoutPanelOutput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.01408F));
            this.tableLayoutPanelOutput.Size = new System.Drawing.Size(271, 440);
            this.tableLayoutPanelOutput.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 227);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(265, 210);
            this.textBox1.TabIndex = 2;
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save as(&A)";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open(&O)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 464);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.Text = "PathEditor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tableLayoutPanelCanvas.ResumeLayout(false);
            this.tableLayoutPanelCanvasUI.ResumeLayout(false);
            this.tableLayoutPanelCanvasUI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCanvasScaling)).EndInit();
            this.tableLayoutPanelOutput.ResumeLayout(false);
            this.tableLayoutPanelOutput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxCanvas;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenImage;
        private System.Windows.Forms.ListView listViewPoints;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderPoint;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOutput;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUndo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRedo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorEditCommands;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAutoContour;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorFilesCommands;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCanvas;
        private System.Windows.Forms.TrackBar trackBarCanvasScaling;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCanvasUI;
        private System.Windows.Forms.Button buttonSelectColor;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    }
}

