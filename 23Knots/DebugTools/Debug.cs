using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23Knots.DebugTools
{
    public static class Debug
    {
        public static bool EnableFrameRateCounter { get; set; } = true;
        private static readonly FrameRateCounter FrameRateCounter = new FrameRateCounter();

        public static void Draw()
        {
            if (EnableFrameRateCounter)
                FrameRateCounter.Draw();
        }
    }
}
