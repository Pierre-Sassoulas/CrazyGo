using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyGo.Core
{
    /// <summary>
    /// Provides extension methods for IEnumerable objects.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Returns a random element from an enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static T RandomElement<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.RandomElementUsing(new Random());
        }

        /// <summary>
        /// Returns a random element from an enumerable, using a pre-instantiated random.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="rand"></param>
        /// <returns></returns>
        public static T RandomElementUsing<T>(this IEnumerable<T> enumerable, Random rand)
        {
            int index = rand.Next(0, enumerable.Count());
            return enumerable.ElementAt(index);
        }

        public static bool Contains(this IEnumerable<Position> enumerable, int row, int column)
        {
            return enumerable.Contains(new Position(row, column));
        }

    }
}
