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
            this.worker = new BackgroundWorker(); // TODO: Can't run multiple jobs at once?
            this.worker.DoWork += (sender, args) => ((Action)args.Argument)();
        }
        public void call(int id, Func<TArgument> argument)
        {
            BackgroundWorker w = new BackgroundWorker();
            w.DoWork += (sender, args) => ((Action)args.Argument)();
            w.RunWorkerAsync(new Action(() => {
                Thread.Sleep(10); // TODO: may need adjusting
                callback(id, argument());
            }));
            /*worker.RunWorkerAsync(new Action(() => {
                Thread.Sleep(10); // TODO: may need adjusting
                callback(id, argument());
            }));*/
        }
    }
}
