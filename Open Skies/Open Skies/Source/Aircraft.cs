using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Skies.Source {
	class Aircraft {
		// Public Independant Properties
		public string name { get; private set; }
		public PartNode basePart { get; private set; }

		// Public Dependant Properties
		public List<PartNode> partList {
			get {
				List<PartNode> list = new List<PartNode>();
				List<PartNode> remaining = new List<PartNode>();
				remaining.Add(basePart);

				while (remaining.Count > 0) {
					PartNode node = remaining.ElementAt(0);
					list.Add(node);
					remaining.Remove(node);

					foreach (PartNode i in node.connectedNodes) {
						if (!remaining.Contains(i)) remaining.Add(i);
					}
				}

				return list;
			}
		}


		// Constructors
		public Aircraft(string name, PartNode basePart) {
			this.name = name;
			this.basePart = basePart;
		}


		// Methods
		public List<Round> Fire(int delta) {
			List<Round> rounds = new List<Round>();
			
			foreach (PartNode node in partList) {
				if (node.part is Gun) {
					List<Round> round = ((Gun)node.part).Shoot(delta);
					if (round != null) rounds.AddRange(round);
				}
			}

			return rounds;
		}
	}

	class PartNode {
		// Public Independant Properties
		public Part part;
		public List<PartNode> connectedNodes { get; private set; }


		// Constructors
		public PartNode(Part part, List<PartNode> connectedNodes) {
			this.part = part;
			this.connectedNodes = connectedNodes;
		}

		
		// Methods
		public bool SeverNode(PartNode node) {
			if (connectedNodes.Contains(node)) {
				// This node is attached to the other node.  Sever the connection.
				connectedNodes.Remove(node);
				node.SeverNode(this);
				return true;
			} else {
				// This node is not attached to the other node.  Do nothing.
				return false;
			}
		}

		public bool AttachNode(PartNode node) {
			if (!connectedNodes.Contains(node)) {
				// This node is not attached to the other node.  Attach it.
				connectedNodes.Add(this);
				node.AttachNode(this);
				return true;
			} else {
				// This node is already attached to the other node.  Do nothing.
				return false;
			}
		}
	}
}
