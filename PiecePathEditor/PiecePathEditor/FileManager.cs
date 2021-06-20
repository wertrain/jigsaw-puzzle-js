using System;
using System.Collections.Generic;
using System.Drawing;
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
            public Bitmap ModelImage { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public List<Point> Points { get; set; }
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
                using (var xmlWriter = XmlWriter.Create(fileName))
                {
                    var xmlSerializer = new XmlSerializer(typeof(ContourFile));
                    xmlSerializer.Serialize(xmlWriter, file);
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
            using (var xmlReader = XmlReader.Create(fileName))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ContourFile));
                return xmlSerializer.Deserialize(xmlReader) as ContourFile;
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
