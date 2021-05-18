using Domains_MATH_RUN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATHRUN_PLAYERMAP.Domains
{
    public static class Levels
    {
        public static readonly Level[] AllLevels = Maps.AllMaps
            .Select(map => new Level(map, Difficulty.Easy))
            .ToArray();
    }
}
