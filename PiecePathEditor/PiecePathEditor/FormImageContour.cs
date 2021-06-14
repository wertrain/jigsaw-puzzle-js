using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiecePathEditor
{
    public partial class FormImageContour : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public int Loops { get { return decimal.ToInt32(numericUpDownLoops.Value); } }

        /// <summary>
        /// 
        /// </summary>
        public int Vertices { get { return decimal.ToInt32(numericUpDownVertices.Value); } }

        /// <summary>
        /// 
        /// </summary>
        public float Alpha { get { return decimal.ToSingle(numericUpDownAlpha.Value); } }

        /// <summary>
        /// 
        /// </summary>
        public float Beta { get { return decimal.ToSingle(numericUpDownBeta.Value); } }

        /// <summary>
        /// 
        /// </summary>
        public float Gammma { get { return decimal.ToSingle(numericUpDownGamma.Value); } }

        /// <summary>
        /// 
        /// </summary>
        public string FileName { get { return textBoxOpenFile.Text; } }

        /// <summary>
        /// 
        /// </summary>
        public FormImageContour()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxOpenFile_TextChanged(object sender, EventArgs e)
        {
            var textbox = (TextBox)sender;
            buttonExecute.Enabled = File.Exists(textbox.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image File(*.bmp,*.jpg,*.png,*.tif)|*.bmp;*.jpg;*.png;*.tif|Bitmap(*.bmp)|*.bmp|Jpeg(*.jpg)|*.jpg|PNG(*.png)|*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBoxOpenFile.Text = ofd.FileName;
                }
            }
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {

        }
    }
}
