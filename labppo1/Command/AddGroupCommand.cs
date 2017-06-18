using labppo1.InnerStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labppo1.Command
{
    class AddGroupCommand : ICommand<DataTree>
    {
        private int index;
        private GroupInfo group;

        public AddGroupCommand(GroupInfo grp,int ind)
        {
            group = grp;
            index = ind;
        }

        public DataTree Do(DataTree dt)
        {
            dt.AddGroup(group, index);
            return dt;
        }

        public DataTree Undo(DataTree dt)
        {
            dt.DeleteGroup(index);
            return dt;
        }
    }
}
