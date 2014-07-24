using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Skies.Source {
	class Aircraft {
		// ---- Properties ----
		public string name { get; private set; }
		public PartNode basePart { get; private set; }
		public List<PartNode> partList {
			get {
				if (partListNeedsUpdate) {
					_partList = new List<PartNode>();
					List<PartNode> remaining = new List<PartNode>();
					remaining.Add(basePart);

					while (remaining.Count > 0) {
						PartNode node = remaining.ElementAt(0);
						_partList.Add(node);
						remaining.Remove(node);

						foreach (PartNode i in node.connectedNodes) {
							if (!remaining.Contains(i)) remaining.Add(i);
						}
					}

					partListNeedsUpdate = false;
				}

				return _partList;
			}
		}

		// ---- Fields ----
		bool partListNeedsUpdate;
		List<PartNode> _partList;

		// ---- Constructors ----
		public Aircraft(string name, PartNode basePart) {
			this.name = name;
			this.basePart = basePart;
			partListNeedsUpdate = true;
		}


		// ---- Methods ----
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
		// ---- Properties ----
		public Part part;
		public List<PartNode> connectedNodes { get; private set; }


		// ---- Constructors ----
		public PartNode(Part part, List<PartNode> connectedNodes) {
			this.part = part;
			this.connectedNodes = connectedNodes;
		}
		
		public PartNode(Part part) {
			this.part = part;
			this.connectedNodes = new List<PartNode>();
		}

		
		// ---- Methods ----
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
