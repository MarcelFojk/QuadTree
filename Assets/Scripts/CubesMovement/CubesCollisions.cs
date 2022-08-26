using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesCollisions : MonoBehaviour
{
    [SerializeField]
    private CubesCreator _cubesCreator;

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private CubesParameters _parameters;

    private List<GameObject> _cubesList;

    private float _cubesCollisionRadius;

    private bool _isSpacePressed = false;

    private List<Point> foundPoints = new();

    private void Start()
    {
        _cubesList = _cubesCreator.listOfCubes;
        _cubesCollisionRadius = _parameters.cubeCollisionRadius;
    }

    private void Update()
    {   
        if (_isSpacePressed)
        {
            CheckForCollision();

            OutOfScreen();
        }
    }

    private void CheckForCollision()
    {   
        float width = _camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, Mathf.Abs(_camera.transform.position.z))).x;
        float height = _camera.ScreenToWorldPoint(new Vector3(0, Screen.height, Mathf.Abs(_camera.transform.position.z))).y;
        
        // Creates Quadtree on visible screen
        Rectangle rec = new Rectangle(0f, 0f, width, height);
        Quadtree qt = new Quadtree(rec, 1);

        // Inserts every cube to the Quadtree
        for (int i = 0; i < _cubesList.Count; i++)
        {
            Point point = new Point(_cubesList[i].transform.position.x, _cubesList[i].transform.position.y, _cubesList[i]);

            qt.Insert(point);
        }

        // for each cube it searches for another cube in the area of the rectangle named "range"
        for (int i = 0; i < _cubesList.Count; i++)
        {
            Rectangle range = new Rectangle(_cubesList[i].transform.position.x, _cubesList[i].transform.position.y, _cubesCollisionRadius * 2, _cubesCollisionRadius * 2);

            List<Point> storedPoints = new();

            // gets all the cubes within the range
            foundPoints = qt.Query(range, storedPoints);

            // checks if cubes collided
            for (int k = 0; k < foundPoints.Count; k++)
            {
                if (_cubesList[i] != foundPoints[k].UserData)
                {
                    bool collided = CheckDistance(_cubesList[i], foundPoints[k].UserData);

                    int index = _cubesList.IndexOf(foundPoints[k].UserData);

                    if (collided)
                    {
                        if (i > index)
                        {
                            Destroy(_cubesList[i]);
                            _cubesList.Remove(_cubesList[i]);

                            Destroy(_cubesList[index]);
                            _cubesList.Remove(_cubesList[index]);

                            break;
                        }
                        else if (i < index)
                        {
                            Destroy(_cubesList[index]);
                            _cubesList.Remove(_cubesList[index]);

                            Destroy(_cubesList[i]);
                            _cubesList.Remove(_cubesList[i]);

                            break;
                        }
                    }
                }
            }
        }
        qt.DrawQuadtree();
    }

    // destroys every out of screen cube
    private void OutOfScreen()
    {
        for (int i = 0; i < _cubesList.Count; i++)
        {
            Vector3 cubePos = _camera.WorldToScreenPoint(_cubesList[i].transform.position);

            if (cubePos.x < 0 || cubePos.y < 0 || cubePos.x > Screen.width || cubePos.y > Screen.height)
            {
                Destroy(_cubesList[i]);
                _cubesList.Remove(_cubesList[i]);
            }
        }
    }

    private bool CheckDistance(GameObject firstCube, GameObject secondCube)
    {
        float distance = (firstCube.transform.position - secondCube.transform.position).magnitude;

        return (distance <= 2 * _cubesCollisionRadius);
    }

    private void SpacePressed()
    {
        _isSpacePressed = true;
    }

    private void OnEnable()
    {
        MovementManager._spacePressed += SpacePressed;
    }

    private void OnDisable()
    {
        MovementManager._spacePressed -= SpacePressed;
    }
}
