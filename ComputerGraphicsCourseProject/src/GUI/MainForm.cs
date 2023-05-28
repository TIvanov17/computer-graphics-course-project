using Draw.src.Util;
using Draw.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
		void DrawRectangleOnCurrentMousePosition(object sender, EventArgs e)
		{
			dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = false;
			dialogProcessor.AddRectangle(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";	
			viewPort.Invalidate();
		}

		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = true;
			dialogProcessor.AddRectangle(int.Parse(strokeWidthTextBox.Text));
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
			if(e.Button == MouseButtons.Right)
            {
				dialogProcessor.DrawSpecs.
					Position = new PointF(MousePosition.X, MousePosition.Y);

				dialogProcessor.DrawSpecs.
					ShouldDrawOnRandomPosition = false;

				dialogProcessor.PositionOnRightClickAddShape =
					new PointF(MousePosition.X, MousePosition.Y);
            }

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

					
					statusBar.Items[0].Text = "Последно действие: Селекция на примитив " + currentClickedShape.Name;
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
				if (dialogProcessor.SelectedShapesCollection != null)
				{
					statusBar.Items[0].Text = "Последно действие: Влачене";
				}

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
			if (fillColorDialog.ShowDialog() == DialogResult.OK)
			{

				dialogProcessor.LastPickedColor = fillColorDialog.Color;
				lastPickedColor.BackColor = fillColorDialog.Color;
				dialogProcessor.SetFillColor(fillColorDialog.Color);
				viewPort.Invalidate();
			}
		}

        private void ChangeStrokeColorClick(object sender, EventArgs e)
        {
			if (strokeColorDialog.ShowDialog() == DialogResult.OK)
			{
				dialogProcessor.SetStrokeColor(strokeColorDialog.Color);
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

		private void DrawStarShapeOnCurrentMousePositionButton(object sender, EventArgs e)
		{
			dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = false;
			dialogProcessor.AddStar(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на квадрат";
			viewPort.Invalidate();
		}

		private void DrawStarShapeButton(object sender, EventArgs e)
		{
			dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = true;
			dialogProcessor.AddStar(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на квадрат";
			viewPort.Invalidate();
		}

		private void DrawSquareShapeOnCurrentMousePosition(object sender, EventArgs e)
		{
			dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = false;
			dialogProcessor.AddSquare(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на квадрат";
			viewPort.Invalidate();
		}

		private void DrawSquareButtonClick(object sender, EventArgs e)
        {
			dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = true;
			dialogProcessor.AddSquare(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на квадрат";
			viewPort.Invalidate();
		}

        private void DrawEllipseShapeButtonClick(object sender, EventArgs e)
        {
			dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = true;
			dialogProcessor.AddEllipse(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на елипса";
			viewPort.Invalidate();
		}

		private void DrawEllipseShapeOnCurrentMousePosition(object sender, EventArgs e)
		{
			dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = false;
			dialogProcessor.AddEllipse(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на елипса";
			viewPort.Invalidate();
		}


		private void DrawCircleShapeButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = true;
			dialogProcessor.AddCircle(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на кръг";
			viewPort.Invalidate();
		}

		private void DrawCircleShapeOnCurrentMousePosition(object sender, EventArgs e)
		{
			dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = false;
			dialogProcessor.AddCircle(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на кръг";
			viewPort.Invalidate();
		}

		private void DrawLineButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = true;
			dialogProcessor.AddLine(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на кръг";
			viewPort.Invalidate();
		}

		private void DrawLineShapeOnCurrentMousePosition(object sender, EventArgs e)
		{
			dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = false;
			dialogProcessor.AddLine(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на кръг";
			viewPort.Invalidate();
		}

		private void DrawPentagonShapeButtonClick(object sender, EventArgs e)
        {
			dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = true;
			dialogProcessor.AddPentagon(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на звезда";
			viewPort.Invalidate();
		}

		private void DrawPentagonShapeOnCurrentMousePosition(object sender, EventArgs e)
		{
			dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = false;
			dialogProcessor.AddPentagon(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на звезда";
			viewPort.Invalidate();
		}

		private void RotateShapeButton(object sender, EventArgs e)
        {
			int angle;

			if (int.TryParse(angleTextBox.Text, out angle))
			{
				dialogProcessor.RotateShape(angle);
				statusBar.Items[0].Text = "Последно действие: Ротация на фигура";
			} 
			
			viewPort.Invalidate();
		}

        private void ScaleShapeButton(object sender, EventArgs e)
        {
			float scaleFactor;
			
			if(float.TryParse(scaleBox.Text, out scaleFactor))
            {
				dialogProcessor.ScaleShape(scaleFactor, scaleFactor);
				statusBar.Items[0].Text = "Последно действие: Мащабиране на фигура";
			}


		
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
			dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = true;
			dialogProcessor.AddTriangle(int.Parse(strokeWidthTextBox.Text));
			statusBar.Items[0].Text = "Последно действие: Рисуване на звезда";
			viewPort.Invalidate();
		}

		private void DrawTriangleShapeOnCurrentMousePosition(object sender, EventArgs e)
		{
			dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = false;
			dialogProcessor.AddTriangle(int.Parse(strokeWidthTextBox.Text));
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

			if (Commands.IsCutSelectedShapesCommandClicked(e))
			{
				dialogProcessor.CutShapes();
				viewPort.Invalidate();
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

			if (Commands.IsSelectAllShapesCommandClicked(e))
			{
				SelectAllShapesButtonClicked(sender, e);
				return;
			}
			if (Commands.IsUnselectAllShapesCommandClicked(e))
			{
				UnselectAllShapesButtonClicked(sender, e);
				return;
			}
			if (Commands.IsDeleteSelectedShapesCommandClicked(e))
			{
				DeleteShapeButtonClick(sender, e);
			}
            if (Commands.SaveAsCommandClicked(e))
            {
				SaveButtonClicked(sender, e);
            }
			if (Commands.UploadCommandClicked(e))
			{
				UploadButtonClicked(sender, e);
			}

			if (Commands.IsInvertSelectionCommandClicked(e))
			{
				InvertSelectionButtonClicked(sender, e);
			}

		}

		private void ContextOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
			contextMenuStrip1.Items.Clear();
			
			AddNewShapeOptions();

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


			if (dialogProcessor.ShapeList.Count > 0)
			{
				contextMenuStrip1.Items.Add("Select All Shapes", null, new EventHandler(SelectAllShapesButtonClicked));
			}

			if (dialogProcessor.SelectedShapesCollection.Count > 0)
            {
				contextMenuStrip1.Items.Add("Unselect All", null, new EventHandler(UnselectAllShapesButtonClicked));
				contextMenuStrip1.Items.Add("Rotate Shape", null, new EventHandler(RotateShapeButton));
				contextMenuStrip1.Items.Add("Delete", null, new EventHandler(DeleteShapeButtonClick));
				contextMenuStrip1.Items.Add("Copy", null, new EventHandler(CopyShapesButtonClicked));
				contextMenuStrip1.Items.Add("Cut", null, new EventHandler(CutShapesButtonClicked));
				contextMenuStrip1.Items.Add("Invert Selection", null, new EventHandler(InvertSelectionButtonClicked));

			}
			if(dialogProcessor.CopyOfSelectedShapes.Count > 0)
            {
				contextMenuStrip1.Items.Add("Paste", null, new EventHandler(PasteShapesButtonClicked));
			}
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
			ToolStripMenuItem creatShapeOnRandomPosition = 
				new ToolStripMenuItem("Shape With Random Position");


			ToolStripMenuItem creatShapeOnCurrentPosition =
				new ToolStripMenuItem("Shape With Current Position");

			creatShapeOnCurrentPosition
				.DropDownItems.Add("Star", null, DrawStarShapeOnCurrentMousePositionButton);

			creatShapeOnCurrentPosition
				.DropDownItems.Add("Square", null, DrawSquareShapeOnCurrentMousePosition);

			creatShapeOnCurrentPosition
				.DropDownItems.Add("Rectangle", null, DrawRectangleOnCurrentMousePosition);
				
			creatShapeOnCurrentPosition
				.DropDownItems.Add("Pentagon", null, DrawPentagonShapeOnCurrentMousePosition);

			creatShapeOnCurrentPosition
				.DropDownItems.Add("Ellipse", null, DrawEllipseShapeOnCurrentMousePosition);

			creatShapeOnCurrentPosition
				.DropDownItems.Add("Triangle", null, DrawTriangleShapeOnCurrentMousePosition);

			creatShapeOnCurrentPosition
				.DropDownItems.Add("Circle", null, DrawCircleShapeOnCurrentMousePosition);
			
			creatShapeOnCurrentPosition
				.DropDownItems.Add("Line", null, DrawLineShapeOnCurrentMousePosition);

			creatShapeOnRandomPosition
				.DropDownItems.Add("Rectangle", null,
				new EventHandler(DrawRectangleSpeedButtonClick));

			creatShapeOnRandomPosition
				.DropDownItems.Add("Square", null,
				new EventHandler(DrawSquareButtonClick));

			creatShapeOnRandomPosition
				.DropDownItems.Add("Ellipse", null,
				new EventHandler(DrawEllipseShapeButtonClick));

			creatShapeOnRandomPosition
				.DropDownItems.Add("Triangle", null,
				new EventHandler(DrawTriangleShapeButtonClick));

			creatShapeOnRandomPosition
				.DropDownItems.Add("Pentagon", null,
				new EventHandler(DrawPentagonShapeButtonClick));

			creatShapeOnRandomPosition
				.DropDownItems.Add("Star", null,
				new EventHandler(DrawStarShapeButton));

			creatShapeOnRandomPosition
				.DropDownItems.Add("Circle", null,
				new EventHandler(DrawCircleShapeButtonClick));

			creatShapeOnRandomPosition
				.DropDownItems.Add("Line", null,
				new EventHandler(DrawLineButtonClick));

			contextMenuStrip1.Items.Add(creatShapeOnRandomPosition);
			contextMenuStrip1.Items.Add(creatShapeOnCurrentPosition);
		}

        private void CopyShapesButtonClicked(object sender, EventArgs e)
        {
			if (dialogProcessor.SelectedShapesCollection.Count > 0)
			{
				dialogProcessor.CopyShapes();
				viewPort.Invalidate();
			}
		}

		private void CutShapesButtonClicked(object sender, EventArgs e)
		{
			if (dialogProcessor.SelectedShapesCollection.Count > 0)
			{
				dialogProcessor.CutShapes();
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

		private void SelectAllShapesButtonClicked(object sender, EventArgs e)
		{
			if (dialogProcessor.ShapeList.Count > 0)
			{
				dialogProcessor.SelectAllShapes();
				viewPort.Invalidate();
			}
		}

		private void UnselectAllShapesButtonClicked(object sender, EventArgs e)
		{
			if (dialogProcessor.ShapeList.Count > 0)
			{
				dialogProcessor.SelectedShapesCollection.Clear();
				viewPort.Invalidate();
			}
		}

		private void InvertSelectionButtonClicked(object sender, EventArgs e)
		{
			// TODO: add logic in DialogProcessor in some Method

			if (dialogProcessor.ShapeList.Count > 0 && 
				dialogProcessor.SelectedShapesCollection.Count == 0)
			{
				SelectAllShapesButtonClicked(sender, e);
				viewPort.Invalidate();
				return;
			}

			if (dialogProcessor.ShapeList.Count > 0 && 
				dialogProcessor.SelectedShapesCollection.Count > 0)
			{
				dialogProcessor.InvertSelection();
				viewPort.Invalidate();
			}

		}

		// LOCAL SAVE INTO PROJECT DIR
		private void SaveFile_Click(object sender, EventArgs e)
		{
			string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "local_save.cg");
			ModelSaver.SaveModel(path,
				dialogProcessor.ShapeList);
			viewPort.Invalidate();
		}


		private void SaveButtonClicked(object sender, EventArgs e)
        {
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				ModelSaver.SaveModel(saveFileDialog1.FileName, dialogProcessor.ShapeList);
				viewPort.Invalidate();
			}
		}

        private void UploadButtonClicked(object sender, EventArgs e)
        {
			
			if (uploadFileDialog.ShowDialog() == DialogResult.OK)
			{
				String path = uploadFileDialog.FileName;
				//path.EndsWith();

				if (path.Contains(".cg"))
				{
					dialogProcessor.ShapeList.Clear();
					dialogProcessor.SelectedShapesCollection.Clear();
					dialogProcessor.CopyOfSelectedShapes.Clear();
					dialogProcessor.ShapeList.AddRange(ModelSaver.UploadModel(path));
				}

				viewPort.Invalidate();
			}

		}

		private static DialogResult BuildForm(ref string x, ref string y, ref string shape)
        {
			Form form = new Form();
			Label labelForInputX = new Label();
			Label labelForInputY = new Label();
			Label labelForShape = new Label();
			TextBox textBoxForX = new TextBox();
			TextBox textBoxForY = new TextBox();
			ComboBox comboBox = new ComboBox();
			comboBox.Items.AddRange(new string[] { 
				"Line", "Ellipse", "Rectangle", "Square",
				"Star", "Triangle", "Cicle", "Pentagon" 
			});

			Button buttonOk = new Button();
			
			labelForInputX.Text = "X:";
			labelForInputY.Text = "Y:";
			labelForShape.Text = "Select Shape:";
			buttonOk.Text = "OK";
			buttonOk.DialogResult = DialogResult.OK;

			labelForInputX.SetBounds(20, 86, 20, 20);
			labelForInputY.SetBounds(120, 86, 20, 20);
			textBoxForX.SetBounds(50, 86, 30, 20);
			textBoxForY.SetBounds(150, 86, 30, 20);
			labelForShape.SetBounds(10, 120, 80, 20);
			comboBox.SetBounds(100, 120, 70, 20);
			buttonOk.SetBounds(100, 160, 30, 30);
			
			labelForInputX.AutoSize = true;
			form.ClientSize = new Size(200, 200);
			form.FormBorderStyle = FormBorderStyle.FixedDialog;
			form.StartPosition = FormStartPosition.CenterScreen;
			form.MinimizeBox = false;
			form.MaximizeBox = false;

			form.Controls
				.AddRange(new Control[] { 
					labelForInputX, labelForInputY, labelForShape,
					textBoxForX, textBoxForY,
					comboBox, buttonOk
				});
			form.AcceptButton = buttonOk;

			DialogResult dialogResult = form.ShowDialog();
			
			x = textBoxForX.Text;
			y = textBoxForY.Text;
			shape = (string)comboBox.SelectedItem;


			return dialogResult;
		}

        private void NewForm(object sender, EventArgs e)
        {

            string x = "";
            string y = "";
            string shape = "";
            if (BuildForm(ref x, ref y, ref shape) == DialogResult.OK)
            {
                dialogProcessor.PositionOnRightClickAddShape =
                    new PointF(float.Parse(x), float.Parse(y));

				dialogProcessor.DrawSpecs.Position = 
					new PointF(float.Parse(x), float.Parse(y));

				dialogProcessor.DrawSpecs.ShouldDrawOnRandomPosition = false;

				DrawSelectedShape(sender, e, shape);
			}
        }

		private void DrawSelectedShape(object sender, EventArgs e, string selectedShape)
        {
			if(selectedShape == null)
            {
				return;
            }

			if (selectedShape.Equals("Line"))
			{
				DrawLineShapeOnCurrentMousePosition(sender, e);
			}

			if (selectedShape.Equals("Ellipse"))
			{
				DrawEllipseShapeOnCurrentMousePosition(sender, e);
			}

			if (selectedShape.Equals("Rectangle"))
			{
				DrawRectangleOnCurrentMousePosition(sender, e);
			}
			
			if (selectedShape.Equals("Square"))
			{
				DrawSquareShapeOnCurrentMousePosition(sender, e);
			}

			if (selectedShape.Equals("Triangle"))
			{
				DrawTriangleShapeOnCurrentMousePosition(sender, e);
			}

			if (selectedShape.Equals("Cicle"))
			{
				DrawCircleShapeOnCurrentMousePosition(sender, e);
			}

			if (selectedShape.Equals("Pentagon"))
			{
				DrawPentagonShapeOnCurrentMousePosition(sender, e);
			}

			if (selectedShape.Equals("Star"))
			{
				DrawStarShapeOnCurrentMousePositionButton(sender, e);
			}

		}

        private void SetRGBAColor_Click(object sender, EventArgs e)
        {
			int red, green, blue, alpha;

			if (int.TryParse(redColorBox.Text, out red) &&
				int.TryParse(greenColorBox.Text, out green) &&
				int.TryParse(blueColorBox.Text, out blue) && 
				int.TryParse(alphaColorBox.Text, out alpha))
			{
				if(red < 0 || green > 255 || green < 0 || green > 255 ||
					blue < 0 || blue > 255 || alpha < 0 || alpha > 255)
                {
					viewPort.Invalidate();
					return;
                }


				dialogProcessor.SetFillColor(Color.FromArgb(alpha, red, green, blue));
				statusBar.Items[0].Text = "Последно действие: Ротация на фигура";
			}

			viewPort.Invalidate();
		}

        private void RotateAt90Degree(object sender, EventArgs e)
        {
			dialogProcessor.RotateShape(90);
			viewPort.Invalidate();
		}

        private void SetName(object sender, EventArgs e)
        {
			if(dialogProcessor.SelectedShapesCollection.Count > 0)
            {
				dialogProcessor.SelectedShapesCollection.ForEach(s => s.Name = nameBox.Text);
				
			}
        }
    }
}
