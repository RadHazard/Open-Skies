using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Skies.Source {
	class ControlSurface : Part {
		// ---- Properties ----
		public double area { get; protected set; }
		public double maxDeflection { get; protected set; }

		public double deflection {
			get;
			set {
				if (value > maxDeflection)
					deflection = maxDeflection;
				else if (value < -maxDeflection)
					deflection = -maxDeflection;
				else
					deflection = value;
			}
		}

		// ---- Constructors ----
		public ControlSurface(string name, double mass, double area, double maxDeflection)
			: base(name, mass) {
			this.area = area;
			this.maxDeflection = maxDeflection;
			this.deflection = 0;
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
		public Elevator_MK1() : base("Elevator_MK1", 10, 0.25, 30) { }
	}

	/// <summary>
	/// MK1 Elevator
	///   I made these numbers up
	/// Mass:            20 kg
	/// Area:           0.5 m^2
	/// Max Deflection:  30 deg
	/// </summary>
	class Aileron_MK1 : Aileron {
		public Aileron_MK1() : base("Elevator_MK1", 20, 0.5, 30) { }
	}


	/// <summary>
	/// MK1 Rudder
	///   I made these numbers up
	/// Mass:            10 kg
	/// Area:          0.25 m^2
	/// Max Deflection:  30 deg
	/// </summary>
	class Rudder_MK1 : Rudder {
		public Rudder_MK1() : base("Elevator_MK1", 10, 0.25, 30) { }
	}
}
