﻿namespace PiecePathEditor
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
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorFilesCommands = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorEditCommands = new System.Windows.Forms.ToolStripSeparator();
            this.clearLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorEdits = new System.Windows.Forms.ToolStripSeparator();
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
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelCodeStyle = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonCodeStyleClass = new System.Windows.Forms.RadioButton();
            this.radioButtonCodeStyleArray = new System.Windows.Forms.RadioButton();
            this.radioButtonCodeStyleJsPath = new System.Windows.Forms.RadioButton();
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
            this.flowLayoutPanelCodeStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxCanvas
            // 
            this.pictureBoxCanvas.BackColor = System.Drawing.Color.White;
            this.pictureBoxCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCanvas.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxCanvas.Name = "pictureBoxCanvas";
            this.pictureBoxCanvas.Size = new System.Drawing.Size(444, 399);
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
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItemOpenImage,
            this.toolStripSeparatorFilesCommands,
            this.toolStripMenuItemExit});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(51, 20);
            this.toolStripMenuItemFile.Text = "File(&F)";
            this.toolStripMenuItemFile.DropDownOpening += new System.EventHandler(this.toolStripMenuItemFile_DropDownOpening);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.newToolStripMenuItem.Text = "New(&N)";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemNew_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openToolStripMenuItem.Text = "Open(&O)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemOpen_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveToolStripMenuItem.Text = "Save(&S)";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemSave_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveAsToolStripMenuItem.Text = "Save as(&A)";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemSaveAs_Click);
            // 
            // toolStripMenuItemOpenImage
            // 
            this.toolStripMenuItemOpenImage.Name = "toolStripMenuItemOpenImage";
            this.toolStripMenuItemOpenImage.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItemOpenImage.Text = "Open Image(&O)";
            this.toolStripMenuItemOpenImage.Click += new System.EventHandler(this.toolStripMenuItemOpenImage_Click);
            // 
            // toolStripSeparatorFilesCommands
            // 
            this.toolStripSeparatorFilesCommands.Name = "toolStripSeparatorFilesCommands";
            this.toolStripSeparatorFilesCommands.Size = new System.Drawing.Size(152, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItemExit.Text = "Exit(&E)";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUndo,
            this.toolStripMenuItemRedo,
            this.toolStripSeparatorEditCommands,
            this.clearLToolStripMenuItem,
            this.toolStripSeparatorEdits,
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
            // clearLToolStripMenuItem
            // 
            this.clearLToolStripMenuItem.Name = "clearLToolStripMenuItem";
            this.clearLToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.clearLToolStripMenuItem.Text = "Clear(&L)";
            this.clearLToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemClear_Click);
            // 
            // toolStripSeparatorEdits
            // 
            this.toolStripSeparatorEdits.Name = "toolStripSeparatorEdits";
            this.toolStripSeparatorEdits.Size = new System.Drawing.Size(158, 6);
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
            this.listViewPoints.FullRowSelect = true;
            this.listViewPoints.HideSelection = false;
            this.listViewPoints.Location = new System.Drawing.Point(3, 3);
            this.listViewPoints.Name = "listViewPoints";
            this.listViewPoints.Size = new System.Drawing.Size(265, 204);
            this.listViewPoints.TabIndex = 0;
            this.listViewPoints.UseCompatibleStateImageBehavior = false;
            this.listViewPoints.View = System.Windows.Forms.View.Details;
            this.listViewPoints.SelectedIndexChanged += new System.EventHandler(this.listViewPoints_SelectedIndexChanged);
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
            this.tableLayoutPanelCanvas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCanvas.Controls.Add(this.pictureBoxCanvas, 0, 0);
            this.tableLayoutPanelCanvas.Controls.Add(this.tableLayoutPanelCanvasUI, 0, 1);
            this.tableLayoutPanelCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCanvas.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelCanvas.Name = "tableLayoutPanelCanvas";
            this.tableLayoutPanelCanvas.RowCount = 2;
            this.tableLayoutPanelCanvas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCanvas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelCanvas.Size = new System.Drawing.Size(450, 440);
            this.tableLayoutPanelCanvas.TabIndex = 1;
            // 
            // tableLayoutPanelCanvasUI
            // 
            this.tableLayoutPanelCanvasUI.ColumnCount = 2;
            this.tableLayoutPanelCanvasUI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCanvasUI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelCanvasUI.Controls.Add(this.trackBarCanvasScaling, 0, 0);
            this.tableLayoutPanelCanvasUI.Controls.Add(this.buttonSelectColor, 1, 0);
            this.tableLayoutPanelCanvasUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCanvasUI.Location = new System.Drawing.Point(3, 408);
            this.tableLayoutPanelCanvasUI.Name = "tableLayoutPanelCanvasUI";
            this.tableLayoutPanelCanvasUI.RowCount = 1;
            this.tableLayoutPanelCanvasUI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCanvasUI.Size = new System.Drawing.Size(444, 29);
            this.tableLayoutPanelCanvasUI.TabIndex = 2;
            // 
            // trackBarCanvasScaling
            // 
            this.trackBarCanvasScaling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarCanvasScaling.Location = new System.Drawing.Point(3, 3);
            this.trackBarCanvasScaling.Maximum = 15;
            this.trackBarCanvasScaling.Minimum = 1;
            this.trackBarCanvasScaling.Name = "trackBarCanvasScaling";
            this.trackBarCanvasScaling.Size = new System.Drawing.Size(408, 23);
            this.trackBarCanvasScaling.TabIndex = 1;
            this.trackBarCanvasScaling.TabStop = false;
            this.trackBarCanvasScaling.Value = 1;
            this.trackBarCanvasScaling.Scroll += new System.EventHandler(this.trackBarCanvasScaling_Scroll);
            // 
            // buttonSelectColor
            // 
            this.buttonSelectColor.BackColor = System.Drawing.Color.Black;
            this.buttonSelectColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSelectColor.Location = new System.Drawing.Point(417, 3);
            this.buttonSelectColor.Name = "buttonSelectColor";
            this.buttonSelectColor.Size = new System.Drawing.Size(24, 23);
            this.buttonSelectColor.TabIndex = 2;
            this.buttonSelectColor.UseVisualStyleBackColor = false;
            this.buttonSelectColor.Click += new System.EventHandler(this.buttonSelectColor_Click);
            // 
            // tableLayoutPanelOutput
            // 
            this.tableLayoutPanelOutput.ColumnCount = 1;
            this.tableLayoutPanelOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOutput.Controls.Add(this.listViewPoints, 0, 0);
            this.tableLayoutPanelOutput.Controls.Add(this.textBoxCode, 0, 1);
            this.tableLayoutPanelOutput.Controls.Add(this.flowLayoutPanelCodeStyle, 0, 2);
            this.tableLayoutPanelOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelOutput.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelOutput.Name = "tableLayoutPanelOutput";
            this.tableLayoutPanelOutput.RowCount = 3;
            this.tableLayoutPanelOutput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.98592F));
            this.tableLayoutPanelOutput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.01408F));
            this.tableLayoutPanelOutput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelOutput.Size = new System.Drawing.Size(271, 440);
            this.tableLayoutPanelOutput.TabIndex = 2;
            // 
            // textBoxCode
            // 
            this.textBoxCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCode.Location = new System.Drawing.Point(3, 213);
            this.textBoxCode.Multiline = true;
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.ReadOnly = true;
            this.textBoxCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCode.Size = new System.Drawing.Size(265, 196);
            this.textBoxCode.TabIndex = 2;
            // 
            // flowLayoutPanelCodeStyle
            // 
            this.flowLayoutPanelCodeStyle.Controls.Add(this.radioButtonCodeStyleClass);
            this.flowLayoutPanelCodeStyle.Controls.Add(this.radioButtonCodeStyleArray);
            this.flowLayoutPanelCodeStyle.Controls.Add(this.radioButtonCodeStyleJsPath);
            this.flowLayoutPanelCodeStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelCodeStyle.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelCodeStyle.Location = new System.Drawing.Point(3, 415);
            this.flowLayoutPanelCodeStyle.Name = "flowLayoutPanelCodeStyle";
            this.flowLayoutPanelCodeStyle.Size = new System.Drawing.Size(265, 22);
            this.flowLayoutPanelCodeStyle.TabIndex = 3;
            // 
            // radioButtonCodeStyleClass
            // 
            this.radioButtonCodeStyleClass.AutoSize = true;
            this.radioButtonCodeStyleClass.Location = new System.Drawing.Point(210, 3);
            this.radioButtonCodeStyleClass.Name = "radioButtonCodeStyleClass";
            this.radioButtonCodeStyleClass.Size = new System.Drawing.Size(52, 16);
            this.radioButtonCodeStyleClass.TabIndex = 2;
            this.radioButtonCodeStyleClass.TabStop = true;
            this.radioButtonCodeStyleClass.Text = "Class";
            this.radioButtonCodeStyleClass.UseVisualStyleBackColor = true;
            this.radioButtonCodeStyleClass.CheckedChanged += new System.EventHandler(this.radioButtonCodeStyleRadioButton_CheckedChanged);
            // 
            // radioButtonCodeStyleArray
            // 
            this.radioButtonCodeStyleArray.AutoSize = true;
            this.radioButtonCodeStyleArray.Location = new System.Drawing.Point(153, 3);
            this.radioButtonCodeStyleArray.Name = "radioButtonCodeStyleArray";
            this.radioButtonCodeStyleArray.Size = new System.Drawing.Size(51, 16);
            this.radioButtonCodeStyleArray.TabIndex = 1;
            this.radioButtonCodeStyleArray.Text = "Array";
            this.radioButtonCodeStyleArray.UseVisualStyleBackColor = true;
            this.radioButtonCodeStyleArray.CheckedChanged += new System.EventHandler(this.radioButtonCodeStyleRadioButton_CheckedChanged);
            // 
            // radioButtonCodeStyleJsPath
            // 
            this.radioButtonCodeStyleJsPath.AutoSize = true;
            this.radioButtonCodeStyleJsPath.Checked = true;
            this.radioButtonCodeStyleJsPath.Location = new System.Drawing.Point(42, 3);
            this.radioButtonCodeStyleJsPath.Name = "radioButtonCodeStyleJsPath";
            this.radioButtonCodeStyleJsPath.Size = new System.Drawing.Size(105, 16);
            this.radioButtonCodeStyleJsPath.TabIndex = 0;
            this.radioButtonCodeStyleJsPath.TabStop = true;
            this.radioButtonCodeStyleJsPath.Text = "JavaScript Path";
            this.radioButtonCodeStyleJsPath.UseVisualStyleBackColor = true;
            this.radioButtonCodeStyleJsPath.CheckedChanged += new System.EventHandler(this.radioButtonCodeStyleRadioButton_CheckedChanged);
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
            this.flowLayoutPanelCodeStyle.ResumeLayout(false);
            this.flowLayoutPanelCodeStyle.PerformLayout();
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
        private System.Windows.Forms.TextBox textBoxCode;
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
        private System.Windows.Forms.ToolStripMenuItem clearLToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorEdits;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCodeStyle;
        private System.Windows.Forms.RadioButton radioButtonCodeStyleJsPath;
        private System.Windows.Forms.RadioButton radioButtonCodeStyleArray;
        private System.Windows.Forms.RadioButton radioButtonCodeStyleClass;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    }
}

