﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
		void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (pickUpSpeedButton.Checked) {
				dialogProcessor.Selection = dialogProcessor.ContainsPoint(e.Location);
				if (dialogProcessor.Selection != null) {
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
		void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging) {
				if (dialogProcessor.Selection != null) statusBar.Items[0].Text = "Последно действие: Влачене";
				dialogProcessor.TranslateTo(e.Location);
				viewPort.Invalidate();
			}
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
			dialogProcessor.SetOpaciry(opacityValue.Value);
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

		private void DrawStarShapeButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomStar(int.Parse(strokeWidthTextBox.Text));

			statusBar.Items[0].Text = "Последно действие: Рисуване на звезда";

			viewPort.Invalidate();
		}

        private void DrawPentagonShapeButtonClick(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomPentagon(int.Parse(strokeWidthTextBox.Text));

			statusBar.Items[0].Text = "Последно действие: Рисуване на звезда";

			viewPort.Invalidate();
		}
    }
}