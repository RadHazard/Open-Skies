using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Skies.Source {
	internal class Aircraft {
		// ---- Properties ----
		public string Name { get; private set; }
		
		public PartNode BasePart { get; private set; }
		
		public List<PartNode> PartList {
			get {
				if (partListNeedsUpdate) {
					partList = new List<PartNode>();
					List<PartNode> remaining = new List<PartNode>();
					remaining.Add(BasePart);

					while (remaining.Count > 0) {
						PartNode node = remaining.ElementAt(0);
						partList.Add(node);
						remaining.Remove(node);

						foreach (PartNode i in node.connectedNodes) {
							if (!remaining.Contains(i) && !partList.Contains(i)) remaining.Add(i);
						}
					}

					partListNeedsUpdate = false;
				}

				return partList;
			}
		}
		List<PartNode> partList;
		bool partListNeedsUpdate;

		public int PartNumber {
			get {
				return PartList.Count;
			}
		}


		// ---- Constructors ----
		public Aircraft(string name, PartNode basePart) {
			this.Name = name;
			this.BasePart = basePart;
			partListNeedsUpdate = true;
		}


		// ---- Methods ----
		public List<Round> Fire(int delta) {
			List<Round> rounds = new List<Round>();
			
			foreach (PartNode node in PartList) {
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
				connectedNodes.Add(node);
				node.AttachNode(this);
				return true;
			} else {
				// This node is already attached to the other node.  Do nothing.
				return false;
			}
		}
	}
}
