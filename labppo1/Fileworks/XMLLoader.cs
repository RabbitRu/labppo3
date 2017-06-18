using labppo1.InnerStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace labppo1.Fileworks
{
    class XMLLoader : ILoader
    {
        public DataTree LoadFromFile(string filename)
        {
            XmlDocument file = new XmlDocument();
            file.Load(filename);
          
            DataTree dt = new DataTree();

            foreach(XmlNode group in file.DocumentElement)
            {
                dt.AddGroup(new GroupInfo(group.Attributes[0].Value));

                XmlNode students = group.FirstChild;
                foreach (XmlNode student in students.ChildNodes)
                {
                    try
                    {
                        dt[dt.Count - 1].addStudent(student["surname"].InnerText,
                            student["name"].InnerText,
                            student["middleName"].InnerText,
                            int.Parse(student["rating"].InnerText),
                            "default.bmp");
                    }
                    catch
                    {
                        //out of range rating message
                    }
                }
            }

            return dt;
        }

        public void WriteToFile(string filename, DataTree dt)
        {
            XmlTextWriter textWriter = new XmlTextWriter(filename, Encoding.UTF8);
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("groups");

            textWriter.WriteEndElement();
            textWriter.WriteEndDocument();

            textWriter.Close();

            XmlDocument file = new XmlDocument();
            file.Load(filename);

            for (int i = 0; i < dt.Count; i++)
            {
                XmlNode group = file.CreateElement("group");
                file.DocumentElement.AppendChild(group);
                XmlAttribute attribute = file.CreateAttribute("name");
                attribute.Value = dt[i].Groupname;
                group.Attributes.Append(attribute);

                XmlNode students = file.CreateElement("students");
                group.AppendChild(students);

                for (int j = 0; j < dt[i].Count; j++)
                {
                    XmlNode student = file.CreateElement("student");
                    students.AppendChild(student);

                    XmlNode surname = file.CreateElement("surname");
                    surname.InnerText = dt[i][j].Surname;
                    student.AppendChild(surname);

                    XmlNode name = file.CreateElement("name");
                    name.InnerText = dt[i][j].Firstname;
                    student.AppendChild(name);

                    XmlNode middlename = file.CreateElement("middleName");
                    middlename.InnerText = dt[i][j].Middlename;
                    student.AppendChild(middlename);

                    XmlNode rating = file.CreateElement("rating");
                    rating.InnerText = dt[i][j].Rating.ToString();
                    student.AppendChild(rating);
                }
            }

            file.Save(filename);
        }
    }
}
