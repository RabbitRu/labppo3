using labppo1.InnerStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labppo1.Command
{
    class EditStudentCommand : ICommand<DataTree>
    {
        private int gindex, sindex;
        private StudentInfo newstudent, oldstudent;

        public EditStudentCommand(StudentInfo st, int gind, int sind)
        {
            newstudent = st;
            gindex = gind;
            sindex = sind;
        }

        public DataTree Do(DataTree dt)
        {
            oldstudent = dt[gindex][sindex];
            dt.DeleteStudent(gindex, sindex);
            dt.AddStudent(newstudent, gindex, sindex);
            return dt;
        }

        public DataTree Undo(DataTree dt)
        {
            dt.DeleteStudent(gindex, sindex);
            dt.AddStudent(oldstudent, gindex, sindex);
            return dt;
        }
    }
}
