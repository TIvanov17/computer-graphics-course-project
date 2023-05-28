using System;
using System.Drawing;


namespace Draw.src.Model
{
	[Serializable]
	class StarShape : Shape
    {
		private PointF[] points = new PointF[8];

		public StarShape(RectangleF rect) : base(rect)
		{
		}

		public StarShape(StarShape star) : base(star)
		{
		}


		public override bool Contains(PointF point)
		{
			PointF[] pointsArray = { point };

			TransformationMatrix.Matrix.Invert();
			TransformationMatrix.Matrix.TransformPoints(pointsArray);
			TransformationMatrix.Matrix.Invert();

			bool result = false;
			for (int i = 0; i < points.Length - 1; i++)
			{

				bool checkForY = points[i].Y < pointsArray[0].Y && points[i + 1].Y >= pointsArray[0].Y ||
							points[i + 1].Y < pointsArray[0].Y && points[i].Y >= pointsArray[0].Y;

				bool checkForX = points[i].X + (pointsArray[0].Y - points[i].Y) /
						(points[i + 1].Y - points[i].Y) * (points[i + 1].X - points[i].X) < pointsArray[0].X;


				if (checkForY && checkForX)
				{
					result = !result;
				}
			}

			return result;
		}

		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);

			int currentX = (int)Rectangle.X;
			int currentY = (int)Rectangle.Y;

			points[0] = new Point(currentX, currentY + 50);
			points[1] = new Point(currentX + 40, currentY + 40);
			points[2] = new Point(currentX + 50, currentY);
			points[3] = new Point(currentX + 60, currentY + 40);
			points[4] = new Point(currentX + 100, currentY + 50);
			points[5] = new Point(currentX + 60, currentY + 60);
			points[6] = new Point(currentX + 50, currentY + 100);
			points[7] = new Point(currentX + 40, currentY + 60);

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
			return new StarShape(this);
		}


	}
}
