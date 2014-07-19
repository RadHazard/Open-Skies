using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Skies.Source {
	class Part {
		// Public Independant Properties
		public string name { get; private set; }
		public double mass { get; protected set; }

		// Constructors
		public Part(string name, double mass) {
			this.name = name;
			this.mass = mass;
		}
	}

	class Cockpit : Part {

	}

	class Wing : Part {

	}
}
