using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Skies.Source {
	class ControlSurface : Part {
		// ---- Properties ----
		public double Area { get; protected set; }
		
		public double MaxDeflection { get; protected set; }

		public double Deflection {
			get {
				return deflection;
			}
			set {
				if (value > MaxDeflection)
					deflection = MaxDeflection;
				else if (value < -MaxDeflection)
					deflection = -MaxDeflection;
				else
					deflection = value;
			}
		}
		public double deflection;

		// ---- Constructors ----
		public ControlSurface(string name, double mass, double area, double maxDeflection)
			: base(name, mass) {
			this.Area = area;
			this.MaxDeflection = maxDeflection;
			this.Deflection = 0;
		}
	}

	class Elevator : ControlSurface {
		public Elevator(string name, double mass, double area, double maxDeflection) : base(name, mass, area, maxDeflection) { }

		public double getForce(double airspeed, double angleOfAttack) {
			return 0;
		}
	}

	class Aileron : ControlSurface {
		public Aileron(string name, double mass, double area, double maxDeflection) : base(name, mass, area, maxDeflection) { }

		public double getForce(double airspeed) {
			return 0;
		}
	}

	class Rudder : ControlSurface {
		public Rudder(string name, double mass, double area, double maxDeflection) : base(name, mass, area, maxDeflection) { }

		public double getForce(double airspeed, double slipAngle) {
			return 0;
		}
	}

	/// <summary>
	/// MK1 Elevator
	///   I made these numbers up
	/// Mass:            10 kg
	/// Area:          0.25 m^2
	/// Max Deflection:  30 deg
	/// </summary>
	class Elevator_MK1 : Elevator {
		public Elevator_MK1() : base("MK1 Elevator", 10, 0.25, 30) { }
	}

	/// <summary>
	/// MK1 Elevator
	///   I made these numbers up
	/// Mass:            20 kg
	/// Area:           0.5 m^2
	/// Max Deflection:  30 deg
	/// </summary>
	class Aileron_MK1 : Aileron {
		public Aileron_MK1() : base("MK1 Aileron", 20, 0.5, 30) { }
	}


	/// <summary>
	/// MK1 Rudder
	///   I made these numbers up
	/// Mass:            10 kg
	/// Area:          0.25 m^2
	/// Max Deflection:  30 deg
	/// </summary>
	class Rudder_MK1 : Rudder {
		public Rudder_MK1() : base("MK1 Rudder", 10, 0.25, 30) { }
	}
}
