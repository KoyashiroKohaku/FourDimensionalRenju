using System;

namespace FourDimensionalRenju.Core
{
    public struct Point : IEquatable<Point>
    {
        public const byte X_COUNT = 7;
        public const byte Y_COUNT = 7;
        public const byte Z_COUNT = 7;
        public const byte S_COUNT = 7;

        private readonly byte _x;
        private readonly byte _y;
        private readonly byte _z;
        private readonly byte _s;

        public Point(byte x, byte y, byte z, byte s)
        {
            if (x >= X_COUNT)
            {
                // TODO: Error message
                throw new ArgumentOutOfRangeException();
            }

            if (y >= Y_COUNT)
            {
                // TODO: Error message
                throw new ArgumentOutOfRangeException();
            }

            if (z >= Z_COUNT)
            {
                // TODO: Error message
                throw new ArgumentOutOfRangeException();
            }

            if (s >= S_COUNT)
            {
                // TODO: Error message
                throw new ArgumentOutOfRangeException();
            }

            _x = x;
            _y = y;
            _z = z;
            _s = s;
        }

        public byte X => _x;
        public byte Y => _y;
        public byte Z => _z;
        public byte S => _s;

        public static bool IsValid(byte x, byte y, byte z, byte s)
        {
            if (x is < 0 or >= X_COUNT)
            {
                return false;
            }

            if (y is < 0 or >= Y_COUNT)
            {
                return false;
            }

            if (z is < 0 or >= Z_COUNT)
            {
                return false;
            }

            if (s <= S_COUNT)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return $"X: {_x}, Y: {_y}, Z: {_z}, S: {_s}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is Move other)
            {
                return Equals(other);
            }

            return false;
        }

        public bool Equals(Point other)
        {
            return _x == other.X && _y == other.Y && _z == other.Z && _s == other.S;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_x, _y, _z, _s);
        }

        public static bool operator ==(Point left, Point right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }
    }
}
