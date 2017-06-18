using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labppo1.InnerStruct
{
    class GroupInfo
    {
        private List<StudentInfo> students;
        private string groupname;

        public string Groupname{ get; set; }

        public int Count
        {
            get
            {
                return students.Count;
            }
        }

        public int MaxRating
        {
            get
            {
                int max = 0;
                foreach (StudentInfo student in students)
                    if (student.Rating > max)
                        max = student.Rating;
                return max;
            }
        }
        public int MinRating
        {
            get
            {
                int min = 100;
                foreach (StudentInfo student in students)
                    if (student.Rating < min)
                        min = student.Rating;
                return min;
            }
        }
        public int AvRating
        {
            get
            {
                int av = 0;
                if (students.Count > 0)
                {
                    foreach (StudentInfo student in students)
                        av += student.Rating;
                    av /= students.Count;
                }
                return av;
            }
        }

        public StudentInfo this[int index]
        {
            get
            {
                if (index >= 0 && index < students.Count)
                    return students[index];
                throw new IndexOutOfRangeException();
            }
        }

        public void addStudent(StudentInfo student, int index)
        {
            students.Insert(index, student);
        }

        public void addStudent(string surname, string firstname, string middlename, int rating, string avatar, int index)
        {
            students.Insert(index, new StudentInfo(surname, firstname, middlename, rating, avatar));
        }
        public void addStudent(StudentInfo student)
        {
            students.Add(student);
        }

        public void addStudent(string surname, string firstname, string middlename, int rating, string avatar)
        {
            students.Add(new StudentInfo(surname, firstname, middlename, rating, avatar));
        }

        public void DeleteStudent(int index)
        {
            students.RemoveAt(index);
        }

        public void Clear()
        {
            students.Clear();
        }

        public GroupInfo(string gname)
        {
            students = new List<StudentInfo>();
            Groupname = gname;
        }

        public GroupInfo(GroupInfo grp)
        {
            Groupname = grp.Groupname;
            students = new List<StudentInfo>(grp.students);
        }
    }
}
