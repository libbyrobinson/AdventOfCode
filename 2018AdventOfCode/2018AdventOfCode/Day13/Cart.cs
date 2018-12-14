using System;

namespace _2018AdventOfCode.Day13
{
    public class Cart : IComparable<Cart>
    {
        public Cart(char marker, Track track)
        {
            CurrentTrack = track;
            _nextTurnDirection = Direction.Left;
            switch (marker)
            {
                case '^':
                    CurrentDirection = Direction.Up;
                    break;
                case 'v':
                    CurrentDirection = Direction.Down;
                    break;
                case '<':
                    CurrentDirection = Direction.Left;
                    break;
                case '>':
                    CurrentDirection = Direction.Right;
                    break;
            }
        }

        public Track CurrentTrack { get; private set; }
        public Direction CurrentDirection { get; private set; }

        public void MoveTo(Track newTrack)
        {
            CurrentTrack.SetCart(null);
            CurrentTrack = newTrack;
            newTrack.SetCart(this);

            if (newTrack.TrackMarker == '+')
            {
                EnterIntersection();
            }

            if (newTrack.TrackMarker == '/' || newTrack.TrackMarker == '\\')
            {
                TurnCorner(newTrack.TrackMarker);
            }
        }

        private void TurnCorner(char cornerMarker)
        {
            if (CurrentDirection == Direction.Up || CurrentDirection == Direction.Down)
            {
                if (cornerMarker == '/')
                {
                    TurnRight();
                }
                else
                {

                    TurnLeft();
                }
            }

            else if (CurrentDirection == Direction.Left || CurrentDirection == Direction.Right)
            {
                if (cornerMarker == '/')
                {
                    TurnLeft();
                }
                else
                {
                    TurnRight();
                }
            }
        }

        private Direction _nextTurnDirection;
        private void EnterIntersection()
        {
            switch (_nextTurnDirection)
            {
                case Direction.Left:
                    TurnLeft();
                    _nextTurnDirection = Direction.Straight;
                    break;
                case Direction.Right:
                    TurnRight();
                    _nextTurnDirection = Direction.Left;
                    break;
                case Direction.Straight:
                    _nextTurnDirection = Direction.Right;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TurnLeft()
        {
            switch (CurrentDirection)
            {
                case Direction.Up:
                    CurrentDirection = Direction.Left;
                    break;
                case Direction.Down:
                    CurrentDirection = Direction.Right;
                    break;
                case Direction.Left:
                    CurrentDirection = Direction.Down;
                    break;
                case Direction.Right:
                    CurrentDirection = Direction.Up;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TurnRight()
        {
            switch (CurrentDirection)
            {
                case Direction.Up:
                    CurrentDirection = Direction.Right;
                    break;
                case Direction.Down:
                    CurrentDirection = Direction.Left;
                    break;
                case Direction.Left:
                    CurrentDirection = Direction.Up;
                    break;
                case Direction.Right:
                    CurrentDirection = Direction.Down;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public int CompareTo(Cart other)
        {
            return CurrentTrack.CompareTo(other.CurrentTrack);
        }
    }
}