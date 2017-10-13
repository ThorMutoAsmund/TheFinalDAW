using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalDAW.Messaging;

namespace TheFinalDAW.Audio
{
    public class DAWProject
    {
        private string name;

        private List<AudioTrack> tracks;

        private List<IAudible> audibles;

        private bool open;

        public DAWProject()
        {
            GCD.Instance.Register(Messages.Project.RequestClose, () =>
            {
                CloseProject();
            });
            GCD.Instance.Register(Messages.Project.RequestNew, () =>
            {
                NewProject();
            });
            GCD.Instance.Register(Messages.Project.RequestAddTrack, () =>
            {
                if (this.open)
                {
                    this.tracks.Add(new AudioTrack());
                }
            });
        }

        private void NewProject()
        {
            this.name = "untitled project";
            this.tracks = new List<AudioTrack>();
            this.audibles = new List<IAudible>();
            this.open = true;

            GCD.Instance.Emit(Messages.Project.Loaded);
        }

        private void CloseProject()
        {
            this.open = false;

            GCD.Instance.Emit(Messages.Project.Closed);
        }
    }
}
