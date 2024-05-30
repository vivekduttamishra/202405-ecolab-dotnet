using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo11
{
    public class AnimationPresenter
    {
     
        public Film Film { get; set; }

        public AnimationPresenter(Film film)
        {
            Film = film;
        }

        public async Task Present()
        {
            int i = 0;
            while(i<Film.TotalFrames)
            {

                //while(Film.Frames.Count<=0)
                //    Console.Write(".");

                Film.FrameProduced.WaitOne(); //wait for the signal
                //Film.FrameProduced.Reset(); //needed for ManualResetEvent

                var frame = Film.Frames[0];
                Film.Frames.RemoveAt(0);
                Console.WriteLine($"Displaying Frame {frame.Id}");
                await Task.Delay(1000);
                i++;

                Film.FrameConsumed.Set();
                
            }
        }
    }
}
