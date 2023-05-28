using System;
using System.Drawing;
using System.Windows;

namespace Draw.src.Model
{
	[Serializable]
	class PentagonShape : Shape
    {

		private PointF[] points = new PointF[5];

		public PentagonShape(RectangleF rect) : base(rect)
		{
		}

		public PentagonShape(PentagonShape star) : base(star)
		{
		}



		public override bool Contains(PointF point)
		{
			PointF[] pointsArray = { point };

			TransformationMatrix.Matrix.Invert();
			TransformationMatrix.Matrix.TransformPoints(pointsArray);
			TransformationMatrix.Matrix.Invert();

			PointF startPoint = pointsArray[0];
			double sum = 0;

			for (int i = 0; i < points.Length; i++)
			{
				PointF P2 = points[i];
				PointF P3 = i == points.Length - 1 ? points[0] : points[i + 1];

				double angleInRadians = Math.Atan2(P2.Y - startPoint.Y, P2.X - startPoint.X) -
										Math.Atan2(P3.Y - startPoint.Y, P3.X - startPoint.X);

                if (angleInRadians < 0)
                {
                    angleInRadians += (2 * Math.PI);
                }
                if (angleInRadians > Math.PI)
                {
                    angleInRadians = 2 * Math.PI - angleInRadians;
                }

                double angleInDegree = 360 * angleInRadians / (2 * Math.PI);
				
				sum += angleInDegree;

			}

			return sum == 360;
		}

		public override void DrawSelf(Graphics grfx)
		{

			base.DrawSelf(grfx);

			int currentX = (int)Rectangle.X;
			int currentY = (int)Rectangle.Y;

			points[0] = new PointF(currentX, currentY + 75);
			points[1] = new PointF(currentX + 50, currentY + 150);
			points[2] = new PointF(currentX + 140, currentY + 150);
			points[3] = new PointF(currentX + 190, currentY + 75);
			points[4] = new PointF(currentX + 95, currentY);

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
			return new PentagonShape(this);
		}

	}
}
