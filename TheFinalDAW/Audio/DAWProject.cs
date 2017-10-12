using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalDAW.Audio
{
    public class DAWProject
    {
        public List<AudioTrack> Tracks { get; set; }

        public List<IAudible> Audibles { get; set; }
    }
}
