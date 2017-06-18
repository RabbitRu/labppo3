using labppo1.InnerStruct;
using labppo1.Pluginworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plugin2
{
    public class Plugin2 : IPlugin
    {
        public TreeView Dt { get; set; }
        public string Name { get { return "Count all students plugin"; } }
        public string Text { get { return "Count all students"; } }
        public string Type { get { return "cms"; } }
        public string Objective { get { return "group"; } }
        public void action(object sender, EventArgs e)
        {
            int scounter = 0, gcounter = 0;
            foreach(TreeNode gp in Dt.Nodes)
            {
                gcounter += 1;
                foreach (TreeNode st in gp.Nodes)
                    scounter += 1;
            }
            MessageBox.Show("Total " + scounter.ToString() + " students in " + gcounter.ToString() + " groups");
        }
    }
}
