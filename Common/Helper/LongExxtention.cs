using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public static class LongExxtention
    {
        public static long GenerateLongRandom()
        {
            Random r = new Random();
            return r.NextInt64();
        }
    }
}
