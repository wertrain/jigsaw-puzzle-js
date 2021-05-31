using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace PiecePathMakerLib
{
    public class PiecePathMaker
    {
        /// <summary>
        /// 
        /// </summary>
        public class Point
        {
            /// <summary>
            /// 
            /// </summary>
            public int X { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int Y { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Point> MakePointsFromFile(string fileName)
        {
            var points = new List<Point>();

            IplImage src = new IplImage(fileName, LoadMode.GrayScale);
            IplImage dst = new IplImage(src.Size, BitDepth.U8, 3);

            CvPoint[] contour = new CvPoint[100];

            CvPoint center = new CvPoint(src.Width / 2, src.Height / 2);
            for (int i = 0; i < contour.Length; i++)
            {
                contour[i].X = (int)(center.X * Math.Cos(2 * Math.PI * i / contour.Length) + center.X);
                contour[i].Y = (int)(center.Y * Math.Sin(2 * Math.PI * i / contour.Length) + center.Y);
            }

            CvWindow w = new CvWindow();
            while (true)
            {
                src.SnakeImage(contour, 0.8f, 0.0f, 0.3f, new CvSize(15, 15), new CvTermCriteria(1), true);
                src.CvtColor(dst, ColorConversion.GrayToRgb);
                for (int i = 0; i < contour.Length - 1; i++)
                {
                    dst.Line(contour[i], contour[i + 1], new CvColor(255, 0, 0), 2);
                }
                dst.Line(contour[contour.Length - 1], contour[0], new CvColor(255, 0, 0), 2);
                w.Image = dst;
                int key = CvWindow.WaitKey();
                if (key == 27)
                {
                    break;
                }
            }

            return points;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="outputFilePath"></param>
        public void DebugBitmap(List<Point> points, string outputFilePath)
        {
            using (Bitmap bitmap = new Bitmap(512, 512))
            {
                foreach (var point in points)
                {
                    bitmap.SetPixel(point.X, point.Y, Color.Black);
                }

                bitmap.Save(outputFilePath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
