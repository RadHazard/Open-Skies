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
	public partial class AircraftForm : Form {
		internal Aircraft Aircraft { get; private set; }

		internal AircraftForm(Aircraft aircraft) {
			InitializeComponent();

			this.Aircraft = aircraft;
			this.Text = aircraft.Name;
			this.FormClosing += AircraftForm_FormClosing;

			UpdateGraphics();
		}

		/// <summary>
		/// Updates the display of the screen
		/// </summary>
		private void UpdateGraphics() {
			this.GroupBoxParts.Controls.Clear();

			int i = 0;
			foreach (PartNode node in Aircraft.PartList) {
				Part part = node.part;

				Label partLabel = new Label();
				partLabel.Text = "(" + part.Integrity + ") " + part.Name + ", " + part.Mass + " kg";
				partLabel.Location = new Point(6, (i * partLabel.Height) + 16);
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

		/// <summary>
		/// Overrides the default FormClosing to hide the form instead
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void AircraftForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (e.CloseReason == CloseReason.UserClosing) {
				this.Hide();
				e.Cancel = true;
			}
		}
	}
}
