using System;
using System.Drawing;

namespace Draw.src.Model
{
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
			float width = Rectangle.Width / 2;
			float height = Rectangle.Height / 2;

			float centerX = Rectangle.X + width;
			float centerY = Rectangle.Y + height;

			bool isPointInsideEllipse = (Math.Pow(point.X - centerX, 2)) / (width * width)
				+ (Math.Pow(point.Y - centerY, 2)) / ( height * height ) <= 1;

			return isPointInsideEllipse;
		}

		public override void DrawSelf(Graphics grfx)
		{

			base.DrawSelf(grfx);

			// set opacity value to current fill color
			FillColor = Color.FromArgb(OpacityValue, FillColor);

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
		}
		public override object Clone()
		{
			return new EllipseShape(this);
		}

	}
}
