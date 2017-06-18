using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labppo1.Command
{
    class Reciever<T>
    {
        private Stack<ICommand<T>> sUndo;
        private Stack<ICommand<T>> sRedo;

        public T Do(ICommand<T> action, T input)
        {
            T result = action.Do(input);
            sRedo.Clear();
            sUndo.Push(action);
            return result;
        }
        public T Undo(T input)
        {
            if(sUndo.Count > 0)
            {
                ICommand<T> action = sUndo.Pop();
                T result = action.Undo(input);
                sRedo.Push(action);
                return result;
            }
            return input;
        }

        public T Redo(T input)
        {
            if(sRedo.Count > 0)
            {
                ICommand<T> action = sRedo.Pop();
                T result = action.Do(input);
                sUndo.Push(action);
                return result;
            }
            return input;
        }
        
        public Reciever()
        {
            sUndo = new Stack<ICommand<T>>();
            sRedo = new Stack<ICommand<T>>();
        }
    }
}
