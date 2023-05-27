using System;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace Draw.src.Model
{
    [Serializable]
    public class SerializableMatrix : ISerializable
    {
        [NonSerializedAttribute]
     
        public Matrix matrix;
      
        public float[] Elements { set; get; }
      
        public virtual Matrix Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        public SerializableMatrix()
        {
            matrix = new Matrix();
        }

        public SerializableMatrix(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
    

            Elements = (float[])info.GetValue("Elements", new float[6].GetType());

            Matrix = new Matrix(Elements[0], Elements[1], 
                Elements[2], Elements[3],Elements[4], Elements[5]);
        }

        void ISerializable.GetObjectData(SerializationInfo oInfo, StreamingContext oContext)
        {
            oInfo.AddValue("Elements", Matrix.Elements);
        }
    }
}
