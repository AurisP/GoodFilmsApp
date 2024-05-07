using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLibrary
{
    // Represents a constant reference to a value of type T.
    public class ConstRef<T>
    {
        private Func<T> getter;

        // Initializes a new instance of the ConstRef class with the specified getter function.
        // Arguments:
        //   - getter: A function that retrieves the value of type T.
        public ConstRef(Func<T> getter)
        {
            this.getter = getter;
        }

        // Gets the current value of type T.
        public T Value
        {
            get { return getter(); }
        }
    }

}
