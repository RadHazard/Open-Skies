using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Skies.Source {
	class Gun : Part {
		// ---- Properties ----
		public int Caliber { get; protected set; } // hundreths of a millimeter
		
		public Belt Belt { get; protected set; }
		
		new public double Mass { // kilograms
			get {
				return base.Mass + Belt.Mass;
			}
			protected set {
				base.Mass = value;
			}
		}

		public int RateOfFire { // rounds per minute
			get {
				return 60000 / rofDelta;
			}
			protected set {
				rofDelta = 60000 / value;
			}
		}
		
		public int RemainingAmmo {
			get {
				if (Belt != null)
					return (Belt.Size - currentRound);
				else
					return 0;
			}
		}

		// ---- Fields ----
		private int currentRound; // position in belt, zero based
		private int rofDelta; // milliseconds
		private int cooldown; // milliseconds


		// ---- Constructors ----
		public Gun(string name, double mass, int caliber, int rateOfFire, Belt belt) : base(name, mass) {
			this.RateOfFire = rateOfFire;
			this.Belt = belt;
			this.currentRound = 0;
			this.cooldown = 0;
		}

		public Gun(string name, double mass, int caliber, int rateOfFire) : base(name, mass) {
			this.RateOfFire = rateOfFire;
			this.Belt = null;
			this.currentRound = 0;
			this.cooldown = 0;
		}


		// ---- Methods ----
		public List<Round> Shoot(int delta) {
			List<Round> rounds = new List<Round>();

			cooldown -= delta;
			while (cooldown < 0 && RemainingAmmo > 0) {
				cooldown += rofDelta;
				rounds.Add(Belt.Rounds[currentRound++]);
			}

			if (cooldown < 0) cooldown = 0;
			return rounds;
		}

		public void Reload(Belt belt) {
			if (belt.Caliber == Caliber) {
				this.Belt = belt;
				this.currentRound = 0;
				this.cooldown = 0;
			} else {
				throw new Exception("Incorrect belt caliber");
			}
		}
	}

	class Belt {
		// ---- Properties ----
		public string Name { get; private set; }
		
		public int Caliber { get; private set; }
		
		public Round[] Rounds { get; private set; }
		
		public int Size {
			get {
				return Rounds.Length;
			}
		}

		public double Mass { // kilograms
			get {
				double m = 0;
				for (int i = 0; i < Size; i++)
					m += Rounds[i].Mass;
				return m;
			}
		}


		// ---- Constructors ----
		private Belt(string name, int caliber) {
			this.Name = name;
			this.Caliber = caliber;
		}

		public Belt(string name, int caliber, Round[] belt)
			: this(name, caliber) {
			this.Rounds = (Round[])belt.Clone();
		}

		public Belt(string name, int caliber, Round[] pattern, int size)
			: this (name, caliber) {
			this.Rounds = new Round[size];
			for (int i = 0; i < size; i++)
				this.Rounds[i] = pattern[i % pattern.Length];
		}
	}

	class Round {
		// ---- Properties ----
		public string Name { get; private set; }
		
		public int Caliber { get; private set; } // hundreths of a millimeter
		
		public double Mass { get; private set; } // kilograms
		
		public double ProjectileMass { get; private set; } // kilograms
		
		public double MuzzleVelocity { get; private set; } // meters/second


		// ---- Constructors ----
		public Round(string name, int caliber, double mass, double projectileMass, double muzzleVelocity) {
			this.Name = name;
			this.Caliber = caliber;
			this.Mass = mass;
			this.ProjectileMass = projectileMass;
			this.MuzzleVelocity = muzzleVelocity;
		}
	}

	/// <summary>
	/// MK1 Gun
	///   Based on the Browning M1919 AN/M2 variant
	/// Mass:            10 kg
	/// caliber:       7.62 mm
	/// Rate of Fire:  1200 round/min
	/// 
	/// </summary>
	class Gun_MK1 : Gun {
		public Gun_MK1() : base("MK1 Gun", 10, 762, 1200) { }
	}

	/// <summary>
	/// MK1 Belt
	///   Belt full of MK1 Ball rounds
	/// Total Mass:   20 kg
	/// Ammo Count:  500 rounds
	/// </summary>
	class MK1Belt : Belt {
		private static Round[] pattern = new Round[] {
			new MK1Ball()
		};
		public MK1Belt() : base("MK1 Belt", 762, pattern, 500) { } 
	}

	/// <summary>
	/// MK1 Ball Round
	///   Based on the .30-06 springfield round, Ball M2 variant
	/// caliber:         7.62 mm
	/// Bullet Mass:       10 g
	/// Cartridge Mass:    40 g (including links)
	/// Muzzle Velocity:  850 m/s
	/// </summary>
	class MK1Ball : Round {
		public MK1Ball() : base("MK1 Ball", 762, 0.01, 0.03, 850) { }
	}
}
