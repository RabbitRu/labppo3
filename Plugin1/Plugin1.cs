using System;
using System.Windows.Forms;
using labppo1.Pluginworks;

namespace Plugin1
{
    public class Plugin1 : IPlugin
    {

        public TreeView Dt { get; set; }
        public string Name { get { return "Notes plugin"; } }
        public string Text { get { return "Add Note"; } }
        public string Type { get { return "cms"; } }
        public string Objective { get { return "all"; } }
        public void action(object sender, EventArgs e)
        {
            try
            {
                Dt.SelectedNode.ToolTipText = Microsoft.VisualBasic.Interaction.InputBox("Заметка", "Prompt", "Человеки", 0, 0);
            }
            catch { }
        }
    }
}
