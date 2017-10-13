using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalDAW.Audio
{
    public class AudioTrack
    {
        public string Name { get; set; }

        public List<AudibleReference> AudioRefs { get; set; }

        public List<IEffect> Effects { get; set; }

    }
}
