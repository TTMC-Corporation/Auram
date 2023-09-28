using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TTMC.Auram;

namespace Investigator
{
	public partial class Base : Form
	{
		class TreeBuilder
		{
			public int index, depth;
			public string text = string.Empty;
			public Dictionary<string, TreeBuilder> childs = new();
			public void addToTreeVeiw(TreeNode root, TreeBuilder tb)
			{
				foreach (string key in tb.childs.Keys)
				{
					TreeNode t = root.Nodes.Add(tb.childs[key].text);
					addToTreeVeiw(t, tb.childs[key]);
				}
			}
		}
		private Database database = new();
		private string? current = null;
		private string path = string.Empty;
		private Dictionary<string, byte[]> data = new();
		public Base(string? path)
		{
			current = path;
			InitializeComponent();
			TXT.Text = versionString;
			LoadBase();
		}
		private string versionString
		{
			get
			{
				return "TTMC Corporation » Auram Investigator v" + Application.ProductVersion;
			}
		}
		private void LoadBase()
		{
			Text = "Investigator" + (string.IsNullOrEmpty(current) ? string.Empty : $" [{Path.GetFileName(current)}]");
			if (current != null)
			{
				data.Clear();
				try
				{
					database = new Database(current);
					foreach (string key in database.keys)
					{
						data[key] = database.Get(key);
					}
				}
				catch
				{
					MessageBox.Show("Failed to load database");
				}
				var list = new List<string>();
				foreach (string key in data.Keys)
				{
					if (key.StartsWith("Database/"))
					{
						list.Add(key[9..]);
					}
					else
					{
						list.Add(key);
					}
				}
				Viewer.Nodes.Clear();
				TreeBuilder Troot = new TreeBuilder();
				TreeBuilder son;
				Troot.depth = 0;
				Troot.index = 0;
				Troot.text = "Database";
				Troot.childs = new Dictionary<string, TreeBuilder>();
				foreach (string str in list)
				{
					string[] seperated = str.Split('/');
					son = Troot;
					int index = 0;
					for (int depth = 0; depth < seperated.Length; depth++)
					{
						if (son.childs.ContainsKey(seperated[depth]))
						{
							son = son.childs[seperated[depth]];
						}
						else
						{
							son.childs.Add(seperated[depth], new TreeBuilder());
							son = son.childs[seperated[depth]];
							son.index = ++index;
							son.depth = depth + 1;
							son.text = seperated[depth];
							son.childs = new Dictionary<string, TreeBuilder>();
						}
					}
				}
				Viewer.Nodes.Add("Database");
				Troot.addToTreeVeiw(Viewer.Nodes[0], Troot);
			}
		}
		private void Viewer_AfterSelect(object sender, TreeViewEventArgs e)
		{
			try
			{
				path = Viewer.SelectedNode.FullPath.Replace(Path.DirectorySeparatorChar, '/');
				if (path.StartsWith("Database/"))
				{
					path = path[9..];
				}
				TXT.Text = path + " » " + Encoding.UTF8.GetString(data[path]);
				property.SelectedObject = data[path];
			}
			catch
			{
				path = string.Empty;
				TXT.Text = versionString;
				property.SelectedObject = null;
			}
		}
		private void OpenFile()
		{
			OpenFileDialog open = new();
			open.Title = "Open Auram File";
			open.DefaultExt = "auram";
			open.Filter = "Auram files (*.auram)|*.auram|All files (*.*)|*.*";
			if (open.ShowDialog() == DialogResult.OK)
			{
				current = open.FileName;
				LoadBase();
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
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (ModifierKeys == Keys.Control)
			{
				if (e.KeyCode == Keys.S)
				{
					Save(current);
				}
				if (e.KeyCode == Keys.O)
				{
					OpenFile();
				}
				if (e.KeyCode == Keys.N)
				{
					database.Clear();
					Viewer.Nodes.Clear();
				}
				if (e.KeyCode == Keys.W)
				{
					Close();
				}
			}
			else if (ModifierKeys == Keys.F5)
			{
				database.Clear();
				Viewer.Nodes.Clear();
				LoadBase();
			}
			else if (ModifierKeys == Keys.Delete)
			{
				database.Remove(path);
				Viewer.Nodes.RemoveByKey(path);
			}
		}
		private void openToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			OpenFile();
		}
		private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			Save(current);
		}
		private void saveAsToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			Save();
		}
	}
}