using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControllerLibrary
{
    public class CCallback<TArgument>
    {
        private Action<int, TArgument> callback;
        private BackgroundWorker worker;
        public CCallback(Action<int, TArgument> callback)
        {
            this.callback = callback;
            this.worker = new BackgroundWorker();
            this.worker.DoWork += (sender, args) => ((Action)args.Argument)();
        }
        public void call(int id, Func<TArgument> argument)
        {
            worker.RunWorkerAsync(new Action(() => {
                Thread.Sleep(10); // TODO: may need adjusting
                callback(id, argument());
            }));
        }
    }
}
