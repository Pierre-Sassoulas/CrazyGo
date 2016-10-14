using CrazyGo.Core;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace CrazyGo.WPF.ViewModel
{
    public class GobanViewModel
    {
        public struct Cell
        {
            public int Row { get; set; }
            public int Column { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public string Name { get { return Row + "," + Column; } }
            public SolidColorBrush Color { get; set; }

        }

        public ObservableCollection<Cell> Cells { get; private set; }

        public ObservableCollection<string> RowNumbers { get; private set; }

        public int CellSize { get; private set; }

        public void LoadGoban()
        {
            CellSize = 50;

            var goban = new RegularGoban(9, 9);

            RowNumbers = new ObservableCollection<string>();
            for (int i = 1; i <= goban.GetHeight(); i++)
            {
                RowNumbers.Add(i.ToString());
            }

            Cells = new ObservableCollection<Cell>();
            var r = new Random();
            foreach (var position in goban.Positions)
            {
                var cell = new Cell()
                {
                    Row = (position.Row - 1) * CellSize,
                    Column = (position.Column - 1) * CellSize,
                    Width = CellSize,
                    Height = CellSize
                };
                cell.Color = new SolidColorBrush();
                byte[] rgb = new byte[3];
                r.NextBytes(rgb);
                cell.Color.Color = System.Windows.Media.Color.FromArgb(150, rgb[0], rgb[1], rgb[2]);
                Cells.Add(cell);
            }
        }
    }
}