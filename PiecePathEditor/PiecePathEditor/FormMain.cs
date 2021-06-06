using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiecePathEditor
{
    public partial class FormMain : Form
    {
        private enum PointSequence
        {
            /// <summary>
            /// 
            /// </summary>
            None,

            /// <summary>
            /// 
            /// </summary>
            Add,

            /// <summary>
            /// 
            /// </summary>
            Move,

            /// <summary>
            /// 
            /// </summary>
            Remove,
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            Points = new List<Point>();
            CurrentPoint = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var point in Points)
            {
                int x = e.X - point.X;
                int y = e.Y - point.Y;
                double r = Math.Sqrt(x * x + y * y);

                if (r <= 3.0)
                {
                    CurrentPoint = point;
                    Sequence = PointSequence.Move;
                    return;
                }
            }

            Sequence = PointSequence.Add;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            switch (Sequence)
            {
                case PointSequence.Add:
                    Points.Add(new Point(e.X, e.Y));
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private class Point
        {
            /// <summary>
            /// 
            /// </summary>
            public int X { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int Y { get; set; }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private PointSequence Sequence { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private List<Point> Points { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private Point CurrentPoint { get; set; }
    }
}
