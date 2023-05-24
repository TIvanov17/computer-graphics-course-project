using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Draw.src.Util
{
    class ModelSaver
    {
        private ModelSaver() { }

        public static void SaveModel(string fileName, List<Shape> dataCollection)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            FileStream fileStream =
                new FileStream(fileName, FileMode.Create);

            binaryFormatter.Serialize(fileStream, dataCollection);

            fileStream.Close();
        }

        public static List<Shape> UploadModel(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open);

            BinaryFormatter formatter = new BinaryFormatter();

            List<Shape> dataCollection = (List<Shape>)formatter.Deserialize(fileStream);

            fileStream.Close();
            return dataCollection;
        }

    }
}
