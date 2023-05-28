using System;
using System.Drawing;
using System.Windows.Forms;

namespace Draw.src.Model
{
	[Serializable]
	class TriangleShape : Shape
    {
		private PointF[] points = new PointF[3];

		public TriangleShape(RectangleF rect) : base(rect)
		{
		}

		public TriangleShape(TriangleShape triangle) : base(triangle)
		{
		}


        public override bool Contains(PointF point)
		{

			PointF[] pointsArray = { point };

			TransformationMatrix.Matrix.Invert();
			TransformationMatrix.Matrix.TransformPoints(pointsArray);
			TransformationMatrix.Matrix.Invert();


            /*            double A = FindArea(points[0], points[1], points[2]);

                        double A1 = FindArea(pointsArray[0], points[1], points[2]);

                        double A2 = FindArea(points[0], pointsArray[0], points[2]);

                        double A3 = FindArea(points[0], points[1], pointsArray[0]);

                        return (A == A1 + A2 + A3);*/

            PointF startPoint = pointsArray[0];

            double sum = 0;

            for (int i = 0; i < points.Length; i++)
            {
                PointF P2 = points[i];
                PointF P3 = i == points.Length - 1 ? points[0] : points[i + 1];

                double angleInRadians = Math.Atan2(P2.Y - startPoint.Y, P2.X - startPoint.X) -
                                        Math.Atan2(P3.Y - startPoint.Y, P3.X - startPoint.X);

                double angleInDegree = 360 * angleInRadians / (2 * Math.PI);

                if (angleInDegree <= -180 && angleInDegree >= -270)
                {
                    angleInDegree = 360 + angleInDegree;
                }

                sum += angleInDegree;
            }

            return sum == 360;
        }

		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);

			int currentX = (int) Rectangle.X;
			int currentY = (int) Rectangle.Y;

			points[0] = new Point(currentX, currentY);
			points[1] = new Point(currentX + 50, currentY + 100);
			points[2] = new Point(currentX + 100, currentY + 0);

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
			return new TriangleShape(this);
		}

		private double FindArea(PointF first, PointF second, PointF third)
		{
			return Math.Abs((first.X * (second.Y - third.Y) +
						second.X * (third.Y - first.Y) +
						third.X * (first.Y - second.Y)) / 2.0);
		}
	}
}
