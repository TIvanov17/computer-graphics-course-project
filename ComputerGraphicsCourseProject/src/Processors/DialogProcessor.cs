using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using Draw.src.Model;
using Draw.src.Util;
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
		
		private List<Shape> selectedShapesCollection = new List<Shape>();

		public List<Shape> SelectedShapesCollection
		{
			get { return selectedShapesCollection; }
			set { selectedShapesCollection = value; }
		}

		private ISet<Shape> copyOfSelectedShapes = new HashSet<Shape>();

		public ISet<Shape> CopyOfSelectedShapes
		{
			get { return copyOfSelectedShapes; }
			set { copyOfSelectedShapes = value; }
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

		private Color lastPickedColor;
		public Color LastPickedColor
		{
			get { return lastPickedColor; }
			set { lastPickedColor = value; }
		}

		private PointF positionOnRightClickAddShape;
		public PointF PositionOnRightClickAddShape
		{
			get { return positionOnRightClickAddShape; }
			set { positionOnRightClickAddShape = value; }
		}

		private DrawSpecs drawSpecs = new DrawSpecs();
		public DrawSpecs DrawSpecs
		{
			get { return drawSpecs; }
			set { drawSpecs = value; }
		}


		#endregion

		public void AddGroupShape(int strokeWidth)
        {
			RectangleF rectangleF = DrawGroupShapeRectangle();
			GroupShape groupShape = new GroupShape(rectangleF);
			groupShape.StrokeWidth = strokeWidth;

			groupShape.SubShapes.AddRange(SelectedShapesCollection);

			SelectedShapesCollection = new List<Shape>();
			SelectedShapesCollection.Add(groupShape);

			foreach(Shape item in groupShape.SubShapes)
            {
				ShapeList.Remove(item);
            }

			ShapeList.Add(groupShape);
		}


		public void AddRandomRectangle(int strokeWidth)
		{
			Rectangle rectangle = DrawRectangle(100, 200);
			RectangleShape rect = new RectangleShape(rectangle);
			rect.StrokeWidth = strokeWidth;
			ShapeList.Add(rect);
		}

		public void AddRandomSquare(int strokeWidth)
		{
			Rectangle rectangle = DrawRectangle(100, 100);
			RectangleShape square = new RectangleShape(rectangle);
			square.StrokeWidth = strokeWidth;
			ShapeList.Add(square);
		}

		public void AddRandomEllipse(int strokeWidth)
		{
			Rectangle rectangle = DrawRectangle(100, 200);
			EllipseShape ellipse = new EllipseShape(rectangle);
			ellipse.StrokeWidth = strokeWidth;

			ShapeList.Add(ellipse);
		}

		public void AddRandomCircle(int strokeWidth)
		{
			Rectangle rectangle = DrawRectangle(100, 100);
			EllipseShape circle = new EllipseShape(rectangle);
			circle.StrokeWidth = strokeWidth;

			ShapeList.Add(circle);
		}

		public void AddRandomLine(int strokeWidth)
        {
			Rectangle rectangle = DrawRectangle(200, 30);
			Line line = new Line(rectangle);
			line.StrokeWidth = strokeWidth;

			ShapeList.Add(line);
		}

		public void AddRandomTriangle(int strokeWidth)
		{
			Rectangle rectangle = DrawRectangle(100, 100);
			TriangleShape triangle = new TriangleShape(rectangle);
			triangle.StrokeWidth = strokeWidth;

			ShapeList.Add(triangle);
		}

		public void AddRandomPentagon(int strokeWidth)
		{
			Rectangle rectangle = DrawRectangle(190, 150);
			PentagonShape star = new PentagonShape(rectangle);
			star.StrokeWidth = strokeWidth;
			ShapeList.Add(star);
		}

		public void AddRandomStar(int strokeWidth)
		{
			Rectangle rectangle = DrawRectangle(100, 100);
			StarShape star = new StarShape(rectangle);
			star.StrokeWidth = strokeWidth;
			ShapeList.Add(star);
		}

		public void BuildNewShape(int strokeWidth)
        {
			Rectangle rectangle;

			if (DrawSpecs.ShouldDrawOnRandomPosition)
            {
				rectangle = DrawRectangle(100, 100);
			}
            else
            {
				rectangle = new Rectangle(
					(int)DrawSpecs.Position.X - 50,
					(int)DrawSpecs.Position.Y - 70,
					100, 100
				);
			}

			StarShape star = new StarShape(rectangle);
			star.StrokeWidth = strokeWidth;
			ShapeList.Add(star);
		}

		public void AddStar(int strokeWidth)
		{
			if(positionOnRightClickAddShape != null)
            {
				Rectangle rectangle = new Rectangle(
					(int)PositionOnRightClickAddShape.X - 50,
					(int)PositionOnRightClickAddShape.Y - 70, 
					100, 200);
				
				StarShape star = new StarShape(rectangle);
				star.StrokeWidth = strokeWidth;
				ShapeList.Add(star);
			}
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
			if (selectedShapesCollection.Count > 0)
			{
				PointF[] pointsArray = { p };

				foreach (Shape selectedShape in SelectedShapesCollection)
                {
					
					selectedShape.TransformationMatrix.Matrix.Invert();
					selectedShape.TransformationMatrix.Matrix.TransformPoints(pointsArray);
					selectedShape.TransformationMatrix.Matrix.Invert();

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

			if (SelectedShapesCollection.Count > 0)
			{
				foreach(Shape selectedShape in SelectedShapesCollection){

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
			if (SelectedShapesCollection.Count > 0)
			{
				foreach(Shape selectedShape in SelectedShapesCollection)
                {
					selectedShape.StrokeColor = color;
				}
			}
		}

		public void SetFillColor(Color color)
		{
			if (SelectedShapesCollection.Count > 0)
			{
				foreach (Shape selectedShape in SelectedShapesCollection) { 
					selectedShape.FillColor = color;
				}
			}
		}

		public void SetStrokeWidth(int strokeWidth)
		{
			if (SelectedShapesCollection.Count > 0)
			{
				foreach(Shape selectedShape in SelectedShapesCollection)
                {
					selectedShape.StrokeWidth = strokeWidth;
				}
			}
		}

		public void SetOpacity(int opacityValue)
		{
			if (SelectedShapesCollection.Count > 0)
			{
				foreach(Shape selectedShape in SelectedShapesCollection)
                {
					selectedShape.OpacityValue = opacityValue;
				}
			}
		}

		public void RotateShape(int angle)
		{
			if (SelectedShapesCollection.Count > 0)
			{
				foreach(Shape selectedShape in SelectedShapesCollection)
                {

					float[] matrixElements = selectedShape.TransformationMatrix.
						Matrix.Elements;
					
					Matrix newRotatedMatrix = new Matrix(matrixElements[0], matrixElements[1], 
														matrixElements[2], matrixElements[3], 
														matrixElements[4], matrixElements[5]);
					newRotatedMatrix.RotateAt(
						angle,
						new PointF(
							selectedShape.Location.X + selectedShape.Width / 2,
							selectedShape.Location.Y + selectedShape.Height / 2
						)
					);

					selectedShape.TransformationMatrix.Matrix = newRotatedMatrix;
				}
			}
		}

		public void ScaleShape(float scaleFactorX, float scaleFactorY)
		{
			if (SelectedShapesCollection.Count > 0)
			{
				foreach (Shape selectedShape in SelectedShapesCollection)
                {
					selectedShape.TransformationMatrix
						.Matrix.Scale(scaleFactorX, scaleFactorY);
				}
			}
		}

		public void DeleteSelectedShapes()
		{
			foreach (Shape shape in SelectedShapesCollection)
			{
				ShapeList.Remove(shape);
			}

			SelectedShapesCollection.Clear();
		}


		public void UngroupSelectedShapes(List<Shape> groupShapes)
		{
			foreach (Shape shape in groupShapes)
			{
				SelectedShapesCollection.Remove(shape);
				List<Shape> subShapesCollection = ((GroupShape)shape).SubShapes;
				ShapeList.Remove(shape);
				ShapeList.AddRange(subShapesCollection);
			}
		}

		public void CutShapes()
		{
			CopyOfSelectedShapes.Clear();
			foreach (Shape shape in SelectedShapesCollection)
			{
				ShapeList.Remove(shape);
				Shape copyOfCurrentShape = (Shape)shape.Clone();
				CopyOfSelectedShapes.Add(copyOfCurrentShape);
			}
			SelectedShapesCollection.Clear();
		}

		public void CopyShapes()
        {
			CopyOfSelectedShapes.Clear();
			foreach (Shape shape in SelectedShapesCollection)
			{
				Shape copyOfCurrentShape = (Shape)shape.Clone();
				CopyOfSelectedShapes.Add(copyOfCurrentShape);
			}
		}

		public void PasteShapes()
        {
			foreach (Shape shape in CopyOfSelectedShapes)
			{
				Shape newFreshShapeOfCopiedOne = (Shape)shape.Clone();
				ShapeList.Add(newFreshShapeOfCopiedOne);
			}	
		}

		public void SelectAllShapes()
        {
			foreach(Shape shape in ShapeList)
            {
                if (!SelectedShapesCollection.Contains(shape))
                {
					SelectedShapesCollection.Add(shape);
                }
            }
        }

		public void InvertSelection()
        {
			foreach (Shape shape in ShapeList)
			{
				if (SelectedShapesCollection.Contains(shape))
				{
					SelectedShapesCollection.Remove(shape);
					continue;
				}
				SelectedShapesCollection.Add(shape);
			}
		}

		private RectangleF DrawGroupShapeRectangle()
		{
			float minX = float.MaxValue;
			float minY = float.MaxValue;

			float maxX = float.MinValue;
			float maxY = float.MinValue;

			foreach (Shape shape in SelectedShapesCollection)
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

		private Rectangle DrawRectangle(int width, int height)
		{
			int x = Utility.GenerateRandomNumber(100, 1000);
			int y = Utility.GenerateRandomNumber(100, 600);

			return new Rectangle(x, y, width, height);
		}

	}
}
