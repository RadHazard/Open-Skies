using Open_Skies.Source;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Open_Skies {
	public partial class AirplaneForm : Form {
		Aircraft aircraft;

		internal AirplaneForm(Aircraft aircraft) {
			this.aircraft = aircraft;

			InitializeComponent();

			UpdateGraphics();
		}

		private void UpdateGraphics() {
			this.GroupBoxParts.Controls.Clear();

			var i = 1;
			foreach (PartNode node in aircraft.PartList) {
				Part part = node.part;

				Label partLabel = new Label();
				partLabel.Text = "(" + part.Integrity + ") " + part.Name + ", " + part.Mass + " kg";
				partLabel.Location = new Point(20, i * (partLabel.Height));
				partLabel.AutoSize = true;

				// Color part name by integrity
				if (part.Integrity == 100) {
					partLabel.ForeColor = Color.Black;
				} else if (part.Integrity > 50) {
					partLabel.ForeColor = Color.Gray;
				} else if (part.Integrity > 25) {
					partLabel.ForeColor = Color.Orange;
				} else if (part.Integrity > 0) {
					partLabel.ForeColor = Color.Red;
				} else {
					partLabel.BackColor = Color.DarkRed;
					partLabel.ForeColor = Color.White;
				}

				this.GroupBoxParts.Controls.Add(partLabel);
				i++;
			}
		}
	}
}
