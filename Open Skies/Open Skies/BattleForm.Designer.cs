namespace Open_Skies {
	partial class BattleForm {
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
			this.GroupBoxAircraft = new System.Windows.Forms.GroupBox();
			this.deltaComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// GroupBoxAircraft
			// 
			this.GroupBoxAircraft.Location = new System.Drawing.Point(13, 13);
			this.GroupBoxAircraft.Name = "GroupBoxAircraft";
			this.GroupBoxAircraft.Size = new System.Drawing.Size(300, 450);
			this.GroupBoxAircraft.TabIndex = 0;
			this.GroupBoxAircraft.TabStop = false;
			this.GroupBoxAircraft.Text = "Active Aircraft";
			// 
			// deltaComboBox
			// 
			this.deltaComboBox.FormattingEnabled = true;
			this.deltaComboBox.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "1000"});
			this.deltaComboBox.Location = new System.Drawing.Point(72, 499);
			this.deltaComboBox.Name = "deltaComboBox";
			this.deltaComboBox.Size = new System.Drawing.Size(54, 21);
			this.deltaComboBox.TabIndex = 4;
			this.deltaComboBox.Text = "100";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 502);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Delta (ms)";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// BattleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(636, 528);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.deltaComboBox);
			this.Controls.Add(this.GroupBoxAircraft);
			this.Name = "BattleForm";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox GroupBoxAircraft;
		private System.Windows.Forms.ComboBox deltaComboBox;
		private System.Windows.Forms.Label label1;
	}
}

