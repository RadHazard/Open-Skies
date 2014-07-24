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
			this.airplaneGroupBox1 = new System.Windows.Forms.GroupBox();
			this.airplaneGroupBox2 = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// airplaneGroupBox1
			// 
			this.airplaneGroupBox1.Location = new System.Drawing.Point(13, 13);
			this.airplaneGroupBox1.Name = "airplaneGroupBox1";
			this.airplaneGroupBox1.Size = new System.Drawing.Size(332, 537);
			this.airplaneGroupBox1.TabIndex = 0;
			this.airplaneGroupBox1.TabStop = false;
			this.airplaneGroupBox1.Text = "Airplane 1";
			// 
			// airplaneGroupBox2
			// 
			this.airplaneGroupBox2.Location = new System.Drawing.Point(395, 13);
			this.airplaneGroupBox2.Name = "airplaneGroupBox2";
			this.airplaneGroupBox2.Size = new System.Drawing.Size(332, 537);
			this.airplaneGroupBox2.TabIndex = 1;
			this.airplaneGroupBox2.TabStop = false;
			this.airplaneGroupBox2.Text = "Airplane 2";
			// 
			// BattleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(739, 562);
			this.Controls.Add(this.airplaneGroupBox2);
			this.Controls.Add(this.airplaneGroupBox1);
			this.Name = "BattleForm";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox airplaneGroupBox1;
		private System.Windows.Forms.GroupBox airplaneGroupBox2;
	}
}

