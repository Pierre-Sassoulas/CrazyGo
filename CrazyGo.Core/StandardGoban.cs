using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyGo.Core
{
    /// <summary>
    /// Reprensents a standard goban, i.e. rectangular grid without any hole.
    /// </summary>
    public class StandardGoban : Goban
    {
        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public StandardGoban(int height, int width)
        {
            for (int h = 1; h <= height; h++)
            {
                for (int w = 1; w <= width; w++)
                {
                    _positions.Add(new Position(h, w));
                }
            }
        }
    }
}
