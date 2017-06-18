using labppo1.InnerStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labppo1.Command
{
    class AddStudentCommand : ICommand<DataTree>
    {
        private int gindex, sindex;
        private StudentInfo student;

        public AddStudentCommand(StudentInfo stdnt, int gind, int sind)
        {
            student = stdnt;
            gindex = gind;
            sindex = sind;
        }

        public DataTree Do(DataTree dt)
        {
            dt.AddStudent(student, gindex, sindex);
            return dt;
        }

        public DataTree Undo(DataTree dt)
        {
            dt.DeleteStudent(gindex, sindex);
            return dt;
        }
    }
}
