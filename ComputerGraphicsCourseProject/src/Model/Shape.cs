using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{

	// binary format file stream save, wrapper of matrix
	// file stream, binary, deserialize cast to shape list

	/// <summary>
	/// Базовия клас на примитивите, който съдържа общите характеристики на примитивите.
	/// </summary>
	[Serializable]
	public abstract class Shape : ICloneable
	{
		public enum Type
        {
			GROUP, SINGLE
        }

		#region Constructors
		
		public Shape()
		{
		}
		
		public Shape(RectangleF rect)
		{
			rectangle = rect;
		}
		
		public Shape(Shape shape)
		{
			rectangle = shape.rectangle;
			Height = shape.Height;
			Width = shape.Width;
			Location = shape.Location;
			FillColor =  shape.FillColor;
		}
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Обхващащ правоъгълник на елемента.
		/// </summary>
		private RectangleF rectangle;
		
		public virtual RectangleF Rectangle {
			get { return rectangle; }
			set { rectangle = value; }
		}

		private Type shapeType = Type.SINGLE;
		public virtual Type ShapeType
		{
			get { return shapeType; }
			protected set { shapeType = value; }
		}

		public virtual float Width {
			get { return Rectangle.Width; }
			set { rectangle.Width = value; }
		}
		
		public virtual float Height {
			get { return Rectangle.Height; }
			set { rectangle.Height = value; }
		}

		public virtual PointF Location {
			get { return Rectangle.Location; }
			set { rectangle.Location = value; }
		}

		private Color fillColor = Color.White;		
		public virtual Color FillColor {
			get { return fillColor; }
			set { fillColor = value; }
		}

		private Color strokeColor = Color.Black;

		public virtual Color StrokeColor {
			get { return strokeColor; }
			set { strokeColor = value; }
		}

		private int strokeWidth = 1;

		public virtual int StrokeWidth
		{
			get { return strokeWidth; }
			set { strokeWidth = value; }
		}

		private int opacityValue = 255;

		public virtual int OpacityValue
		{
			get { return opacityValue; }
			set { opacityValue = value; }
		}

		public Matrix transformationMatrix = new Matrix();

		public virtual Matrix TransformationMatrix
        {
			get { return transformationMatrix; }
			set { transformationMatrix = value; }
		}

		#endregion

		public virtual bool Contains(PointF point)
		{
			return Rectangle.Contains(point.X, point.Y);
		}

		public virtual void DrawSelf(Graphics grfx)
		{
			// shape.Rectangle.Inflate(shape.BorderWidth, shape.BorderWidth);
		}

        public abstract object Clone();
    }
}
