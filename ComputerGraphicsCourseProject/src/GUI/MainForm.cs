using Draw.src.Util;
using Draw.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Draw
{
	/// <summary>
	/// Върху главната форма е поставен потребителски контрол,
	/// в който се осъществява визуализацията
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
		/// </summary>
		private DialogProcessor dialogProcessor = new DialogProcessor();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		/// <summary>
		/// Изход от програмата. Затваря главната форма, а с това и програмата.
		/// </summary>
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		
		/// <summary>
		/// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
		/// </summary>
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);
		}
		
		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>
		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomRectangle(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";	
			viewPort.Invalidate();
		}

		/// <summary>
		/// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
		/// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
		/// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
		/// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
		/// </summary>
		void ViewPortMouseDown(object sender, MouseEventArgs e)
		{
			if (pickUpSpeedButton.Checked) {
				
				Shape currentClickedShape = dialogProcessor.ContainsPoint(e.Location);
				
				if (currentClickedShape != null)
                {
                    if (dialogProcessor.SelectedShapesCollection.Contains(currentClickedShape))
                    {
						dialogProcessor.SelectedShapesCollection.Remove(currentClickedShape);
					}
                    else
                    {
						dialogProcessor.SelectedShapesCollection.Add(currentClickedShape);
					}

					statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
					dialogProcessor.IsDragging = true;
					dialogProcessor.LastLocation = e.Location;
					viewPort.Invalidate();
				}

			}
		}

		/// <summary>
		/// Прихващане на преместването на мишката.
		/// Ако сме в режм на "влачене", то избрания елемент се транслира.
		/// </summary>
		void ViewPortMouseMove(object sender, MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging) {
				if (dialogProcessor.SelectedShapesCollection != null) statusBar.Items[0].Text = "Последно действие: Влачене";
				dialogProcessor.TranslateTo(e.Location);
				viewPort.Invalidate();
			}
			mouseCoorinates.Text = "x: " + MousePosition.X + " y: " + MousePosition.Y;
		}

		/// <summary>
		/// Прихващане на отпускането на бутона на мишката.
		/// Излизаме от режим "влачене".
		/// </summary>
		void ViewPortMouseUp(object sender, MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

        private void ChangeFillColorClick(object sender, EventArgs e)
        {
			if (colorDialog2.ShowDialog() == DialogResult.OK)
			{
				lastPickedColor.BackColor = colorDialog2.Color;
				dialogProcessor.SetFillColor(colorDialog2.Color);
				viewPort.Invalidate();
			}
		}

        private void ChangeStrokeColorClick(object sender, EventArgs e)
        {
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				dialogProcessor.SetStrokeColor(colorDialog1.Color);
				viewPort.Invalidate();
			}
		}

		private void ChangeStrokeWidth(object sender, EventArgs e)
		{

            bool canConvert = int.TryParse
                (strokeWidthTextBox.Text, out int resultStrokeWidthValue);

            if (canConvert && resultStrokeWidthValue >= 0)
            {
				dialogProcessor.SetStrokeWidth(resultStrokeWidthValue);
				viewPort.Invalidate();
			}
		}

        private void ChangeOpacityValue(object sender, EventArgs e)
        {
			dialogProcessor.SetOpacity(opacityValue.Value);
			viewPort.Invalidate();
		}

		private void DrawStarShapeButton(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomStar(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на квадрат";
			viewPort.Invalidate();
		}

		private void DrawSquareButtonClick(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomSquare(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на квадрат";
			viewPort.Invalidate();
		}

        private void DrawEllipseShapeButtonClick(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomEllipse(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на елипса";
			viewPort.Invalidate();
		}

        private void DrawPentagonShapeButtonClick(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomPentagon(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на звезда";
			viewPort.Invalidate();
		}

        private void RotateShapeButton(object sender, EventArgs e)
        {
			dialogProcessor.RotateShape(45);
			statusBar.Items[0].Text = "Последно действие: Ротация на фигура";
			viewPort.Invalidate();
		}

        private void ScaleShapeButton(object sender, EventArgs e)
        {
			dialogProcessor.ScaleShape(1.2f, 1.2f);
			statusBar.Items[0].Text = "Последно действие: Мащабиране на фигура";
			viewPort.Invalidate();
		}

        private void DrawGroupShapeButton(object sender, EventArgs e)
        {
			if(dialogProcessor.SelectedShapesCollection.Count > 1)
            {
				dialogProcessor.AddGroupShape(int.Parse(strokeWidthTextBox.Text));
				statusBar.Items[0].Text = "Последно действие: " +
					"Създаване на група от селектираните фигури";
				viewPort.Invalidate();
			}
		}

        private void DrawTriangleShapeButtonClick(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomTriangle(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на звезда";
			viewPort.Invalidate();
		}

        private void ViewPortKeyDown(object sender, KeyEventArgs e)
        {

            if (Commands.IsCreateGroupShapesCommandClicked(e))
            {
				DrawGroupShapeButton(sender, e);
				return;
            }

			if (Commands.IsUngroupShapesCommandClicked(e))
            {
				UnGroupSelectedShapesButtonClick(sender, e);
				return;
			}

			if (Commands.IsCopySelectedShapesCommandClicked(e))
			{
				dialogProcessor.CopyShapes();
				viewPort.Invalidate();
				return;
			}

			if (Commands.IsPasteSelectedShapesCommandClicked(e)
				&& dialogProcessor.CopyOfSelectedShapes.Count > 0)
			{
				dialogProcessor.PasteShapes();
				viewPort.Invalidate();
			}

		}

        private void ContextOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
			contextMenuStrip1.Items.Clear();

			int numberOfGroupShapes = dialogProcessor.SelectedShapesCollection
							.Where(shape => shape.ShapeType == Shape.Type.GROUP)
							.Count();

			if (numberOfGroupShapes > 0)
            {
				contextMenuStrip1.Items.Add(
					"Ungroup shapes", 
					null, 
					new EventHandler(UnGroupSelectedShapesButtonClick)
				);
			}

			if (dialogProcessor.SelectedShapesCollection.Count > 0)
            {	
				contextMenuStrip1.Items.Add("Rotate Shape", null, new EventHandler(RotateShapeButton));
				contextMenuStrip1.Items.Add("Delete", null, new EventHandler(DeleteShapeButtonClick));
				contextMenuStrip1.Items.Add("Copy", null, new EventHandler(CopyShapesButtonClicked));
			}
			if(dialogProcessor.CopyOfSelectedShapes.Count > 0)
            {
				contextMenuStrip1.Items.Add("Paste", null, new EventHandler(PasteShapesButtonClicked));
			}

			AddNewShapeOptions();

			// TODO: Shape Manipulations

		}

		private void DeleteShapeButtonClick(object sender, EventArgs e)
		{
			if (dialogProcessor.SelectedShapesCollection.Count > 0)
			{
				dialogProcessor.DeleteSelectedShapes();
				viewPort.Invalidate();
			}
		}

        private void UnGroupSelectedShapesButtonClick(object sender, EventArgs e)
        {
			List<Shape> groupShapes = dialogProcessor.SelectedShapesCollection
				.Where(shape => shape.ShapeType == Shape.Type.GROUP)
				.ToList();
			
			if(groupShapes.Count > 0)
            {
				dialogProcessor.UngroupSelectedShapes(groupShapes);
				viewPort.Invalidate();
			}
		}

		private void AddNewShapeOptions()
		{
			contextMenuStrip1.Items.Add("New Rectangle", null,
				new EventHandler(DrawRectangleSpeedButtonClick));

			contextMenuStrip1.Items.Add("New Square", null,
				new EventHandler(DrawSquareButtonClick));

			contextMenuStrip1.Items.Add("New Ellipse", null,
				new EventHandler(DrawEllipseShapeButtonClick));

			contextMenuStrip1.Items.Add("New Triangle", null,
				new EventHandler(DrawTriangleShapeButtonClick));

			contextMenuStrip1.Items.Add("New Pentagon", null,
				new EventHandler(DrawPentagonShapeButtonClick));

			contextMenuStrip1.Items.Add("New Star", null,
				new EventHandler(DrawStarShapeButton));
		}

        private void CopyShapesButtonClicked(object sender, EventArgs e)
        {
			if (dialogProcessor.SelectedShapesCollection.Count > 0)
			{
				dialogProcessor.CopyShapes();
				viewPort.Invalidate();
			}
		}

        private void PasteShapesButtonClicked(object sender, EventArgs e)
        {
			if (dialogProcessor.CopyOfSelectedShapes.Count > 0)
			{
				dialogProcessor.PasteShapes();
				viewPort.Invalidate();
			}
		}
    }
}
