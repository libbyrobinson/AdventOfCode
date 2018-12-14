using System;
using System.Collections.Generic;
using System.Linq;

namespace _2018AdventOfCode.Day13
{
    public class CartTracks
    {
        private List<Cart> _carts;
        private readonly Track[,] _tracks;

        public CartTracks(List<string> trackInput)
        {
            _carts = new List<Cart>();
            _tracks = new Track[trackInput.First().Length,trackInput.Count];

            for (var y = 0; y < _tracks.GetLength(1); y++)
            {
                var row = trackInput[y];
                for (var x = 0; x < _tracks.GetLength(0); x++)
                {
                    var track = new Track(row[x], x, y);
                    if (track.Cart != null)
                    {
                        _carts.Add(track.Cart);
                    }
                    _tracks[x, y] = track;
                }
            }
        }

        public Track MoveCartsUntilCrash()
        {
            while (true)
            {
                _carts.Sort();

                foreach (var cart in _carts)
                {
                    var nextTrack = GetNextTrack(cart);

                    if (nextTrack.Cart != null)
                    {
                        return nextTrack;
                    }

                    cart.MoveTo(nextTrack);
                }
            }
        }

        public Cart MoveCartsUntilAllButOneHaveCrashed()
        {
            while (true)
            {
                _carts.Sort();

                var crashes = new List<Cart>();
                foreach (var cart in _carts)
                {
                    if (crashes.Contains(cart)) continue;

                    var nextTrack = GetNextTrack(cart);

                    if (nextTrack.Cart != null)
                    {
                        crashes.Add(cart);
                        crashes.Add(nextTrack.Cart);
                        cart.CurrentTrack.SetCart(null);
                        nextTrack.SetCart(null);
                    }
                    else
                    {
                        cart.MoveTo(nextTrack);
                    }
                }

                _carts = _carts.Except(crashes).ToList();
                if (_carts.Count == 1)
                {
                    return _carts.First();
                }
            }
        }

        private Track GetNextTrack(Cart cart)
        {
            switch (cart.CurrentDirection)
            {
                case Direction.Up:
                    return _tracks[cart.CurrentTrack.X, cart.CurrentTrack.Y - 1];
                case Direction.Down:
                    return _tracks[cart.CurrentTrack.X, cart.CurrentTrack.Y + 1];
                case Direction.Left:
                    return _tracks[cart.CurrentTrack.X - 1, cart.CurrentTrack.Y];
                case Direction.Right:
                    return  _tracks[cart.CurrentTrack.X + 1, cart.CurrentTrack.Y];
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}