using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadtree
{
    private Rectangle _rectangle;

    private int _capacity;

    private List<Point> _points = new();

    private Quadtree northWest;
    private Quadtree northEast;
    private Quadtree southWest;
    private Quadtree southEast;

    private bool _isDivided = false;

    public Quadtree(Rectangle rectangle, int capacity)
    {
        _rectangle = rectangle;
        _capacity = capacity;
    }

    public bool Insert(Point point)
    {
        if (!_rectangle.Contains(point)) return false;

        if (_points.Count < _capacity && !_isDivided)
        {
            _points.Add(point);
            return true;
        }

        if (!_isDivided)
        {
            Subdivide();
        }

        if (northWest.Insert(point))
        {
            return true;
        }
        else if (northEast.Insert(point))
        {
            return true;
        }
        else if (southWest.Insert(point))
        {
            return true;
        }
        else if (southEast.Insert(point))
        {
            return true;
        }

        return false;
    }

    private void Subdivide()
    {
        float x = _rectangle.X;
        float y = _rectangle.Y;
        float w = _rectangle.width;
        float h = _rectangle.height;


        Rectangle nw = new Rectangle(x + w / 2, y + h / 2, w / 2, h / 2);
        northWest = new Quadtree(nw, _capacity);

        Rectangle ne = new Rectangle(x - w / 2, y + h / 2, w / 2, h / 2);
        northEast = new Quadtree(ne, _capacity);

        Rectangle sw = new Rectangle(x + w / 2, y - h / 2, w / 2, h / 2);
        southWest = new Quadtree(sw, _capacity);

        Rectangle se = new Rectangle(x - w / 2, y - h / 2, w / 2, h / 2);
        southEast = new Quadtree(se, _capacity);

        _isDivided = true;
    }

    public List<Point> Query(Rectangle range, List<Point> found)
    {   
        // draws range in which the cubes are searched for
        Debug.DrawLine(new Vector3(range.X - range.width, range.Y - range.height),
            new Vector3(range.X - range.width, range.Y + range.height), Color.red);

        Debug.DrawLine(new Vector3(range.X - range.width, range.Y + range.height),
            new Vector3(range.X + range.width, range.Y + range.height), Color.red);

        Debug.DrawLine(new Vector3(range.X + range.width, range.Y + range.height),
           new Vector3(range.X + range.width, range.Y - range.height), Color.red);

        Debug.DrawLine(new Vector3(range.X + range.width, range.Y - range.height),
            new Vector3(range.X - range.width, range.Y - range.height), Color.red);


        if (!_rectangle.Intersects(range))
        {
            return null;
        }

        if (_isDivided)
        { 
            northWest.Query(range, found);
            northEast.Query(range, found);
            southWest.Query(range, found);
            southEast.Query(range, found);
        }

        for (int i = 0; i < _points.Count; i++)
        {
            if (range.Contains(_points[i]))
            {
                found.Add(_points[i]);
            }
        }

        return found;
    }

    public void DrawQuadtree()
    {   
        Debug.DrawLine(new Vector3(_rectangle.X - _rectangle.width, _rectangle.Y - _rectangle.height), 
            new Vector3(_rectangle.X - _rectangle.width, _rectangle.Y + _rectangle.height), Color.green);

        Debug.DrawLine(new Vector3(_rectangle.X - _rectangle.width, _rectangle.Y + _rectangle.height),
            new Vector3(_rectangle.X + _rectangle.width, _rectangle.Y + _rectangle.height), Color.green);

        Debug.DrawLine(new Vector3(_rectangle.X + _rectangle.width, _rectangle.Y + _rectangle.height),
           new Vector3(_rectangle.X + _rectangle.width, _rectangle.Y - _rectangle.height), Color.green);

        Debug.DrawLine(new Vector3(_rectangle.X + _rectangle.width, _rectangle.Y - _rectangle.height),
            new Vector3(_rectangle.X - _rectangle.width, _rectangle.Y - _rectangle.height), Color.green);

        if (_isDivided)
        {
            northWest.DrawQuadtree();
            northEast.DrawQuadtree();
            southWest.DrawQuadtree();
            southEast.DrawQuadtree();
        }
    }
}
