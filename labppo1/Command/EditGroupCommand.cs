using labppo1.InnerStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labppo1.Command
{
    class EditGroupCommand : ICommand<DataTree>
    {
        private int index;
        private GroupInfo newgroup, oldgroup;

        public EditGroupCommand(GroupInfo grp, int ind)
        {
            newgroup = grp;
            index = ind;
        }

        public DataTree Do(DataTree dt)
        {
            oldgroup = dt[index];
            for (int i = 0; i < oldgroup.Count; i++)
                newgroup.addStudent(oldgroup[i]);
            dt.DeleteGroup(index);
            dt.AddGroup(newgroup, index);
            return dt;
        }

        public DataTree Undo(DataTree dt)
        {
            dt.DeleteGroup(index);
            dt.AddGroup(oldgroup, index);
            return dt;
        }
    }
}
