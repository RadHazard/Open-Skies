using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Skies.Source {
	class Part {
		// ---- Properties ----
		public string name { get; protected set; }
		public double mass { get; protected set; }
		public double integrity { get; protected set; }

		// ---- Constructors ----
		public Part(string name, double mass) {
			this.name = name;
			this.mass = mass;
			this.integrity = 100;
		}
	}
}
