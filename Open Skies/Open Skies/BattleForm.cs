using Open_Skies.Source;
using Open_Skies.Source.Parts;
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
	public partial class BattleForm : Form {
		Aircraft plane1;
		Aircraft plane2;

		public BattleForm() {
			plane1 = new Aircraft("Aircraft 1", MakePlane());
			plane2 = new Aircraft("Aircraft 2", MakePlane());

			InitializeComponent();
		}

		/// <summary>
		/// Makes a basic plane part graph with all the basic parts
		/// </summary>
		/// <returns>Root PartNode of the plane part graph</returns>
		private PartNode MakePlane() {
			PartNode cockpit = new PartNode(new Cockpit_MK1());

			PartNode leftWing = new PartNode(new Wing_MK1());
			cockpit.AttachNode(leftWing);
			PartNode leftAileron = new PartNode(new Aileron_MK1());
			leftWing.AttachNode(leftAileron);

			PartNode rightWing = new PartNode(new Wing_MK1());
			cockpit.AttachNode(leftWing);
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
			PartNode mg2 = new PartNode(new Gun_MK1());
			
			return cockpit;
		}
	}
}
