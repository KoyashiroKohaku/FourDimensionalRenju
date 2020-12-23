using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Collections.Generic;

namespace FourDimensionalRenju.Core
{
    public class Renju
    {
        private readonly Stack<Move> _moves = new Stack<Move>();
        private readonly Stack<Move> _undoHistoryMoves = new Stack<Move>();

        public IEnumerable<Move> Moves => _moves;
        public IEnumerable<Point> Points => _moves.Select(m => m.Point);

        public Player NextPlayer => _moves.Count % 2 == 0 ? Player.Player1 : Player.Player2;

        public void Clear()
        {
            _moves.Clear();
            _undoHistoryMoves.Clear();
        }

        public void AddMove(Player player, Point point)
        {
            if (player != NextPlayer)
            {
                // TODO: Exception
                throw new ArgumentException();
            }

            if (Contain(point))
            {
                // TODO: Exception
                throw new ArgumentException();
            }

            var move = new Move(player, point);
            _moves.Push(move);
            _undoHistoryMoves.Clear();
        }

        public bool TryAddMove(Player player, Point point, [NotNullWhenAttribute(false)] out string? error)
        {
            if (player != NextPlayer)
            {
                // TODO: Error message
                error = string.Empty;
                return false;
            }

            if (Contain(point))
            {
                // TODO: Error message
                error = string.Empty;
                return false;
            }

            var move = new Move(player, point);
            _moves.Push(move);
            _undoHistoryMoves.Clear();

            error = default;
            return true;
        }

        public void Undo()
        {
            if (_moves.TryPop(out var popped))
            {
                _undoHistoryMoves.Push(popped);
            }
        }

        public void Redo()
        {
            if (_undoHistoryMoves.TryPop(out var popped))
            {
                _moves.Push(popped);
            }
        }

        public bool Contain(Point point)
        {
            return Points.Contains(point);
        }
    }
}
