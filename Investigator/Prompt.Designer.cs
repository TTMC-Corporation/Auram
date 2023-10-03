namespace Investigator
{
	partial class Prompt
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prompt));
			value = new System.Windows.Forms.TextBox();
			set = new System.Windows.Forms.Button();
			SuspendLayout();
			// 
			// value
			// 
			value.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			value.ForeColor = System.Drawing.Color.DimGray;
			value.Location = new System.Drawing.Point(12, 12);
			value.Name = "value";
			value.Size = new System.Drawing.Size(400, 40);
			value.TabIndex = 0;
			value.TabStop = false;
			value.Text = "Placeholder";
			value.Enter += value_Enter;
			value.Leave += value_Leave;
			// 
			// set
			// 
			set.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			set.Location = new System.Drawing.Point(12, 58);
			set.Name = "set";
			set.Size = new System.Drawing.Size(400, 40);
			set.TabIndex = 1;
			set.TabStop = false;
			set.Text = "Set Value";
			set.UseVisualStyleBackColor = true;
			set.Click += set_Click;
			// 
			// Prompt
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(425, 111);
			Controls.Add(set);
			Controls.Add(value);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "Prompt";
			Text = "SetValue";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.TextBox value;
		private System.Windows.Forms.Button set;
	}
}