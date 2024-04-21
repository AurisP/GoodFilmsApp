using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLibrary
{
    public class ConstRef<T>
    {
        private Func<T> getter;
        public ConstRef(Func<T> getter)
        {
            this.getter = getter;
        }
        public T Value
        {
            get { return getter(); }
        }
    }
}
