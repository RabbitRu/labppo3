using labppo1.Command;
using labppo1.InnerStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labppo1.Pluginworks
{
    public interface IPlugin
    {
        TreeView Dt { get; set; }
        string Name { get; }
        string Text { get; }
        string Type { get; }
        string Objective { get; }
        //public event EventHandler<ICommand<DataTree> plEvent;
        void action(object sender, EventArgs e);
    }
}
