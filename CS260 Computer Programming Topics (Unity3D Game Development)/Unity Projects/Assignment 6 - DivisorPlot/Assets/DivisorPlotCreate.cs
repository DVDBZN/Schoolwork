using UnityEngine;
using System.Collections;

public class DivisorPlotCreate : MonoBehaviour
{
    //Variables
    public GameObject cube;
    private GameObject clone;
    public int x;
    public int y;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //If "space" is pressed
        if (Input.GetKey("space"))
        {
            //Loop until cube is created
            while (true)
            {
                //If equal, reset y and increment x
                if (x == y)
                {
                    x++;
                    y = 1;
                }

                //If not equal, increment y
                else
                {
                    y++;
                }

                //If x is divisible by y
                if (x % y == 0)
                {
                    //Coordinates based on x and y incrementing
                    Vector3 cubePos = new Vector3(x, y, 0);

                    //Create clone of cube at new coordinate and set as active
                    clone = (GameObject)Instantiate(cube, cubePos, Quaternion.identity);
                    clone.SetActive(true);
                    break;
                }
            } 
        }
	}
}
