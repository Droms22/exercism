using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    public int x;
    public int y;
    public Direction direction;
    
    public RobotSimulator(Direction direction, int x, int y)
    {
        this.x = x;
        this.y = y;
        this.direction = direction;
    }

    public Direction Direction
    {
        get
        {
            return direction;
        }
    }

    public int X
    {
        get
        {
            return x;
        }
    }

    public int Y
    {
        get
        {
            return y;
        }
    }

    public void Move(string instructions)
    {
        foreach (char c in instructions)
        {
            if (c == 'R')
                direction = (Direction) (((int) direction + 1) % 4);
            if (c == 'L')
                direction = (Direction) (((int) direction - 1 + 4) % 4);
            if (c == 'A')
            {
                switch (direction)
                {
                    case Direction.North:
                        y++;
                        break;
                    case Direction.East:
                        x++;
                        break;
                    case Direction.South:
                        y--;
                        break;
                    case Direction.West:
                        x--;
                        break;
                }
            }
        }
    }
}