using System;
using System.Drawing;


namespace Draw.src.Model
{
	[Serializable]
	class Line : Shape
    {

		public Line(RectangleF rect) : base(rect)
        {
        }

        public Line(Line line) : base(line)
        {
        }


		public override void DrawSelf(Graphics grfx)
		{

			base.DrawSelf(grfx);

			PointF[] points = new PointF[2];

			int currentX = (int)Rectangle.X;
			int currentY = (int)Rectangle.Y;

			points[0] = new Point(currentX, currentY + 15);
			points[1] = new Point(currentX + 200, currentY + 15);

			FillColor = Color.FromArgb(OpacityValue, FillColor);
			grfx.Transform = TransformationMatrix.Matrix;

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
            return new Line(this);
        }
    }
}
