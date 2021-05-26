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
        public List<Point> MakePointsFromFile(string fileName)
        {
            var points = new List<Point>();

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
