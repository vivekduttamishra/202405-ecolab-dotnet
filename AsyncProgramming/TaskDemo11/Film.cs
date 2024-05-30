using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo11
{
    public class Film
    {
        public int TotalFrames { get; set; }
        public List<AnimationFrame> Frames { get; set; } = new List<AnimationFrame>();
    }
}
