using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngine
{
    public class Rook : Figure
    {
        public bool IsMoved { get; set; }

        public Rook(int _x, int _y, PlayerType pt, FigureType ft, Engine e, bool isMoved = false) : base(_x, _y, pt, ft, e)
        {
            IsMoved = isMoved;
        }

        public override List<Tuple<int, int>> GetPossibleMoves(Figure[,] table)
        {
            List<Tuple<int, int>> moves = new List<Tuple<int, int>>();

            List<Tuple<int, int>> directions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(-1, 0),
                new Tuple<int, int>(0, -1)
            };

            foreach (var dir in directions)
            {
                int xNew = x + dir.Item1;
                int yNew = y + dir.Item2;

                while (engine.CheckBoundaries(xNew, yNew) && table[xNew, yNew] == null)
                {
                    moves.Add(new Tuple<int, int>(xNew, yNew));
                    xNew += dir.Item1;
                    yNew += dir.Item2;
                }

                if (engine.CheckBoundaries(xNew, yNew) && table[xNew, yNew].player != player)
                    moves.Add(new Tuple<int, int>(xNew, yNew));
            }

            return moves;
        }

        public override void Move(int xNew, int yNew)
        {
            base.Move(xNew, yNew);
            IsMoved = true;
        }
    }
}
