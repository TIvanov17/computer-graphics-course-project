using System;
using System.Drawing;


namespace Draw.src.Model
{
	[Serializable]
	class PentagonShape : Shape
    {
		public PentagonShape(RectangleF rect) : base(rect)
		{
		}

		public PentagonShape(PentagonShape star) : base(star)
		{
		}

		public override bool Contains(PointF point)
		{

			return base.Contains(point);
		}

		public override void DrawSelf(Graphics grfx)
		{

			base.DrawSelf(grfx);

			PointF[] points = new PointF[5];

			int currentX = (int)Rectangle.X;
			int currentY = (int)Rectangle.Y;

			points[0] = new Point(currentX, currentY + 75);
			points[1] = new Point(currentX + 50, currentY + 150);
			points[2] = new Point(currentX + 140, currentY + 150);
			points[3] = new Point(currentX + 190, currentY + 75);
			points[4] = new Point(currentX + 95, currentY);

			FillColor = Color.FromArgb(OpacityValue, FillColor);

			grfx.FillPolygon(
					new SolidBrush(FillColor),
					points
			);

			grfx.DrawPolygon(
					new Pen(StrokeColor, StrokeWidth),
					points
			);
		}

		public override object Clone()
		{
			return new PentagonShape(this);
		}

	}
}
