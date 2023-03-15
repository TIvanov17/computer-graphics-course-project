using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Draw.src.Model;
using Draw.Util;

namespace Draw
{
	/// <summary>
	/// Класът, който ще бъде използван при управляване на диалога.
	/// </summary>
	public class DialogProcessor : DisplayProcessor
	{
		#region Constructor

		public DialogProcessor()
		{
		}

		#endregion

		#region Properties
		
		private List<Shape> selection = new List<Shape>();

		public List<Shape> Selection
		{
			get { return selection; }
			set { selection = value; }
		}

		/// <summary>
		/// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
		/// </summary>
		private bool isDragging;
		public bool IsDragging
		{
			get { return isDragging; }
			set { isDragging = value; }
		}

		/// <summary>
		/// Последна позиция на мишката при "влачене".
		/// Използва се за определяне на вектора на транслация.
		/// </summary>
		private PointF lastLocation;
		public PointF LastLocation
		{
			get { return lastLocation; }
			set { lastLocation = value; }
		}

		#endregion

		public void AddGroupShape(int strokeWidth)
        {
			RectangleF rectangleF = DrawGroupShapeRectangle();
			GroupShape groupShape = new GroupShape(rectangleF);
			
			groupShape.FillColor = Color.White;
			groupShape.StrokeWidth = strokeWidth;
			groupShape.SubShapes.AddRange(Selection);

			ShapeList.Add(groupShape);
		}

		public void AddRandomRectangle(int strokeWidth)
		{
			Rectangle rectangle = DrawRectangle(100, 200);
			RectangleShape rect = new RectangleShape(rectangle);
			rect.FillColor = Color.White;
			rect.StrokeWidth = strokeWidth;

			ShapeList.Add(rect);
		}

		public void AddRandomSquare(int strokeWidth)
		{
			Rectangle rectangle = DrawRectangle(100, 100);

			SquareShape square = new SquareShape(rectangle);
			square.FillColor = Color.White;
			square.StrokeWidth = strokeWidth;

			ShapeList.Add(square);
		}

		public void AddRandomEllipse(int strokeWidth)
		{
			Rectangle rectangle = DrawRectangle(100, 200);

			EllipseShape ellipse = new EllipseShape(rectangle);
			ellipse.FillColor = Color.White;
			ellipse.StrokeWidth = strokeWidth;

			ShapeList.Add(ellipse);
		}

		public void AddRandomStar(int strokeWidth)
		{
			Rectangle rectangle = DrawRectangle(100, 200);
			TriangleShape star = new TriangleShape(rectangle);
			star.FillColor = Color.White;
			star.StrokeWidth = strokeWidth;

			ShapeList.Add(star);
		}

		public void AddRandomPentagon(int strokeWidth)
		{
			Rectangle rectangle = DrawRectangle(100, 200);
			PentagonShape star = new PentagonShape(rectangle);
			star.FillColor = Color.White;
			star.StrokeWidth = strokeWidth;

			ShapeList.Add(star);
		}


		/// <summary>
		/// Проверява дали дадена точка е в елемента.
		/// Обхожда в ред обратен на визуализацията с цел намиране на
		/// "най-горния" елемент т.е. този който виждаме под мишката.
		/// </summary>
		/// <param name="point">Указана точка</param>
		/// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
		public Shape ContainsPoint(PointF point)
		{
			for (int i = ShapeList.Count - 1; i >= 0; i--)
			{
				if (ShapeList[i].Contains(point))
				{
					// selection color
					//ShapeList[i].FillColor = Color.Red;
					return ShapeList[i];
				}
			}

			return null;
		}

		/// <summary>
		/// Транслация на избраният елемент на вектор определен от 
		/// <paramref name="p>p</paramref>
		/// </summary>
		/// <param name="p">Вектор на транслация.</param>
		public void TranslateTo(PointF p)
		{
			if (selection.Count > 0)
			{
				PointF[] pointsArray = { p };

				foreach (Shape selectedShape in Selection)
                {
					selectedShape.TransformationMatrix.Invert();
					selectedShape.TransformationMatrix.TransformPoints(pointsArray);
					selectedShape.TransformationMatrix.Invert();

					selectedShape.Location = new PointF
						(selectedShape.Location.X + pointsArray[0].X - lastLocation.X,
						selectedShape.Location.Y + pointsArray[0].Y - lastLocation.Y);
				}

				lastLocation = pointsArray[0];
			}
		}

		public override void Draw(Graphics grfx)
		{
			base.Draw(grfx);

			// draw Selection Box
			float[] dashValues = { 4, 2 };
			Pen dashPen = new Pen(Color.Black, 2);
			dashPen.DashPattern = dashValues;

			if (Selection.Count > 0)
			{
				foreach(Shape selectedShape in Selection){
					//grfx.Transform = Selection.TransformationMatrix;
					grfx.DrawRectangle(
						dashPen,
						selectedShape.Location.X - 3,
						selectedShape.Location.Y - 3,
						selectedShape.Width + 6,
						selectedShape.Height + 6
					);

				}
			}
		}

		public void SetStrokeColor(Color color)
		{
			if (Selection.Count > 0)
			{
				foreach(Shape selectedShape in Selection)
                {
					selectedShape.StrokeColor = color;
				}
			}
		}

		public void SetFillColor(Color color)
		{
			if (Selection.Count > 0)
			{
				foreach (Shape selectedShape in Selection) { 
					selectedShape.FillColor = color;
				}
			}
		}

		public void SetStrokeWidth(int strokeWidth)
		{
			if (Selection.Count > 0)
			{
				foreach(Shape selectedShape in Selection)
                {
					selectedShape.StrokeWidth = strokeWidth;
				}
			}
		}

		public void SetOpacity(int opacityValue)
		{
			if (Selection.Count > 0)
			{
				foreach(Shape selectedShape in Selection)
                {
					selectedShape.OpacityValue = opacityValue;
				}
			}
		}

		public void RotateShape(int angle)
		{
			if (Selection.Count > 0)
			{
				foreach(Shape selectionShape in Selection)
                {
					selectionShape.TransformationMatrix.RotateAt(
						angle,
						new PointF(
							selectionShape.Location.X + selectionShape.Width / 2,
							selectionShape.Location.Y + selectionShape.Height / 2
						)
					);

				}
			}
		}

		public void ScaleShape(float scaleFactorX, float scaleFactorY)
		{
			if (Selection.Count > 0)
			{
				foreach (Shape selectedShape in Selection)
                {
					selectedShape.TransformationMatrix.Scale(scaleFactorX, scaleFactorY);
				}

			}
		}

		private RectangleF DrawGroupShapeRectangle()
		{
			float minX = float.MaxValue;
			float minY = float.MaxValue;

			float maxX = float.MinValue;
			float maxY = float.MinValue;

			foreach (Shape shape in Selection)
			{

				float currentX = shape.Location.X + shape.Width;
				float currentY = shape.Location.Y + shape.Height;

				if (shape.Location.X < minX)
				{
					minX = shape.Location.X;
				}

				if (shape.Location.Y < minY)
				{
					minY = shape.Location.Y;
				}

				if (currentX > maxX)
				{
					maxX = currentX;
				}

				if (currentY > maxY)
				{
					maxY = currentY;
				}
			}

			return new RectangleF(minX, minY, maxX - minX, maxY - minY);
		}

		private Rectangle DrawRectangle(int width, int heith)
		{
			int x = Utility.GenerateRandomNumber(100, 1000);
			int y = Utility.GenerateRandomNumber(100, 600);

			return new Rectangle(x, y, width, heith);
		}
	}
}
