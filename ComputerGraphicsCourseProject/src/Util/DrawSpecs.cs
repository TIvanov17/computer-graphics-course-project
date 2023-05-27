using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Util
{
	public class DrawSpecs
    {
	
		private PointF position = new PointF();
		public PointF Position
		{
			get { return position; }
			set { position = value; }
		}

		private bool shouldDrawOnRandomPosition = true;

		public bool ShouldDrawOnRandomPosition
		{
			get { return shouldDrawOnRandomPosition; }
			set { shouldDrawOnRandomPosition = value; }
		}

	}
}
