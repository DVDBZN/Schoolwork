using UnityEngine;

public class Physics : MonoBehaviour
{
    public float xVel;
    public float xPos;
    public float yVel;
    public float yPos;

    public GameObject topWall;
    public GameObject bottomWall;
    public GameObject rightWall;
    public GameObject leftWall;

	// Use this for initialization
	void Start ()
    {
        //Create random starting velocities
        //These values also determine the direction
        xVel = Random.Range(-10.0f, 10.0f);
        yVel = Random.Range(-10.0f, 10.0f);
        //Destroy object after ten seconds
        Destroy(gameObject, 10);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Add velocities to x and y positions
        xPos += xVel;
        yPos += yVel;

        //Move object to new poistion
        transform.position = new Vector3(xPos / 10, yPos / 10, 0);

        //If object hits side walls, change direction
        if (gameObject.transform.position.x >= border(rightWall) || gameObject.transform.position.x <= border(leftWall))
            xVel *= -1;
        
        //If object hits top or bottom wall, change direction
        if (gameObject.transform.position.y >= border(topWall) || gameObject.transform.position.y <= border(bottomWall))
            yVel *= -1;
	}

    //Function that determines location of each wall
    float border(GameObject wall)
    {
        //Rotation of the right and left wall is the only constant identifier since this game allows for movement of walls
        if (wall.transform.rotation.z != 0)
        {
            //If wall is negative on the x axis subtract half of its scale and half of gameobject's scale
            if (wall.transform.position.x >= 0.0f)
                return wall.transform.position.x - ((wall.transform.localScale.y / 2) + (gameObject.transform.localScale.y / 2));
            //Otherwise, add those values
            else //wall.transform.position.x < 0.0f
                return wall.transform.position.x + ((wall.transform.localScale.y / 2) + (gameObject.transform.localScale.y / 2));
        }
        //Walls with z-axis rotation of 0 are identified as the top and side walls
        //Therefore the y-axis position is the border, and not the x-axis
        else
        {
            if (wall.transform.position.y >= 0.0f)
                return wall.transform.position.y - ((wall.transform.localScale.y / 2) + (gameObject.transform.localScale.y / 2));
            else
                return wall.transform.position.y + ((wall.transform.localScale.y / 2) + (gameObject.transform.localScale.y / 2));
        }
    }
}
