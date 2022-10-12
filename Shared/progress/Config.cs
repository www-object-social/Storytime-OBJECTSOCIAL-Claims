using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.progress
{
    class Config
    {
        public readonly string Name;
        private progress.Status _Status;
        private Action ActionChange = null!;
        public event Action Change { 
            add=>ActionChange += value;
            remove => ActionChange -= value;
        }
        internal progress.Status Status {
            get => _Status;
            set
            {
                if (_Status == value||value is Status.StartUp) return;
                _Status = value;
                this.ActionChange?.Invoke();
            }
        }
        public void Done() => Status = Status.Done;
        public void Install() => Status = Status.Install;
        public void Download() => Status = Status.Download;

        public Config(IDevice device,string name,progress.Status status) { 
            this.Name = name;
            this._Status = status;
            device.NetworkChange += () =>
            {
                if (_Status is Status.Download && device.Network is Standard.device.Network.Offline)
                    Status = Status.Done;
            };
        }
    }
}
