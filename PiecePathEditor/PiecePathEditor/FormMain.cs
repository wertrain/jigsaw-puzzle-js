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

            _commandManager = new CommandManager();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var point in _commandManager.Points)
            {
                int x = e.X - point.X;
                int y = e.Y - point.Y;
                double r = Math.Sqrt(x * x + y * y);

                if (r <= PointRadius)
                {
                    CurrentPoint = point;
                    break;
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                if (CurrentPoint == null)
                {
                    Sequence = PointSequence.Add;
                }
                else
                {
                    int x = e.X - CurrentPoint.X;
                    int y = e.Y - CurrentPoint.Y;
                    MoveStartPoint = new Point(x, y);

                    Sequence = PointSequence.Move;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (CurrentPoint != null)
                {
                    Sequence = PointSequence.Remove;
                }
            }
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
                    _commandManager.AddPoint(e.X, e.Y);
                    UpdateAll();
                    break;

                case PointSequence.Move:
                    _commandManager.MovePoint(MoveStartPoint, CurrentPoint.X, CurrentPoint.Y);
                    MoveStartPoint = CurrentPoint = null;
                    UpdateAll();
                    break;

                case PointSequence.Remove:
                    _commandManager.RemovePoint(CurrentPoint);
                    CurrentPoint = null;
                    UpdateAll();
                    break;
            }

            Sequence = PointSequence.None;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            switch (Sequence)
            {
                case PointSequence.Move:
                    CurrentPoint.X = e.X;
                    CurrentPoint.Y = e.Y;
                    UpdateCanvas();
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateAll()
        {
            UpdateListView();
            UpdateCanvas();
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateListView()
        {
            listViewPoints.SuspendLayout();

            listViewPoints.Items.Clear();
            foreach (var point in _commandManager.Points)
            {
                var item = new ListViewItem();
                item.Text = "Point";

                var subItem = new ListViewItem.ListViewSubItem();
                subItem.Text = $"({point.X},{point.Y})";
                item.SubItems.Add(subItem);

                listViewPoints.Items.Add(item);
            }

            listViewPoints.ResumeLayout();
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateCanvas()
        {
            var canvas = pictureBoxCanvas;
            canvas.Image?.Dispose();

            var bitmap = new Bitmap(canvas.Width, canvas.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                var blackBrush = new SolidBrush(Color.Black);

                Point prevPoint = null;
                foreach (var point in _commandManager.Points)
                {
                    g.FillEllipse(blackBrush, new Rectangle(point.X - PointRadius, point.Y - PointRadius, PointRadius * 2, PointRadius * 2));

                    if (prevPoint != null)
                    {
                        g.DrawLine(Pens.Black, prevPoint.X, prevPoint.Y, point.X, point.Y);
                    }
                    prevPoint = point;
                }
            }
            canvas.Image = bitmap;
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly int PointRadius = 5;

        /// <summary>
        /// 
        /// </summary>
        private PointSequence Sequence { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private CommandManager _commandManager;

        /// <summary>
        /// 
        /// </summary>
        private Point CurrentPoint;

        /// <summary>
        /// 
        /// </summary>
        private Point MoveStartPoint;
    }
}
