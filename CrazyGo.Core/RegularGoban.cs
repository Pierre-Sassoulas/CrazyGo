using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyGo.Core
{
    /// <summary>
    /// Reprensents a regular goban, i.e. rectangular grid without any hole.
    /// </summary>
    public class RegularGoban : Goban
    {
        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public RegularGoban(int height, int width)
        {
            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    _positions.Add(new Position(h, w));
                }
            }
        }
    }
}
