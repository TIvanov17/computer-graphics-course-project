using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{

	public class GroupShape : Shape
	{
		public List<Shape> SubShapes = new List<Shape>();

		// TODO: rest of every functionality
		public override object Clone()
		{
			throw new System.NotImplementedException();
		}
		public override Matrix TransformationMatrix
		{
			get => base.TransformationMatrix;
			set 
			{
				base.TransformationMatrix.Multiply(value);

				foreach (Shape currentSubShape in SubShapes)
				{
					currentSubShape.TransformationMatrix.Multiply(value);
				}
			}
		}

		public override Color FillColor
		{
			get => base.FillColor;
			set 
			{
				foreach (Shape currentSubShape in SubShapes)
				{
					currentSubShape.FillColor = value;
				}
			}
		}

		public override Color StrokeColor
		{
			get => base.StrokeColor;
			set
			{
				foreach (Shape currentSubShape in SubShapes)
				{
					currentSubShape.StrokeColor = value;
				}
			}
		}

		public override int StrokeWidth
		{
			get => base.StrokeWidth;
			set 
			{
				foreach (Shape currentSubShape in SubShapes)
				{
					currentSubShape.StrokeWidth = value;
				}
			}
		}

		public override PointF Location
		{
			get => base.Location;

			set
            {

				foreach (Shape currentSubShape in SubShapes)
                {
					currentSubShape.Location = new PointF(
					 currentSubShape.Location.X - Location.X + value.X,
						currentSubShape.Location.Y - Location.Y + value.Y
					);	
				}

                base.Location = new PointF(
                    value.X,
                    value.Y
                );

            }
		}

		#region Constructor

		public GroupShape(RectangleF rect) : base(rect)
		{
		}
		
		public GroupShape(GroupShape groupShape) : base(groupShape)
		{
		}
		
		#endregion

		public override bool Contains(PointF point)
		{

			foreach (Shape currenctShape in SubShapes)
            {
                if (currenctShape.Contains(point))
                {
					return true;
                }
            }	
			
			return false;
		}
		
		public override void DrawSelf(Graphics grfx)
		{

			foreach (Shape currenctShape in SubShapes)
			{
				currenctShape.DrawSelf(grfx);
			}

		}


	}
}
