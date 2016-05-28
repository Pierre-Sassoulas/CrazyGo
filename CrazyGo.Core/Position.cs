using System;

namespace CrazyGo.Core
{
    /// <summary>
    /// Represents a position on the goban game.
    /// </summary>
    public struct Position : IEquatable<Position>
    {
        private int _row;
        private int _column;

        /// <summary>
        /// The row coordinate.
        /// </summary>
        public int Row
        {
            get { return _row; }
        }        

        /// <summary>
        /// The column coordinate.
        /// </summary>
        public int Column
        {
            get { return _column; }
        }

        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="row">The row coordinate.</param>
        /// <param name="column">The column coordinate.</param>
        public Position(int row, int column)
        {
            _row = row;
            _column = column;
        }

        /// <summary>
        /// Returns true if p1 and p2 have same rows and same columns.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Position && this == (Position)obj;
        }

        /// <summary>
        /// Returns a combination of Row hash code and Column hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _row.GetHashCode() ^ _column.GetHashCode();
        }

        /// <summary>
        /// Returns true if both positions have same rows and same columns.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Position other)
        {
            return this == other;
        }

        /// <summary>
        /// Returns true if p1 and p2 have same rows and same columns.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Position p1, Position p2)
        {
            return p1._row == p2._row && p1._column == p2._column;
        }

        /// <summary>
        /// Returns true if p1 and p2 have different rows or different columns.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Position p1, Position p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Returns "(row,column)".
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "(" + _row + "," + _column + ")";
        }
    }
}
