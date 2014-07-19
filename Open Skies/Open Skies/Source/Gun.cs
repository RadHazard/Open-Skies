using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Skies.Source {
	class Gun : Part {
		// Independant Public Properties
		public int calibur { get; private set; } // hundreths of a millimeter
		public Belt belt { get; private set; }

		// Independant Private Properties
		private int currentRound;
		private int rofDelta; // milliseconds
		private int cooldown;

		// Dependant Public Properties
		public double mass {
			get {
				return base.mass + belt.mass;
			}
			set {
				base.mass = value;
			}
		}

		public int rateOfFire { // rounds per minute
			get {
				return 60000 / rofDelta;
			}
			private set {
				rofDelta = 60000 / value;
			}
		}

		public int remainingAmmo {
			get {
				if (belt != null)
					return (belt.length - currentRound);
				else
					return 0;
			}
		}


		// Constructors
		public Gun(string name, double mass, int rateOfFire, Belt belt) : base(name, mass) {
			this.rateOfFire = rateOfFire;
			this.belt = belt;
			this.currentRound = 0;
			this.cooldown = 0;
		}

		public Gun(string name, double mass, int rateOfFire) : base(name, mass) {
			this.rateOfFire = rateOfFire;
			this.belt = null;
			this.currentRound = 0;
			this.cooldown = 0;
		}


		// Methods
		internal List<Round> Shoot(int delta) {
			List<Round> rounds = new List<Round>();

			cooldown -= delta;
			while (cooldown < 0 && remainingAmmo > 0) {
				cooldown += rofDelta;
				rounds.Add(belt.rounds[currentRound++]);
			}

			if (cooldown < 0) cooldown = 0;
			return rounds;
		}

		public void Reload(Belt belt) {
			this.belt = belt;
			this.currentRound = 0;
			this.cooldown = 0;
		}
	}

	class Belt {
		// Public Independant Properties
		public string name { get; private set; }
		public int calibur { get; private set; }
		public Round[] rounds { get; private set; }

		// Public Dependant Properties
		public int length {
			get {
				return rounds.Length;
			}
		}
		public double mass {
			get {
				double m = 0;
				for (int i = 0; i < length; i++)
					m += rounds[i].mass;
				return m;
			}
		}


		// Constructors
		public Belt(string name, int calibur, Round[] ammo) {
			this.name = name;
		}
	}

	class Round {
		// Independant Public Properties
		public int calibur { get; private set; }
		public double mass { get; private set; }
		public double projectileMass { get; private set }
		public double muzzleVelocity { get; private set; }


		// Constructor
		Round(int calibur, double mass, double projectileMass, double muzzleVelocity) {
			this.calibur = calibur;
			this.mass = mass;
			this.projectileMass = projectileMass;
			this.muzzleVelocity = muzzleVelocity;
		}
	}
}
