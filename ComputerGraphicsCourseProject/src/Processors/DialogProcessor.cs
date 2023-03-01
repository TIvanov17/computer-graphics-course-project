﻿using System;
using System.Drawing;
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
		
		/// <summary>
		/// Избран елемент.
		/// </summary>
		private Shape selection;
		public Shape Selection {
			get { return selection; }
			set { selection = value; }
		}
		
		/// <summary>
		/// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
		/// </summary>
		private bool isDragging;
		public bool IsDragging {
			get { return isDragging; }
			set { isDragging = value; }
		}
		
		/// <summary>
		/// Последна позиция на мишката при "влачене".
		/// Използва се за определяне на вектора на транслация.
		/// </summary>
		private PointF lastLocation;
		public PointF LastLocation {
			get { return lastLocation; }
			set { lastLocation = value; }
		}
		
		#endregion
		
		/// <summary>
		/// Добавя примитив - правоъгълник на произволно място върху клиентската област.
		/// </summary>
/*		public void AddRandomRectangle()
		{
			Random rnd = Utility.GetRandomGenerator();
			int x = rnd.Next(100,1000);
			int y = rnd.Next(100,600);
			
			RectangleShape rect = new RectangleShape(new Rectangle(x,y,100,200));
			rect.FillColor = Color.White;

			ShapeList.Add(rect);
		}*/

		public void AddRandomRectangle(int strokeWidth)
		{
			Random rnd = Utility.GetRandomGenerator();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			RectangleShape rect = new RectangleShape(new Rectangle(x, y, 100, 200));
			rect.FillColor = Color.White;
			rect.StrokeWidth = strokeWidth;

			ShapeList.Add(rect);
		}

		public void AddRandomSquare(int strokeWidth)
        {
			Random rnd = Utility.GetRandomGenerator();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			SquareShape square = new SquareShape(new Rectangle(x, y, 100, 100));
			square.FillColor = Color.White;
			square.StrokeWidth = strokeWidth;

			ShapeList.Add(square);
		}

		public void AddRandomEllipse(int strokeWidth)
		{
			Random rnd = Utility.GetRandomGenerator();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			EllipseShape ellipse = new EllipseShape(new Rectangle(x, y, 100, 200));
			ellipse.FillColor = Color.White;
			ellipse.StrokeWidth = strokeWidth;

			ShapeList.Add(ellipse);
		}

		public void AddRandomStar(int strokeWidth)
		{
			Random rnd = Utility.GetRandomGenerator();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			TriangleShape star = new TriangleShape(new Rectangle(x, y, 100, 200));
			star.FillColor = Color.White;
			star.StrokeWidth = strokeWidth;

			ShapeList.Add(star);
		}

		public void AddRandomPentagon(int strokeWidth)
        {
			Random rnd = Utility.GetRandomGenerator();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			PentagonShape star = new PentagonShape(new Rectangle(x, y, 100, 200));
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
			for(int i = ShapeList.Count - 1; i >= 0; i--){
				if (ShapeList[i].Contains(point)){
					
					// selection color
					//ShapeList[i].FillColor = Color.Red;
					return ShapeList[i];
				}	
			}
			return null;
		}
		
		/// <summary>
		/// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
		/// </summary>
		/// <param name="p">Вектор на транслация.</param>
		public void TranslateTo(PointF p)
		{
			if (selection != null) {

				selection.Location = new PointF
					(selection.Location.X + p.X - lastLocation.X, 
					selection.Location.Y + p.Y - lastLocation.Y);

				lastLocation = p;
			}
		}

		public override void Draw(Graphics grfx)
		{
		  
			base.Draw(grfx);

			// draw Selection Box
			float[] dashValues = { 4, 2 };
			Pen dashPen = new Pen(Color.Black, 2);
			dashPen.DashPattern = dashValues;

			if(Selection != null)
			{
				grfx.DrawRectangle(
					dashPen,
					Selection.Location.X - 3,
					Selection.Location.Y - 3,
					Selection.Width + 6,
					Selection.Height + 6
				);
			}
		}

		public void SetStrokeColor(Color color)
		{
			if(Selection != null)
			{
				Selection.StrokeColor = color;
			}
		}

		public void SetFillColor(Color color)
		{
			if (Selection != null)
			{
				Selection.FillColor = color;
			}

		}

		public void SetStrokeWidth(int strokeWidth)
		{
			if (Selection != null)
			{
				Selection.StrokeWidth = strokeWidth;
			}

		}

		public void SetOpaciry(int opacityValue)
		{
			if (Selection != null)
			{
				Selection.OpacityValue = opacityValue;
			}
		}


	}
}