using System;

namespace _2018AdventOfCode.Day13
{
    public class Track : IComparable<Track>
    {
        public Track(char marker, int x, int y)
        {
            X = x;
            Y = y;
            switch (marker)
            {
                case '^':
                case 'v':
                    TrackMarker = '|';
                    Cart = new Cart(marker, this);
                    break;
                case '<':
                case '>':
                    TrackMarker = '-';
                    Cart = new Cart(marker, this);
                    break;
                default:
                    TrackMarker = marker;
                    break;
            }
        }

        public int X { get; }
        public int Y { get; }
        public char TrackMarker { get; }
        public Cart Cart { get; private set; }

        public void SetCart(Cart cart)
        {
            Cart = cart;
        }

        public int CompareTo(Track other)
        {
            if (Y == other.Y)
            {
                if (X == other.X)
                {
                    return 0;
                }
                return X < other.X ? -1 : 1;
            }

            return Y < other.Y ? -1 : 1;
        }
    }
}