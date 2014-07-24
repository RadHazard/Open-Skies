using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Skies.Source.Parts {
	class Engine : Part {
		public static const double AIR_DENSITY = 1.2045; // kg/m^3

		// ---- Properties ----
		public Prop prop { get; protected set; }
		public int power { get; protected set; } // kilowatts
		public int RPM { get; protected set; } // Revolutions per minute
		public double thrust {
			get {
				//F = .5 * r * A * [V_e^2 - V_0^2]
				/*
				double objThrust = (0.00000000000283) * Math.pow(RPM, 2)  
								* Math.pow (prop.diameter, 4) 
			    				* (( AIR_DENSITY ) * objCF;
				
				double perimeterSpeed = prop.diameter * Math.PI * (RPM / 60); // m/s

				if ( perimeterSpeed > 320 ) {
					//alert ('Danger! Supersonic blade perimeter speed!');
				}

				objLE = ((( ( Math.pow (RPM,3)) * (Math.pow (prop.diameter,4)) * (objPitch) )/(Math.pow (10.23,17))) * objCF) * objBlades;
				objfspeed = (RPM * objPitch * 0.000946961947548);
				objKW = ((objLE * 735.5)/1000);
				objThrust = (objThrust * objBlades);
				objkg = (objThrust * 0.4536);
      			objKTS = (objfspeed / 1.1508);
       			objOZ = (objkg * 35.273962);*/

				return 4000 * integrity;  // HAX
			}
		}

		// ---- Constructors ----
		public Engine(string name, double mass, int power, int RPM, Prop prop)
			: base(name, mass) {
			this.power = power;
			this.RPM = RPM;
			this.prop = prop;
		}
	}

	class Prop {
		// ---- Properties ----
		public string name { get; protected set; }
		public int blades { get; protected set; }
		public int diameter { get; protected set; } // millimeters
		public int pitch { get; protected set; } // millimeters
		public double efficiency { get; protected set; } // percent

		// ---- Constructors ----
		public Prop(string name, int blades, int diameter, int pitch, double efficiency) {
			this.name = name;
			this.blades = blades;
			this.diameter = diameter;
			this.pitch = pitch;
			this.efficiency = efficiency;
		}
	}

	/// <summary>
	/// MK1 Engine
	///   Based off of the Pratt & Whitney R-1340-19 Wasp engine
	/// Mass:   450 kg
	/// Power:  450 kW
	/// RPM:   2250 RPM
	/// </summary>
	class Engine_MK1 : Engine {
		public Engine_MK1() : base("MK1 Engine", 450, 450, 2250, new Prop_MK1()) { }
	}

	/// <summary>
	/// MK1 Prop
	///   For use with the MK1 Engine
	/// Blades:           2
	/// Diameter:      2.28 m
	/// Pitch:         2.80 m
	/// Max Efficiency:  85 %
	/// </summary>
	class Prop_MK1 : Prop {
		public Prop_MK1() : base ("MK1 Prop", 2, 2280, 2800, 0.85) { }
	}
}
