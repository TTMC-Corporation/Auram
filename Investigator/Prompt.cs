using System;
using System.Drawing;
using System.Windows.Forms;

namespace Investigator
{
	public partial class Prompt : Form
	{
		public string? text = null;
		private string placeholder = string.Empty;
		public Prompt(string title, string button, string placeholder)
		{
			this.placeholder = placeholder;
			InitializeComponent();
			Text = title;
			set.Text = button;
			value.Text = placeholder;
		}
		private void set_Click(object sender, EventArgs e)
		{
			if (value.ForeColor == Color.Black)
			{
				text = value.Text;
				value.Clear();
			}
			Close();
		}
		private void value_Enter(object sender, EventArgs e)
		{
			if (value.ForeColor == Color.DimGray)
			{
				value.Clear();
				value.ForeColor = Color.Black;
			}
		}
		private void value_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(value.Text))
			{
				value.Text = placeholder;
				value.ForeColor = Color.DimGray;
			}
		}
	}
}