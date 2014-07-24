using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Skies.Source.Parts {
	class Fuselage : Part {
		public Fuselage(string name, double mass) : base(name, mass) { }
	}

	/// <summary>
	/// MK1 Fueselage
	///   Based on the P-26 Peashooter
	/// Mass: 300 kg
	/// </summary>
	class Fuselage_MK1 : Fuselage {
		public Fuselage_MK1() : base("MK1 Fueselage", 300) { }
	}
}
