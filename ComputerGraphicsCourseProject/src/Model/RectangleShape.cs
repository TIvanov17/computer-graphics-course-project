﻿using System;
using System.Drawing;

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

			//TransformationMatrix.Matrix.TransformPoints(new PointF[] { point });
			return base.Contains(pointsArray[0]);
		}
		
		public override void DrawSelf(Graphics grfx)
		{
			
			base.DrawSelf(grfx);
			// set opacity value to current fill color
			FillColor = Color.FromArgb(OpacityValue, FillColor);
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
		}

		public override object Clone()
		{
			return new RectangleShape(this);
		}
	}
}
