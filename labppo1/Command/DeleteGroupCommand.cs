using labppo1.InnerStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labppo1.Command
{
    class DeleteGroupCommand : ICommand<DataTree>
    {
        private int index;
        private GroupInfo group;

        public DeleteGroupCommand(int ind)
        {
            index = ind;
        }

        public DataTree Undo(DataTree dt)
        {
            dt.AddGroup(group, index);
            return dt;
        }

        public DataTree Do(DataTree dt)
        {
            group = new GroupInfo(dt[index]);
            dt.DeleteGroup(index);
            return dt;
        }
    }
}
