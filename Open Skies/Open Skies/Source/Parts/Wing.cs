using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Skies.Source {
	class Wing : Part {
		// ---- Properties ----
		public double AspectRatio {
			get {
				return ((Wingspan * Wingspan) / PlanformArea);
			}
		}

		// ---- Fields ----
		// Wing shape is stored as wingspan and area to accomidate non-rectangular wings
		private double Wingspan; // meters
		private double PlanformArea; // meters squared

		// ---- Constructors ----
		public Wing(string name, double mass, double wingspan, double planformArea)
			: base(name, mass) {
			this.Wingspan = wingspan;
			this.PlanformArea = planformArea;
		}

		// ---- Methods ----
		public double Lift(double velocity) {
			throw new NotImplementedException();
		}
	}

	/// <summary>
	/// MK1 Wing
	///   Based off of the P-26A Peashooter and partially pulled out of my ass
	/// Mass:         150 kg
	/// Wingspan:       4 m
	/// Planform Area:  4 m^2
	/// </summary>
	class Wing_MK1 : Wing {
		public Wing_MK1() : base("MK1 Wing", 150, 4, 4) { }
	}
}
