using labppo1.InnerStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labppo1.Command
{
    class DeleteStudentCommand : ICommand<DataTree>
    {
        private int gindex, sindex;
        private StudentInfo student;

        public DeleteStudentCommand(int gind, int sind)
        {
            gindex = gind;
            sindex = sind;
        }

        public DataTree Undo(DataTree dt)
        {
            dt.AddStudent(student, gindex, sindex);
            return dt;
        }

        public DataTree Do(DataTree dt)
        {
            student = new StudentInfo(dt[gindex][sindex]);
            dt.DeleteStudent(gindex, sindex);
            return dt;
        }
    }
}
