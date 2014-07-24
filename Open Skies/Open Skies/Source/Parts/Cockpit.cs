using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Skies.Source.Parts {
	class Cockpit : Part {
		public Cockpit(string name, double mass) : base(name, mass) { }
	}

	/// <summary>
	/// MK1 Cockpit
	///   Based on the P-26 Peashooter
	/// Mass: 400 kg
	/// </summary>
	class Cockpit_MK1 : Cockpit {
		public Cockpit_MK1() : base("MK1 Cockpit", 400) { }
	}
}
