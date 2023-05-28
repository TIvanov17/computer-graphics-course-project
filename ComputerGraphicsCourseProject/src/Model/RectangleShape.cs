using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
	/// <summary>
	/// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
	/// </summary>
	[Serializable]
	public class RectangleShape : Shape
	{
		#region Constructor
		
		public RectangleShape(RectangleF rect) : base(rect)
		{
		}
		
		public RectangleShape(RectangleShape rectangle) : base(rectangle)
		{
		}
		
		#endregion

		public override bool Contains(PointF point)
		{
			PointF[] pointsArray = { point };

			TransformationMatrix.Matrix.Invert();
			TransformationMatrix.Matrix.TransformPoints(pointsArray);
			TransformationMatrix.Matrix.Invert();

			return base.Contains(pointsArray[0]);
		}
		
		public override void DrawSelf(Graphics grfx)
		{
			
			base.DrawSelf(grfx);

			FillColor = Color.FromArgb(OpacityValue, FillColor);

			var state = grfx.Save();

			grfx.Transform = TransformationMatrix.Matrix;

			grfx.FillRectangle(
					new SolidBrush(FillColor), 
					Rectangle.X, 
					Rectangle.Y, 
					Rectangle.Width, 
					Rectangle.Height
			);
			
			grfx.DrawRectangle(
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
			return new RectangleShape(this);
		}
	}
}
