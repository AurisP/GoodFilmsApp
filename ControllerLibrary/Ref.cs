using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLibrary
{
    // Represents a reference to a value of type T.
    public class Ref<T>
    {
        private Func<T> getter;  // Function to retrieve the value.
        private Action<T> setter; // Action to set the value.

        // Initializes a new instance of the Ref class with the specified getter and setter functions.
        // Arguments:
        //   - getter: A function that retrieves the value of type T.
        //   - setter: An action that sets the value of type T.
        public Ref(Func<T> getter, Action<T> setter)
        {
            this.getter = getter;
            this.setter = setter;
        }

        // Gets or sets the current value of type T.
        public T Value
        {
            get { return getter(); }
            set { setter(value); }
        }
    }

}
