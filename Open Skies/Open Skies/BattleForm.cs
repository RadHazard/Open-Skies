using Open_Skies.Source;
using Open_Skies.Source.Parts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Open_Skies {
	public partial class BattleForm : Form {
		private List<AircraftForm> aircraftList;
		private int aircraftCount;
		
		public BattleForm() {
			InitializeComponent();

			this.aircraftList = new List<AircraftForm>();
			this.aircraftCount = 1;

			AddNewAircraft();
			AddNewAircraft();

			GraphicsUpdate();
		}

		private void GraphicsUpdate() {
			this.GroupBoxAircraft.Controls.Clear();

			int index = 0;
			foreach (AircraftForm aircraftForm in aircraftList) {
				LinkLabel label = new LinkLabel();
				label.Text = aircraftForm.Aircraft.Name;
				label.Tag = aircraftForm;
				label.Click += new EventHandler(OpenAircraftForm);
				label.Location = new Point(6, (index * label.Height) + 16);
				label.AutoSize = true;

				this.GroupBoxAircraft.Controls.Add(label);
				index++;
			}
		}

		void OpenAircraftForm(object sender, EventArgs e) {
			LinkLabel linklabel = sender as LinkLabel;
			if (linklabel != null && linklabel.Tag is AircraftForm) {
				AircraftForm form = linklabel.Tag as AircraftForm;
				form.Show();
				form.Select();
			}
		}

		private void AddNewAircraft() {
			Aircraft aircraft = new Aircraft("Aircraft " + aircraftCount, MakeDebugPlane());
			aircraftList.Add(new AircraftForm(aircraft));
			aircraftCount++;
		}

		/// <summary>
		/// Makes a basic plane part graph with all the basic parts
		/// </summary>
		/// <returns>Root PartNode of the plane part graph</returns>
		private PartNode MakeDebugPlane() {
			PartNode cockpit = new PartNode(new Cockpit_MK1());

			PartNode leftWing = new PartNode(new Wing_MK1());
			cockpit.AttachNode(leftWing);
			PartNode leftAileron = new PartNode(new Aileron_MK1());
			leftWing.AttachNode(leftAileron);

			PartNode rightWing = new PartNode(new Wing_MK1());
			cockpit.AttachNode(rightWing);
			PartNode rightAileron = new PartNode(new Aileron_MK1());
			rightWing.AttachNode(rightAileron);

			PartNode fuselage = new PartNode(new Fuselage_MK1());
			cockpit.AttachNode(fuselage);
			PartNode leftElevator = new PartNode(new Elevator_MK1());
			fuselage.AttachNode(leftElevator);
			PartNode rightElevator = new PartNode(new Elevator_MK1());
			fuselage.AttachNode(rightElevator);
			PartNode rudder = new PartNode(new Rudder_MK1());
			fuselage.AttachNode(rudder);

			PartNode engine = new PartNode(new Engine_MK1());
			cockpit.AttachNode(engine);

			PartNode mg1 = new PartNode(new Gun_MK1());
			engine.AttachNode(mg1);
			PartNode mg2 = new PartNode(new Gun_MK1());
			engine.AttachNode(mg2);

			return cockpit;
		}
	}
}
