using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using TTMC.Auram;

namespace Investigator
{
	public partial class Base : Form
	{
		private MD5 md5 = MD5.Create();
		private Database database = new();
		private string? current = null;
		private string path = string.Empty;
		public Base(string? path)
		{
			current = path;
			InitializeComponent();
			LoadCurrent();
		}
		private void Enhance(TreeNodeCollection treeNodeCollection, string key)
		{
			if (key.Contains('/'))
			{
				int separator = key.IndexOf('/');
				string before = key[..separator];
				string after = key[(separator + 1)..];
				int index = treeNodeCollection.IndexOfKey(before);
				TreeNode treeNode = index >= 0 ? treeNodeCollection[index] : treeNodeCollection.Add(before, before);
				Enhance(treeNode.Nodes, after);
			}
			else
			{
				treeNodeCollection.Add(key, key);
			}
		}
		private void LoadBase()
		{
			
			Viewer.Nodes.Clear();
			foreach (string key in database.keys)
			{
				Enhance(Viewer.Nodes, key);
			}
		}
		private void LoadCurrent()
		{
			if (!string.IsNullOrEmpty(current))
			{
				Text = $"Investigator [{Path.GetFileName(current)}]";
				database = new Database(current);
				LoadBase();
			}
		}
		private void Viewer_AfterSelect(object? sender = null, TreeViewEventArgs? e = null)
		{
			path = Viewer.SelectedNode.FullPath.Replace('\\', '/');
			string? text = database.Get<string>(path);
			TXT.ForeColor = string.IsNullOrEmpty(text) ? Color.Maroon : Color.Black;
			TXT.Text = path + (string.IsNullOrEmpty(text) ? " (EMPTY)" : " » " + text);
		}
		private void OpenFile()
		{
			database.Close();
			OpenFileDialog open = new();
			open.Title = "Open Auram File";
			open.DefaultExt = "auram";
			open.Filter = "Auram files (*.auram)|*.auram|All files (*.*)|*.*";
			if (open.ShowDialog() == DialogResult.OK)
			{
				current = open.FileName;
				LoadCurrent();
			}
		}
		private void Save(string? path = null)
		{
			if (!string.IsNullOrEmpty(path))
			{
				database.Save(path);
			}
			else
			{
				SaveFileDialog save = new();
				save.Title = "Save Auram File";
				save.DefaultExt = "auram";
				save.Filter = "Auram files (*.auram)|*.auram|All files (*.*)|*.*";
				if (save.ShowDialog() == DialogResult.OK)
				{
					current = save.FileName;
					Save(current);
				}
			}
		}
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFile();
		}
		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Save(current);
		}
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Save();
		}
		private void setStringToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(path))
			{
				Prompt setValue = new("Set Value", "Set Value", "Text");
				setValue.ShowDialog();
				if (!string.IsNullOrEmpty(setValue.text))
				{
					database.Set(path, setValue.text);
					Viewer_AfterSelect();
				}
			}
		}
		private void getHashToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TXT.ForeColor = Color.Teal;
			TXT.Text = Convert.ToHexString(md5.ComputeHash(database.Get(path)));
		}
		private void TXT_DoubleClick(object sender, EventArgs e)
		{
			Clipboard.SetText(TXT.Text);
		}
		private void removeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			database.Remove(path);
			Viewer.SelectedNode.Remove();
		}
		private void connectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Prompt setValue = new("Connect to server", "Connect", "127.0.0.1:13000");
			setValue.ShowDialog();
			if (!string.IsNullOrEmpty(setValue.text))
			{
				if (setValue.text.Contains(':'))
				{
					string[] temp = setValue.text.Split(':');
					if (ushort.TryParse(temp[1], out ushort value))
					{
						database.Connect(temp[0], value);
					}
					else
					{
						database.Connect(temp[0]);
					}
				}
				else
				{
					database.Connect(setValue.text);
				}
				MessageBox.Show("Connected");
				LoadBase();
			}
		}
	}
}