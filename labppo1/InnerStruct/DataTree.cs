using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labppo1.InnerStruct
{
    class DataTree
    {
        private List<GroupInfo> groups;

        public void AddGroup(GroupInfo group)
        {
            groups.Add(group);
        }

        public void AddGroup(GroupInfo group, int index)
        {
            groups.Insert(index, group);
        }

        public void DeleteGroup(int index)
        {
            groups[index].Clear();
            groups.RemoveAt(index);
        }

        public void AddStudent(StudentInfo student, int group)
        {
            groups[group].addStudent(student);
        }

        public void AddStudent(StudentInfo student, int group, int index)
        {
            groups[group].addStudent(student,index);
        }

        public void DeleteStudent(int gindex, int sindex)
        {
            groups[gindex].DeleteStudent(sindex);
        }

        public GroupInfo this[int index]
        {
            get
            {
                if (index >= 0 && index < groups.Count)
                    return groups[index];
                throw new IndexOutOfRangeException();
            }
        }

        public int Count
        {
            get
            {
                return groups.Count;
            }
        }

        public void Clear()
        {
            groups.Clear();
        }

        public DataTree()
        {
            groups = new List<GroupInfo>();
        }
    }
}
