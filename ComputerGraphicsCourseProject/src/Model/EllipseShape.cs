using System;
using System.Drawing;

namespace Draw.src.Model
{
	[Serializable]
	class EllipseShape : Shape
    {

		public EllipseShape(RectangleF rect) : base(rect)
		{
		}

		public EllipseShape(EllipseShape ellipse) : base(ellipse)
		{
		}

		public override bool Contains(PointF point)
		{
			PointF[] pointsArray = { point };

			TransformationMatrix.Matrix.Invert();
			TransformationMatrix.Matrix.TransformPoints(pointsArray);
			TransformationMatrix.Matrix.Invert();

			float width = Rectangle.Width / 2;
			float height = Rectangle.Height / 2;

			float centerX = Rectangle.X + width;
			float centerY = Rectangle.Y + height;

			bool isPointInsideEllipse = (Math.Pow(pointsArray[0].X - centerX, 2)) / (width * width)
				+ (Math.Pow(pointsArray[0].Y - centerY, 2)) / ( height * height ) <= 1;

			return isPointInsideEllipse;
		}

		public override void DrawSelf(Graphics grfx)
		{

			base.DrawSelf(grfx);

			// set opacity value to current fill color
			FillColor = Color.FromArgb(OpacityValue, FillColor);

			var state = grfx.Save();


			grfx.Transform = TransformationMatrix.Matrix;

			grfx.FillEllipse(
					new SolidBrush(FillColor),
					Rectangle.X,
					Rectangle.Y,
					Rectangle.Width,
					Rectangle.Height
			);
			
			grfx.DrawEllipse(
					new Pen(StrokeColor, StrokeWidth),
					Rectangle.X,
					Rectangle.Y,
					Rectangle.Width,
					Rectangle.Height
			);

			grfx.Restore(state);
		}
		public override object Clone()
		{
			return new EllipseShape(this);
		}

	}
}
