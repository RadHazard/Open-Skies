namespace Open_Skies {
	partial class AircraftForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.GroupBoxParts = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// GroupBoxParts
			// 
			this.GroupBoxParts.AutoSize = true;
			this.GroupBoxParts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.GroupBoxParts.Location = new System.Drawing.Point(12, 12);
			this.GroupBoxParts.Name = "GroupBoxParts";
			this.GroupBoxParts.Size = new System.Drawing.Size(6, 19);
			this.GroupBoxParts.TabIndex = 1;
			this.GroupBoxParts.TabStop = false;
			this.GroupBoxParts.Text = "Parts";
			// 
			// AircraftForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(321, 472);
			this.Controls.Add(this.GroupBoxParts);
			this.Name = "AircraftForm";
			this.Text = "AirplaneForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox GroupBoxParts;
	}
}