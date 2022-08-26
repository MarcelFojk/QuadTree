using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Rectangle
{
    public float X;
    public float Y;
    public float width;
    public float height;

    public Rectangle(float x, float y, float _width, float _height)
    {
        X = x;
        Y = y;
        width = _width;
        height = _height;
    }
        
    public bool Contains(Point point)
    {
        if (point.X >= X - width && point.X <= X + width && point.Y >= Y - height && point.Y <= Y + height)
        {
            return true;
        }
        else return false;
    }

    public bool Intersects(Rectangle range)
    {
        if (range.X - range.width > X + width ||
            range.X + range.width < X - width ||
            range.Y - range.height > Y + height ||
            range.Y + range.height < Y - height)
        {
            return false;
        }
        else
        {   
            return true;
        }
    }
}
