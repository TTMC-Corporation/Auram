
namespace Investigator
{
	partial class Base
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Base));
			Viewer = new System.Windows.Forms.TreeView();
			TXT = new System.Windows.Forms.Label();
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			setStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			getHashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// Viewer
			// 
			Viewer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			Viewer.BackColor = System.Drawing.SystemColors.Window;
			Viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			Viewer.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			Viewer.ForeColor = System.Drawing.Color.Black;
			Viewer.Indent = 30;
			Viewer.Location = new System.Drawing.Point(12, 27);
			Viewer.Name = "Viewer";
			Viewer.Size = new System.Drawing.Size(1176, 572);
			Viewer.TabIndex = 2;
			Viewer.AfterSelect += Viewer_AfterSelect;
			// 
			// TXT
			// 
			TXT.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			TXT.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			TXT.ForeColor = System.Drawing.Color.Black;
			TXT.Location = new System.Drawing.Point(12, 602);
			TXT.Name = "TXT";
			TXT.Size = new System.Drawing.Size(1176, 19);
			TXT.TabIndex = 3;
			TXT.Text = "TTMC Corporation » Auram Investigator";
			TXT.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			TXT.DoubleClick += TXT_DoubleClick;
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, toolsToolStripMenuItem });
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new System.Drawing.Size(1200, 24);
			menuStrip1.TabIndex = 4;
			menuStrip1.Text = "menu";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, connectToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			openToolStripMenuItem.Name = "openToolStripMenuItem";
			openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			openToolStripMenuItem.Text = "Open";
			openToolStripMenuItem.Click += openToolStripMenuItem_Click;
			// 
			// saveToolStripMenuItem
			// 
			saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			saveToolStripMenuItem.Text = "Save";
			saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
			// 
			// saveAsToolStripMenuItem
			// 
			saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			saveAsToolStripMenuItem.Text = "Save As";
			saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
			// 
			// editToolStripMenuItem
			// 
			editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { setStringToolStripMenuItem, removeToolStripMenuItem });
			editToolStripMenuItem.Name = "editToolStripMenuItem";
			editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			editToolStripMenuItem.Text = "Edit";
			// 
			// setStringToolStripMenuItem
			// 
			setStringToolStripMenuItem.Name = "setStringToolStripMenuItem";
			setStringToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			setStringToolStripMenuItem.Text = "Set string";
			setStringToolStripMenuItem.Click += setStringToolStripMenuItem_Click;
			// 
			// removeToolStripMenuItem
			// 
			removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			removeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			removeToolStripMenuItem.Text = "Remove";
			removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
			// 
			// toolsToolStripMenuItem
			// 
			toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { getHashToolStripMenuItem });
			toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			toolsToolStripMenuItem.Text = "Tools";
			// 
			// getHashToolStripMenuItem
			// 
			getHashToolStripMenuItem.Name = "getHashToolStripMenuItem";
			getHashToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			getHashToolStripMenuItem.Text = "Get Hash";
			getHashToolStripMenuItem.Click += getHashToolStripMenuItem_Click;
			// 
			// connectToolStripMenuItem
			// 
			connectToolStripMenuItem.Name = "connectToolStripMenuItem";
			connectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			connectToolStripMenuItem.Text = "Connect";
			connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
			// 
			// Base
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Window;
			ClientSize = new System.Drawing.Size(1200, 630);
			Controls.Add(TXT);
			Controls.Add(Viewer);
			Controls.Add(menuStrip1);
			Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = menuStrip1;
			Name = "Base";
			Text = "Investigator";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private System.Windows.Forms.TreeView Viewer;
		private System.Windows.Forms.Label TXT;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem setStringToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem getHashToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
	}
}

