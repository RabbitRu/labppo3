using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labppo1.Command
{
    interface ICommand<T>
    {
        T Do(T action);
        T Undo(T action);
    }
}
