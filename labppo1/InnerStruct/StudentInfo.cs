using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labppo1.InnerStruct
{
    class StudentInfo
    {
        private string firstname;
        private string surname;
        private string middlename;
        private string avatar;
        private int rating;

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Middlename
        {
            get { return middlename; }
            set { middlename = value; }
        }
        public string Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }
        public int Rating
        {
            get { return rating; }
            set
            {
                if (value > 100)
                    rating = 100;
                else
                {
                    if (value < 0)
                        rating = 0;
                    else
                        rating = value;
                }
            }
        }

        public StudentInfo(string surname, string firstname, string middlename, int rating, string avatar)
        {
            Surname = surname;
            Firstname = firstname;
            Middlename = middlename;
            Rating = rating;
            Avatar = avatar;
        }

        public StudentInfo(StudentInfo sinfo)
        {
            Surname = sinfo.Firstname;
            Firstname = sinfo.Firstname;
            Middlename = sinfo.Middlename;
            Rating = sinfo.Rating;
            Avatar = sinfo.Avatar;
        }
    }
}
