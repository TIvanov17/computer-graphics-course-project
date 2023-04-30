using Draw.src.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{

	[Serializable]
	public class GroupShape : Shape
	{
		public List<Shape> SubShapes = new List<Shape>();

		public override SerializableMatrix TransformationMatrix
		{
			get => base.TransformationMatrix;
			set 
			{
				base.TransformationMatrix.transformationMatrix.Multiply(value.transformationMatrix);

				foreach (Shape currentSubShape in SubShapes)
				{
					currentSubShape.TransformationMatrix.transformationMatrix.Multiply(value.transformationMatrix);
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

        public override int OpacityValue
		{
			get => base.OpacityValue;

			set
			{
				foreach (Shape currentSubShape in SubShapes)
				{
					currentSubShape.OpacityValue = value;
				}
			}
		}

        #region Constructor

        public GroupShape(RectangleF rect) : base(rect)
		{
			ShapeType = Type.GROUP;
		}

		public GroupShape(GroupShape groupShape) : base(groupShape)
		{
			ShapeType = Type.GROUP;
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

		public override object Clone()
		{
			GroupShape groupShape = new GroupShape(this);
			foreach(Shape subShape in this.SubShapes)
            {
				groupShape.SubShapes.Add((Shape)subShape.Clone());
            }

			return groupShape;
		}
	}
}
