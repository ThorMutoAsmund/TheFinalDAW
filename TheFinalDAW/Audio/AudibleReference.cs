using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalDAW.Audio
{
    public class AudibleReference
    {
        public IAudible Audible { get; set; }

        public double Length { get; set; }

        public double StartTime { get; set; }

    }
}
