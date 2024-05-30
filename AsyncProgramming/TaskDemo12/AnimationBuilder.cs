using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo11
{
    public class AnimationBuilder
    {
        private int frameCount = 0;
        public Film Film { get; set; }

        public AnimationBuilder( Film film)
        {
            Film = film;
        }

        public async Task Build()
        {
            for(int i=0; i< Film.TotalFrames; i++)
            {
                Film.FrameConsumed.WaitOne();

                await Task.Delay(100);
                frameCount++;
                var frame = new AnimationFrame()
                {
                    Id = i
                };
                Film.Frames.Add(frame);
                Console.WriteLine($"Created Frame {frame.Id} {Thread.CurrentThread.ManagedThreadId}");

                Film.FrameProduced.Set(); //set the signal
            }
        }
    }
}
