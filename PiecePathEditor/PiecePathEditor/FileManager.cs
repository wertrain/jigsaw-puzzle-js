using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PiecePathEditor
{
    public class FileManager
    {
        /// <summary>
        /// 
        /// </summary>
        public class ContourFile
        {
            /// <summary>
            /// 
            /// </summary>
            [XmlIgnoreAttribute()]
            public Bitmap ModelImage { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public List<Point> Points { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public ContourFile()
            {
                ModelImage = null;
                Points = new List<Point>();
            }

            /// <summary>
            /// 
            /// </summary>
            [XmlElementAttribute("ModelImage")]
            public byte[] PictureByteArray
            {
                get
                {
                    if (ModelImage != null)
                    {
                        TypeConverter BitmapConverter = TypeDescriptor.GetConverter(ModelImage.GetType());
                        return (byte[])BitmapConverter.ConvertTo(ModelImage, typeof(byte[]));
                    }
                    else
                    {
                        return null;
                    }
                }

                set
                {
                    if (value != null)
                    {
                        ModelImage = new Bitmap(new MemoryStream(value));
                    }
                    else
                    {
                        ModelImage = null;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static FileManager Instance { get; } = new FileManager();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool SaveFile(ContourFile file, string fileName)
        {
            try
            {
                using (var sw = new StreamWriter(fileName, false))
                {
                    var xmlSerializer = new XmlSerializer(typeof(ContourFile));
                    xmlSerializer.Serialize(sw, file);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public ContourFile LoadFile(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            using (var xr = XmlReader.Create(sr))
            {
                var xmlSerializer = new XmlSerializer(typeof(ContourFile));
                return xmlSerializer.Deserialize(xr) as ContourFile;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private FileManager()
        {

        }
    }
}
