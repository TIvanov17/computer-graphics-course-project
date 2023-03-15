using System;
using System.Collections.Generic;
using System.Drawing;

namespace Draw
{
	/// <summary>
	/// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
	/// </summary>
	public class GroupShape : Shape
	{
		public List<Shape> SubShapes = new List<Shape>();

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
			foreach(Shape currenctShape in SubShapes)
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
