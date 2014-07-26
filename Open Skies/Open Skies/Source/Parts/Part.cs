using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Skies.Source {
	class Part {
		// ---- Properties ----
		public string Name { get; protected set; }
		
		public double Mass { get; protected set; }
		
		public double Integrity { get; protected set; }

		// ---- Constructors ----
		public Part(string name, double mass) {
			this.Name = name;
			this.Mass = mass;
			this.Integrity = 100;
		}
	}
}
