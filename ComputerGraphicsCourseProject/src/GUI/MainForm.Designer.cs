namespace Draw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dsooToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedMenu = new System.Windows.Forms.ToolStrip();
            this.drawRectangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawSquareSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.pickUpSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.changeStrokeColorButton = new System.Windows.Forms.ToolStripButton();
            this.changeFillColorButton = new System.Windows.Forms.ToolStripButton();
            this.drawEllipseSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawTriangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.starShapeButton = new System.Windows.Forms.ToolStripButton();
            this.drawPentagonSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.rotateShapeSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.scaleShapeSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawGroupSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.unGroupSelectedShapes = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.strokeWidthTextBox = new System.Windows.Forms.TextBox();
            this.opacityValue = new System.Windows.Forms.TrackBar();
            this.mouseCoorinates = new System.Windows.Forms.Label();
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.lastPickedColor = new System.Windows.Forms.Button();
            this.mainMenu.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.speedMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityValue)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ContextMenuStrip = this.contextMenuStrip1;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(693, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dsooToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(68, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextOpening);
            // 
            // dsooToolStripMenuItem
            // 
            this.dsooToolStripMenuItem.Name = "dsooToolStripMenuItem";
            this.dsooToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteShapeButtonClick);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 401);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(693, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // speedMenu
            // 
            this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawRectangleSpeedButton,
            this.drawSquareSpeedButton,
            this.pickUpSpeedButton,
            this.changeStrokeColorButton,
            this.changeFillColorButton,
            this.drawEllipseSpeedButton,
            this.drawTriangleSpeedButton,
            this.starShapeButton,
            this.drawPentagonSpeedButton,
            this.rotateShapeSpeedButton,
            this.scaleShapeSpeedButton,
            this.drawGroupSpeedButton,
            this.unGroupSelectedShapes});
            this.speedMenu.Location = new System.Drawing.Point(0, 24);
            this.speedMenu.Name = "speedMenu";
            this.speedMenu.Size = new System.Drawing.Size(693, 25);
            this.speedMenu.TabIndex = 3;
            this.speedMenu.Text = "toolStrip1";
            // 
            // drawRectangleSpeedButton
            // 
            this.drawRectangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawRectangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawRectangleSpeedButton.Image")));
            this.drawRectangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawRectangleSpeedButton.Name = "drawRectangleSpeedButton";
            this.drawRectangleSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawRectangleSpeedButton.Text = "DrawRectangleButton";
            this.drawRectangleSpeedButton.Click += new System.EventHandler(this.DrawRectangleSpeedButtonClick);
            // 
            // drawSquareSpeedButton
            // 
            this.drawSquareSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawSquareSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawSquareSpeedButton.Image")));
            this.drawSquareSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawSquareSpeedButton.Name = "drawSquareSpeedButton";
            this.drawSquareSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawSquareSpeedButton.Text = "toolStripButton1";
            this.drawSquareSpeedButton.Click += new System.EventHandler(this.DrawSquareButtonClick);
            // 
            // pickUpSpeedButton
            // 
            this.pickUpSpeedButton.CheckOnClick = true;
            this.pickUpSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickUpSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("pickUpSpeedButton.Image")));
            this.pickUpSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pickUpSpeedButton.Name = "pickUpSpeedButton";
            this.pickUpSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.pickUpSpeedButton.Text = "toolStripButton1";
            // 
            // changeStrokeColorButton
            // 
            this.changeStrokeColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.changeStrokeColorButton.Image = ((System.Drawing.Image)(resources.GetObject("changeStrokeColorButton.Image")));
            this.changeStrokeColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.changeStrokeColorButton.Name = "changeStrokeColorButton";
            this.changeStrokeColorButton.Size = new System.Drawing.Size(23, 22);
            this.changeStrokeColorButton.Text = "Select Stroke Color";
            this.changeStrokeColorButton.Click += new System.EventHandler(this.ChangeStrokeColorClick);
            // 
            // changeFillColorButton
            // 
            this.changeFillColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.changeFillColorButton.Image = ((System.Drawing.Image)(resources.GetObject("changeFillColorButton.Image")));
            this.changeFillColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.changeFillColorButton.Name = "changeFillColorButton";
            this.changeFillColorButton.Size = new System.Drawing.Size(23, 22);
            this.changeFillColorButton.Text = "Select Fill Color";
            this.changeFillColorButton.Click += new System.EventHandler(this.ChangeFillColorClick);
            // 
            // drawEllipseSpeedButton
            // 
            this.drawEllipseSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawEllipseSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawEllipseSpeedButton.Image")));
            this.drawEllipseSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawEllipseSpeedButton.Name = "drawEllipseSpeedButton";
            this.drawEllipseSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawEllipseSpeedButton.Text = "Draw Ellipse";
            this.drawEllipseSpeedButton.Click += new System.EventHandler(this.DrawEllipseShapeButtonClick);
            // 
            // drawTriangleSpeedButton
            // 
            this.drawTriangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawTriangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawTriangleSpeedButton.Image")));
            this.drawTriangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawTriangleSpeedButton.Name = "drawTriangleSpeedButton";
            this.drawTriangleSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawTriangleSpeedButton.Text = "Draw Star";
            this.drawTriangleSpeedButton.Click += new System.EventHandler(this.DrawTriangleShapeButtonClick);
            // 
            // starShapeButton
            // 
            this.starShapeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.starShapeButton.Image = ((System.Drawing.Image)(resources.GetObject("starShapeButton.Image")));
            this.starShapeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.starShapeButton.Name = "starShapeButton";
            this.starShapeButton.Size = new System.Drawing.Size(23, 22);
            this.starShapeButton.Text = "toolStripButton3";
            this.starShapeButton.Click += new System.EventHandler(this.DrawStarShapeButton);
            // 
            // drawPentagonSpeedButton
            // 
            this.drawPentagonSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawPentagonSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawPentagonSpeedButton.Image")));
            this.drawPentagonSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawPentagonSpeedButton.Name = "drawPentagonSpeedButton";
            this.drawPentagonSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawPentagonSpeedButton.Text = "Draw Pentagon";
            this.drawPentagonSpeedButton.Click += new System.EventHandler(this.DrawPentagonShapeButtonClick);
            // 
            // rotateShapeSpeedButton
            // 
            this.rotateShapeSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateShapeSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("rotateShapeSpeedButton.Image")));
            this.rotateShapeSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateShapeSpeedButton.Name = "rotateShapeSpeedButton";
            this.rotateShapeSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.rotateShapeSpeedButton.Text = "Rotate Shape";
            this.rotateShapeSpeedButton.Click += new System.EventHandler(this.RotateShapeButton);
            // 
            // scaleShapeSpeedButton
            // 
            this.scaleShapeSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.scaleShapeSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("scaleShapeSpeedButton.Image")));
            this.scaleShapeSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.scaleShapeSpeedButton.Name = "scaleShapeSpeedButton";
            this.scaleShapeSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.scaleShapeSpeedButton.Text = "Scale Shape";
            this.scaleShapeSpeedButton.Click += new System.EventHandler(this.ScaleShapeButton);
            // 
            // drawGroupSpeedButton
            // 
            this.drawGroupSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawGroupSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawGroupSpeedButton.Image")));
            this.drawGroupSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawGroupSpeedButton.Name = "drawGroupSpeedButton";
            this.drawGroupSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawGroupSpeedButton.Text = "Group Selected Shapes";
            this.drawGroupSpeedButton.Click += new System.EventHandler(this.DrawGroupShapeButton);
            // 
            // unGroupSelectedShapes
            // 
            this.unGroupSelectedShapes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.unGroupSelectedShapes.Image = ((System.Drawing.Image)(resources.GetObject("unGroupSelectedShapes.Image")));
            this.unGroupSelectedShapes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.unGroupSelectedShapes.Name = "unGroupSelectedShapes";
            this.unGroupSelectedShapes.Size = new System.Drawing.Size(23, 22);
            this.unGroupSelectedShapes.Text = "Ungroup Selected Shapes";
            this.unGroupSelectedShapes.Click += new System.EventHandler(this.UnGroupSelectedShapesButtonClick);
            // 
            // strokeWidthTextBox
            // 
            this.strokeWidthTextBox.Location = new System.Drawing.Point(553, 29);
            this.strokeWidthTextBox.Name = "strokeWidthTextBox";
            this.strokeWidthTextBox.Size = new System.Drawing.Size(26, 20);
            this.strokeWidthTextBox.TabIndex = 5;
            this.strokeWidthTextBox.Text = "1";
            this.strokeWidthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.strokeWidthTextBox.TextChanged += new System.EventHandler(this.ChangeStrokeWidth);
            // 
            // opacityValue
            // 
            this.opacityValue.BackColor = System.Drawing.SystemColors.Control;
            this.opacityValue.Location = new System.Drawing.Point(0, 68);
            this.opacityValue.Maximum = 255;
            this.opacityValue.Name = "opacityValue";
            this.opacityValue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.opacityValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.opacityValue.Size = new System.Drawing.Size(45, 212);
            this.opacityValue.TabIndex = 6;
            this.opacityValue.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.opacityValue.Value = 255;
            this.opacityValue.Scroll += new System.EventHandler(this.ChangeOpacityValue);
            // 
            // mouseCoorinates
            // 
            this.mouseCoorinates.AutoSize = true;
            this.mouseCoorinates.Location = new System.Drawing.Point(13, 287);
            this.mouseCoorinates.Name = "mouseCoorinates";
            this.mouseCoorinates.Size = new System.Drawing.Size(0, 13);
            this.mouseCoorinates.TabIndex = 7;
            // 
            // viewPort
            // 
            this.viewPort.ContextMenuStrip = this.contextMenuStrip1;
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(0, 49);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(693, 352);
            this.viewPort.TabIndex = 4;
            this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
            this.viewPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ViewPortKeyDown);
            this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
            this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
            this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
            // 
            // lastPickedColor
            // 
            this.lastPickedColor.Location = new System.Drawing.Point(4, 303);
            this.lastPickedColor.Name = "lastPickedColor";
            this.lastPickedColor.Size = new System.Drawing.Size(41, 33);
            this.lastPickedColor.TabIndex = 8;
            this.lastPickedColor.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 423);
            this.Controls.Add(this.lastPickedColor);
            this.Controls.Add(this.mouseCoorinates);
            this.Controls.Add(this.opacityValue);
            this.Controls.Add(this.strokeWidthTextBox);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.speedMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Draw";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ViewPortKeyDown);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.speedMenu.ResumeLayout(false);
            this.speedMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private Draw.DoubleBufferedPanel viewPort;
		private System.Windows.Forms.ToolStripButton pickUpSpeedButton;
		private System.Windows.Forms.ToolStripButton drawRectangleSpeedButton;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip speedMenu;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.MenuStrip mainMenu;
    private System.Windows.Forms.ColorDialog colorDialog1;
    private System.Windows.Forms.ToolStripButton changeStrokeColorButton;
    private System.Windows.Forms.ToolStripButton changeFillColorButton;
    private System.Windows.Forms.ColorDialog colorDialog2;
    private System.Windows.Forms.TextBox strokeWidthTextBox;
    private System.Windows.Forms.TrackBar opacityValue;
        private System.Windows.Forms.ToolStripButton drawSquareSpeedButton;
        private System.Windows.Forms.ToolStripButton drawEllipseSpeedButton;
        private System.Windows.Forms.ToolStripButton drawTriangleSpeedButton;
        private System.Windows.Forms.ToolStripButton drawPentagonSpeedButton;
        private System.Windows.Forms.ToolStripButton rotateShapeSpeedButton;
        private System.Windows.Forms.ToolStripButton scaleShapeSpeedButton;
        private System.Windows.Forms.ToolStripButton drawGroupSpeedButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dsooToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton starShapeButton;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label mouseCoorinates;
        private System.Windows.Forms.Button lastPickedColor;
        private System.Windows.Forms.ToolStripButton unGroupSelectedShapes;
    }
}
