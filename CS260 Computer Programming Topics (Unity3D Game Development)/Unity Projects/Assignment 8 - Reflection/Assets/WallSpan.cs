//This code manipulates the scale and position of walls
//Based on the perpendicular walls
//When walls are moved, they are dynamic, not static
using UnityEngine;

public class WallSpan : MonoBehaviour
{
    public GameObject topWall;
    public GameObject bottomWall;
    public GameObject rightWall;
    public GameObject leftWall;

    // Use this for initialization
    void Start (){}
	
	// Update is called once per frame
	void Update ()
    {
        //Call custom functions to determine scale and position
        gameObject.transform.localScale = new Vector3(distance() + 1, 1, 1);
        gameObject.transform.position = position();
    }

    float distance()
    {
        //Again, walls are identified by rotation
        if (gameObject.transform.rotation.z != 0)
        {
            //If one wall is positive on the y-axis, and one is negative, then add both
            if (topWall.transform.position.y >= 0.0f && bottomWall.transform.position.y <= 0.0f)
                return Mathf.Abs(topWall.transform.position.y) + Mathf.Abs(bottomWall.transform.position.y);
            //Otherwise, subtract smaller absolute value from the larger absolute value
            else
                return Mathf.Max(Mathf.Abs(topWall.transform.position.y), Mathf.Abs(bottomWall.transform.position.y)) - Mathf.Min(Mathf.Abs(topWall.transform.position.y), Mathf.Abs(bottomWall.transform.position.y));
        }
        else
        {
            //Do same for y-axis
            if (rightWall.transform.position.x >= 0.0f && leftWall.transform.position.x <= 0.0f)
                return Mathf.Abs(rightWall.transform.position.x) + Mathf.Abs(leftWall.transform.position.x);
            else
                return Mathf.Max(Mathf.Abs(rightWall.transform.position.x), Mathf.Abs(leftWall.transform.position.x)) - Mathf.Min(Mathf.Abs(rightWall.transform.position.x), Mathf.Abs(leftWall.transform.position.x));
        }
    }

    Vector3 position()
    {
        if (gameObject.transform.rotation.z != 0)
        {
            //If absolute values of both walls are equal,
            //Then x-axis position of this wall will remain zero
            if (topWall.transform.position.y + bottomWall.transform.position.y == 0)
                return new Vector3(gameObject.transform.position.x, 0, 0);
            //Otherwise, it is the average of both positions
            else
                return new Vector3(gameObject.transform.position.x, (topWall.transform.position.y + bottomWall.transform.position.y) / 2, 0);
        }
        else //gameObject.transform.rotation.z == 0
        {
            //Same, but for y-axis
            if (rightWall.transform.position.x + leftWall.transform.position.x == 0)
                return new Vector3(0, gameObject.transform.position.y, 0);
            else
                return new Vector3((rightWall.transform.position.x + leftWall.transform.position.x) / 2, gameObject.transform.position.y, 0);
        }
    }
}
