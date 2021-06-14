namespace PiecePathEditor
{
    partial class FormImageContour
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
            this.textBoxOpenFile = new System.Windows.Forms.TextBox();
            this.groupBoxFile = new System.Windows.Forms.GroupBox();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.groupBoxParameters = new System.Windows.Forms.GroupBox();
            this.numericUpDownLoops = new System.Windows.Forms.NumericUpDown();
            this.labelLoops = new System.Windows.Forms.Label();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.labelAlpha = new System.Windows.Forms.Label();
            this.numericUpDownAlpha = new System.Windows.Forms.NumericUpDown();
            this.labelBeta = new System.Windows.Forms.Label();
            this.numericUpDownBeta = new System.Windows.Forms.NumericUpDown();
            this.labelGamma = new System.Windows.Forms.Label();
            this.numericUpDownGamma = new System.Windows.Forms.NumericUpDown();
            this.labelVertices = new System.Windows.Forms.Label();
            this.numericUpDownVertices = new System.Windows.Forms.NumericUpDown();
            this.groupBoxFile.SuspendLayout();
            this.groupBoxParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLoops)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVertices)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxOpenFile
            // 
            this.textBoxOpenFile.Location = new System.Drawing.Point(17, 21);
            this.textBoxOpenFile.Name = "textBoxOpenFile";
            this.textBoxOpenFile.Size = new System.Drawing.Size(386, 19);
            this.textBoxOpenFile.TabIndex = 0;
            this.textBoxOpenFile.TextChanged += new System.EventHandler(this.textBoxOpenFile_TextChanged);
            // 
            // groupBoxFile
            // 
            this.groupBoxFile.Controls.Add(this.buttonOpenFile);
            this.groupBoxFile.Controls.Add(this.textBoxOpenFile);
            this.groupBoxFile.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFile.Name = "groupBoxFile";
            this.groupBoxFile.Size = new System.Drawing.Size(446, 54);
            this.groupBoxFile.TabIndex = 1;
            this.groupBoxFile.TabStop = false;
            this.groupBoxFile.Text = "File";
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(413, 19);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(23, 23);
            this.buttonOpenFile.TabIndex = 1;
            this.buttonOpenFile.Text = "...";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // groupBoxParameters
            // 
            this.groupBoxParameters.Controls.Add(this.labelGamma);
            this.groupBoxParameters.Controls.Add(this.numericUpDownGamma);
            this.groupBoxParameters.Controls.Add(this.labelBeta);
            this.groupBoxParameters.Controls.Add(this.numericUpDownBeta);
            this.groupBoxParameters.Controls.Add(this.labelAlpha);
            this.groupBoxParameters.Controls.Add(this.numericUpDownAlpha);
            this.groupBoxParameters.Location = new System.Drawing.Point(12, 71);
            this.groupBoxParameters.Name = "groupBoxParameters";
            this.groupBoxParameters.Size = new System.Drawing.Size(446, 58);
            this.groupBoxParameters.TabIndex = 2;
            this.groupBoxParameters.TabStop = false;
            this.groupBoxParameters.Text = "Parameters";
            // 
            // numericUpDownLoops
            // 
            this.numericUpDownLoops.Location = new System.Drawing.Point(268, 143);
            this.numericUpDownLoops.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownLoops.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLoops.Name = "numericUpDownLoops";
            this.numericUpDownLoops.Size = new System.Drawing.Size(51, 19);
            this.numericUpDownLoops.TabIndex = 0;
            this.numericUpDownLoops.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // labelLoops
            // 
            this.labelLoops.AutoSize = true;
            this.labelLoops.Location = new System.Drawing.Point(229, 146);
            this.labelLoops.Name = "labelLoops";
            this.labelLoops.Size = new System.Drawing.Size(35, 12);
            this.labelLoops.TabIndex = 1;
            this.labelLoops.Text = "Loops";
            // 
            // buttonExecute
            // 
            this.buttonExecute.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonExecute.Location = new System.Drawing.Point(334, 140);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(124, 23);
            this.buttonExecute.TabIndex = 3;
            this.buttonExecute.Text = "Execute(&E)";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // labelAlpha
            // 
            this.labelAlpha.AutoSize = true;
            this.labelAlpha.Location = new System.Drawing.Point(17, 26);
            this.labelAlpha.Name = "labelAlpha";
            this.labelAlpha.Size = new System.Drawing.Size(34, 12);
            this.labelAlpha.TabIndex = 3;
            this.labelAlpha.Text = "Alpha";
            // 
            // numericUpDownAlpha
            // 
            this.numericUpDownAlpha.DecimalPlaces = 2;
            this.numericUpDownAlpha.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownAlpha.Location = new System.Drawing.Point(58, 23);
            this.numericUpDownAlpha.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownAlpha.Name = "numericUpDownAlpha";
            this.numericUpDownAlpha.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownAlpha.TabIndex = 2;
            this.numericUpDownAlpha.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // labelBeta
            // 
            this.labelBeta.AutoSize = true;
            this.labelBeta.Location = new System.Drawing.Point(156, 26);
            this.labelBeta.Name = "labelBeta";
            this.labelBeta.Size = new System.Drawing.Size(29, 12);
            this.labelBeta.TabIndex = 5;
            this.labelBeta.Text = "Beta";
            // 
            // numericUpDownBeta
            // 
            this.numericUpDownBeta.DecimalPlaces = 2;
            this.numericUpDownBeta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownBeta.Location = new System.Drawing.Point(192, 23);
            this.numericUpDownBeta.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownBeta.Name = "numericUpDownBeta";
            this.numericUpDownBeta.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownBeta.TabIndex = 4;
            this.numericUpDownBeta.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // labelGamma
            // 
            this.labelGamma.AutoSize = true;
            this.labelGamma.Location = new System.Drawing.Point(294, 26);
            this.labelGamma.Name = "labelGamma";
            this.labelGamma.Size = new System.Drawing.Size(43, 12);
            this.labelGamma.TabIndex = 7;
            this.labelGamma.Text = "Gamma";
            // 
            // numericUpDownGamma
            // 
            this.numericUpDownGamma.DecimalPlaces = 2;
            this.numericUpDownGamma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownGamma.Location = new System.Drawing.Point(340, 23);
            this.numericUpDownGamma.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownGamma.Name = "numericUpDownGamma";
            this.numericUpDownGamma.Size = new System.Drawing.Size(80, 19);
            this.numericUpDownGamma.TabIndex = 6;
            this.numericUpDownGamma.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // labelVertices
            // 
            this.labelVertices.AutoSize = true;
            this.labelVertices.Location = new System.Drawing.Point(111, 146);
            this.labelVertices.Name = "labelVertices";
            this.labelVertices.Size = new System.Drawing.Size(48, 12);
            this.labelVertices.TabIndex = 5;
            this.labelVertices.Text = "Vertices";
            // 
            // numericUpDownVertices
            // 
            this.numericUpDownVertices.Location = new System.Drawing.Point(164, 143);
            this.numericUpDownVertices.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownVertices.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownVertices.Name = "numericUpDownVertices";
            this.numericUpDownVertices.Size = new System.Drawing.Size(51, 19);
            this.numericUpDownVertices.TabIndex = 4;
            this.numericUpDownVertices.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // FormImageContour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 172);
            this.Controls.Add(this.labelVertices);
            this.Controls.Add(this.numericUpDownVertices);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.labelLoops);
            this.Controls.Add(this.numericUpDownLoops);
            this.Controls.Add(this.groupBoxParameters);
            this.Controls.Add(this.groupBoxFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormImageContour";
            this.Text = "Image Contour";
            this.groupBoxFile.ResumeLayout(false);
            this.groupBoxFile.PerformLayout();
            this.groupBoxParameters.ResumeLayout(false);
            this.groupBoxParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLoops)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVertices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOpenFile;
        private System.Windows.Forms.GroupBox groupBoxFile;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.GroupBox groupBoxParameters;
        private System.Windows.Forms.Label labelGamma;
        private System.Windows.Forms.NumericUpDown numericUpDownGamma;
        private System.Windows.Forms.Label labelBeta;
        private System.Windows.Forms.NumericUpDown numericUpDownBeta;
        private System.Windows.Forms.Label labelAlpha;
        private System.Windows.Forms.NumericUpDown numericUpDownAlpha;
        private System.Windows.Forms.NumericUpDown numericUpDownLoops;
        private System.Windows.Forms.Label labelLoops;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.Label labelVertices;
        private System.Windows.Forms.NumericUpDown numericUpDownVertices;
    }
}