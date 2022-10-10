using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    class Progress
    {
        private readonly IDevice Device;
        public progress.Status _Status = progress.Status.StartUp;
        public progress.Status Status {
            get => _Status;
            set {
                if (_Status == value) return;
                _Status = value;
                this.ActionChange?.Invoke();
            }
        }
        private Action ActionChange = null!;
        public event Action Change { 
            add=> ActionChange += value;
            remove => ActionChange -= value;
        }
        private List<progress.Config> Configs=new List<progress.Config>();
        public progress.Config Config(string name, progress.Status status) {
            if (this.Configs.Any(x => x.Name == name))
                return this.Configs.Single(x => x.Name == name);
            var config = new progress.Config(Device, name, status);
            config.Change += Configs_Change;
            this.Configs.Add(config);
            return config;
        }
        private void Configs_Change()
        {
            if (Configs.All(x => x.Status == progress.Status.Done))
            {
                Status = progress.Status.Done;
                return;
            }
            if (Status is progress.Status.Install or progress.Status.StartUp) return;
            if (Configs.Any(x => x.Status == progress.Status.Install)) {
                Status = progress.Status.Install;
                return;
            }
            Status = progress.Status.Download;
        }
        public Progress(IDevice device) {
            this.Device = device;
        }
    }
}
