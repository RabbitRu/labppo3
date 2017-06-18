using labppo1.InnerStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labppo1.Fileworks
{
    interface ILoader
    {
        DataTree LoadFromFile(string filename);
        void WriteToFile(string filename, DataTree dt);
    }
}
