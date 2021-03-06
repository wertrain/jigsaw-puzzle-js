using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
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

            /// <summary>
            /// 
            /// </summary>
            Insert,

            /// <summary>
            /// 
            /// </summary>
            Offset,
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            MouseWheel += formMain_MouseWheel;

            _commandManager = new CommandManager();

            CanvasScaling = trackBarCanvasScaling.Value = 1;
            buttonSelectColor.BackColor = DefaultPenColor;

            _formDefaultTitle = Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formMain_MouseWheel(object sender, MouseEventArgs e)
        {
            var value = trackBarCanvasScaling.Value;

            value -= (int)((trackBarCanvasScaling.Maximum * (e.Delta / 120.0f)) / trackBarCanvasScaling.Maximum);

            trackBarCanvasScaling.Value = Math.Min(trackBarCanvasScaling.Maximum, Math.Max(trackBarCanvasScaling.Minimum, value));

            trackBarCanvasScaling_Scroll(trackBarCanvasScaling, EventArgs.Empty);
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
                var scalingPoint = new Point(point, CanvasScaling);

                int x = e.X - scalingPoint.X;
                int y = e.Y - scalingPoint.Y;

                double r = Math.Sqrt(x * x + y * y);

                if (r <= PointRadius)
                {
                    _currentPoint = point;
                    break;
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                if (_currentPoint == null)
                {
                    Sequence = listViewPoints.SelectedItems.Count == 0 ? PointSequence.Add : PointSequence.Insert;
                }
                else
                {
                    _moveStartPoint = new Point(_currentPoint.X, _currentPoint.Y);
                    Sequence = PointSequence.Move;

                    SelectPoint(_currentPoint);
                    UpdateCanvas();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (_currentPoint == null)
                {
                    SelectPoint(null); 
                }
                else
                {
                    Sequence = PointSequence.Remove;
                }

                UpdateAll();
            }
            else if (e.Button == MouseButtons.Middle)
            {
                Sequence = PointSequence.Offset;

                var mousePoint = new Point((int)(e.X / CanvasScaling), (int)(e.Y / CanvasScaling));
                _offsetStartPoint = new Point(mousePoint.X, mousePoint.Y);
                _offsetCurrentPoint = new Point(mousePoint.X, mousePoint.Y);
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
                    _commandManager.AddPoint((int)(e.X / CanvasScaling), (int)(e.Y / CanvasScaling));
                    UpdateAll();
                    break;

                case PointSequence.Insert:
                    var index = listViewPoints.SelectedIndices[0];
                    _commandManager.InsertPoint(index, (int)(e.X / CanvasScaling), (int)(e.Y / CanvasScaling));
                    UpdateAll();
                    break;

                case PointSequence.Move:
                    _commandManager.MovePoint(_moveStartPoint, _currentPoint);
                    _moveStartPoint = _currentPoint = null;
                    UpdateAll();
                    break;

                case PointSequence.Remove:
                    _commandManager.RemovePoint(_currentPoint);
                    if (_currentPoint == _selectedPoint) _selectedPoint = null;
                    _currentPoint = null;
                    UpdateAll();
                    break;

                case PointSequence.Offset:
                    _commandManager.OffsetPoints(new Point(_offsetCurrentPoint.X - _offsetStartPoint.X, _offsetCurrentPoint.Y - _offsetStartPoint.Y));
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
                    _currentPoint.X = (int)(e.X / CanvasScaling);
                    _currentPoint.Y = (int)(e.Y / CanvasScaling);
                    UpdateCanvas();
                    break;

                case PointSequence.Offset:
                    var mousePoint = new Point((int)(e.X / CanvasScaling), (int)(e.Y / CanvasScaling));
                    var offsetPoint = new Point(mousePoint.X - _offsetCurrentPoint.X, mousePoint.Y - _offsetCurrentPoint.Y);
                    foreach (var point in _commandManager.Points)
                    {
                        point.X = point.X + offsetPoint.X;
                        point.Y = point.Y + offsetPoint.Y;
                    }
                    _offsetCurrentPoint = mousePoint;
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
            UpdateCode();
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
                var item = new ListViewItem
                {
                    Text = "Point"
                };
                var subItem = new ListViewItem.ListViewSubItem
                {
                    Text = $"({point.X},{point.Y})"
                };
                item.SubItems.Add(subItem);
                item.Tag = point;
                item.Selected = _selectedPoint == point;

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
                if (_currentOpendImage != null)
                {
                    g.DrawImage(_currentOpendImage, 
                        _currentOpendImage.Width / 2 * CanvasScaling, 
                        _currentOpendImage.Height / 2 * CanvasScaling, 
                        _currentOpendImage.Width * CanvasScaling, 
                        _currentOpendImage.Height * CanvasScaling);
                }

                var brush = new SolidBrush(buttonSelectColor.BackColor);
                var pen = new Pen(buttonSelectColor.BackColor);

                Point prevPoint = null;
                foreach (var point in _commandManager.Points)
                {
                    var scalingPoint = new Point(point, CanvasScaling);
                    g.FillEllipse(brush, new Rectangle(scalingPoint.X - PointRadius, scalingPoint.Y - PointRadius, PointRadius * 2, PointRadius * 2));

                    if (prevPoint != null)
                    {
                        var scalingPrevPoint = new Point(prevPoint, CanvasScaling);
                        g.DrawLine(pen, scalingPrevPoint.X, scalingPrevPoint.Y, scalingPoint.X, scalingPoint.Y);
                    }
                    prevPoint = point;
                }

                if (_selectedPoint != null)
                {
                    var radius = (int)(PointRadius * 1.5);
                    var scalingPoint = new Point(_selectedPoint, CanvasScaling);
                    g.FillEllipse(brush, new Rectangle(scalingPoint.X - radius, scalingPoint.Y - radius, radius * 2, radius * 2));
                }
            }
            canvas.Image = bitmap;
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateCode()
        {
            textBoxCode.Text = string.Empty;

            var first = _commandManager.Points.FirstOrDefault();
            if (first == null) return;

            var builder = new StringBuilder();

            if (radioButtonCodeStyleJsPath.Checked)
            {
                builder.Append($"context.moveTo({first.X}, {first.Y});");
                builder.Append(Environment.NewLine);

                var pointList = _commandManager.Points.ToList();
                for (int index = 1; index < pointList.Count; ++index)
                {
                    var point = pointList[index];
                    builder.Append($"context.lineTo({point.X}, {point.Y});");
                    builder.Append(Environment.NewLine);
                }
                //builder.Append($"context.lineTo({first.X}, {first.Y});");
                //builder.Append(Environment.NewLine);
            }
            else if (radioButtonCodeStyleArray.Checked)
            {
                foreach (var point in _commandManager.Points)
                { 
                    builder.Append($"[{point.X}, {point.Y}],");
                    builder.Append(Environment.NewLine);
                }
            }
            else if (radioButtonCodeStyleClass.Checked)
            {
                foreach (var point in _commandManager.Points)
                {
                    builder.Append($"new Point({point.X}, {point.Y}),");
                    builder.Append(Environment.NewLine);
                }
            }

            textBoxCode.Text = builder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemNew_Click(object sender, EventArgs e)
        {
            SelectPoint(null);
            _currentFilePath = null;
            _currentOpendImage = null;
            Text = _formDefaultTitle;
            _commandManager.Clear();
            UpdateAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Contour File(*.ctr)|*.ctr";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var contourFile = FileManager.Instance.LoadFile(ofd.FileName);
                    if (contourFile == null) return;

                    _commandManager.Clear();
                    _currentOpendImage = contourFile.ModelImage;
                    foreach (var point in contourFile.Points)
                    {
                        _commandManager.AddPoint(new Point(point.X, point.Y));
                    }
                    _currentFilePath = ofd.FileName;

                    Text = $"{_formDefaultTitle} - {System.IO.Path.GetFileName(_currentFilePath)}";

                    UpdateAll();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            var contourFile = new FileManager.ContourFile();
            contourFile.ModelImage = _currentOpendImage == null ? null : new Bitmap(_currentOpendImage);
            foreach (var point in _commandManager.Points)
            {
                contourFile.Points.Add(new Point(point.X, point.Y));
            }
            FileManager.Instance.SaveFile(contourFile, _currentFilePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemFile_DropDownOpening(object sender, EventArgs e)
        {
            saveAsToolStripMenuItem.Enabled = string.IsNullOrEmpty(_currentFilePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemSaveAs_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Contour File(*.ctr)|*.ctr";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var contourFile = new FileManager.ContourFile();
                    contourFile.ModelImage = _currentOpendImage == null ? null : new Bitmap(_currentOpendImage);
                    foreach (var point in _commandManager.Points)
                    {
                        contourFile.Points.Add(new Point(point.X, point.Y));
                    }
                    FileManager.Instance.SaveFile(contourFile, sfd.FileName);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemUndo_Click(object sender, EventArgs e)
        {
            if (_commandManager.UndoCommand())
            {
                SelectPoint(null);
                UpdateAll();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemRedo_Click(object sender, EventArgs e)
        {
            if (_commandManager.RedoCommand())
            {
                SelectPoint(null);
                UpdateAll();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            SelectPoint(null);
            _commandManager.Clear();
            UpdateAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemOpenImage_Click(object sender, EventArgs e)
        {
            _currentOpendImage = OpenImage();
            UpdateCanvas();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemAutoContour_Click(object sender, EventArgs e)
        {
            using (var dialog = new FormImageContour())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _commandManager.Clear();

                    CvPoint[] contour = new CvPoint[dialog.Vertices - 1];
                    {
                        var baseData = new IplImage(dialog.FileName, LoadMode.GrayScale);
                        var outputSize = Math.Max(baseData.Width, baseData.Height) * 2;

                        Mat output = new Mat(new OpenCvSharp.CPlusPlus.Size(outputSize, outputSize), MatType.CV_8U, new Scalar(1));

                        var ListOfListOfPoint = new List<OpenCvSharp.CPlusPlus.Point[]>();
                        var points = new List<OpenCvSharp.CPlusPlus.Point>();
                        points.Add(new OpenCvSharp.CPlusPlus.Point(0, 0));
                        points.Add(new OpenCvSharp.CPlusPlus.Point(0, output.Height));
                        points.Add(new OpenCvSharp.CPlusPlus.Point(output.Width, output.Height));
                        points.Add(new OpenCvSharp.CPlusPlus.Point(output.Width, 0));
                        ListOfListOfPoint.Add(points.ToArray());
                        output.FillPoly(ListOfListOfPoint.ToArray(), Scalar.White);

                        var src = output.ToIplImage();
                        src.DrawImage(baseData.Size.Width / 2, baseData.Size.Height / 2, baseData.Size.Width, baseData.Size.Height, baseData);

                        CvPoint center = new CvPoint(src.Width / 2, src.Height / 2);
                        for (int i = 0; i < contour.Length; i++)
                        {
                            contour[i].X = (int)(center.X * Math.Cos(2 * Math.PI * i / contour.Length) + center.X);
                            contour[i].Y = (int)(center.Y * Math.Sin(2 * Math.PI * i / contour.Length) + center.Y);
                        }

                        for (int i = 0; i < dialog.Loops * 100; ++i)
                        {
                            src.SnakeImage(contour, dialog.Alpha, dialog.Beta, dialog.Gammma, new CvSize(15, 15), new CvTermCriteria(1), false);

#if false
                            IplImage dst = new IplImage(src.Size, BitDepth.U8, 3);
                            src.CvtColor(dst, ColorConversion.GrayToRgb);

                            for (int j = 0; j < contour.Length - 1; j++)
                            {
                                dst.Line(contour[j], contour[j + 1], new CvColor(255, 0, 0), 2);
                            }
                            dst.Line(contour[contour.Length - 1], contour[0], new CvColor(255, 0, 0), 2);
                            w.Image = dst;
                            int key = CvWindow.WaitKey();
#endif
                        }
                    }
                    foreach (var point in contour)
                    {
                        _commandManager.AddPoint(new Point(point.X, point.Y));
                    }

                    var first = contour.First();
                    _commandManager.AddPoint(new Point(first.X, first.Y));

                    _currentOpendImage = Bitmap.FromFile(dialog.FileName);

                    UpdateAll();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listView = (ListView)sender;

            _selectedPoint = null;

            if (listView.SelectedItems.Count > 0)
            {
                var item = listView.SelectedItems[0];
                _selectedPoint = (Point)item.Tag;
            }

            UpdateCanvas();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarCanvasScaling_Scroll(object sender, EventArgs e)
        {
            var trackBar = (TrackBar)sender;

            CanvasScaling = 0.8f + (trackBar.Value * 0.2f);
            UpdateCanvas();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectColor_Click(object sender, EventArgs e)
        {
            using(var cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    buttonSelectColor.BackColor = cd.Color;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonCodeStyleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Bitmap OpenImage()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image File(*.bmp,*.jpg,*.png,*.tif)|*.bmp;*.jpg;*.png;*.tif|Bitmap(*.bmp)|*.bmp|Jpeg(*.jpg)|*.jpg|PNG(*.png)|*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (var fs = new System.IO.FileStream(ofd.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        return new Bitmap(fs);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        private void SelectPoint(Point point)
        {
            _selectedPoint = point;

            listViewPoints.SelectedItems.Clear();

            foreach (ListViewItem item in listViewPoints.Items)
            {
               if (item.Tag == point)
                {
                    item.Selected = true;
                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        private void UpdateCanvas(Image image)
        {
            var canvas = pictureBoxCanvas;
            canvas.Image?.Dispose();

            var bitmap = new Bitmap(canvas.Width, canvas.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                g.DrawImage(image, new PointF(canvas.Width * 0.5f - image.Width * 0.5f, canvas.Height * 0.5f - image.Height * 0.5f));
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
        private readonly Color DefaultPenColor = Color.Red;

        /// <summary>
        /// 
        /// </summary>
        private float CanvasScaling { get; set; }

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
        private string _currentFilePath;

        /// <summary>
        /// 
        /// </summary>
        private Point _selectedPoint;

        /// <summary>
        /// 
        /// </summary>
        private Image _currentOpendImage;

        /// <summary>
        /// 
        /// </summary>
        private Point _currentPoint;

        /// <summary>
        /// 
        /// </summary>
        private Point _moveStartPoint;

        /// <summary>
        /// 
        /// </summary>
        private Point _offsetStartPoint;

        /// <summary>
        /// 
        /// </summary>
        private Point _offsetCurrentPoint;

        /// <summary>
        /// 
        /// </summary>
        private string _formDefaultTitle;
    }
}
