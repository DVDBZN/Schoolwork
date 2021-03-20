//This code manipulates the scale and position of the backdrop of the "room".
//Whenever the walls are moved, this will be changed to refelct that.
using UnityEngine;

public class Span : MonoBehaviour
{
    public GameObject topWall;
    public GameObject bottomWall;
    public GameObject righWall;
    public GameObject leftWall;


	// Use this for initialization
	void Start (){}
	
	// Update is called once per frame
	void Update ()
    {
        //Change size and position based on wall position
        gameObject.transform.localScale = new Vector3(xSize(), ySize(), gameObject.transform.localScale.z);
        gameObject.transform.position = new Vector3(xPosition(), yPosition(), gameObject.transform.position.z);
    }

    float xPosition()
    {
        float right = righWall.transform.position.x;
        float left = leftWall.transform.position.x;

        //X position is the average of both wall positions
        return (right + left) / 2;
    }

    float yPosition()
    {
        float top = topWall.transform.position.y;
        float bottom = bottomWall.transform.position.y;

        //So is Y position
        return (top + bottom) / 2;
    }

    float xSize()
    {
        float right = righWall.transform.position.x;
        float left = leftWall.transform.position.x;

        //If one wall is in the positive x-axis area,
        //And one is in the negative x-axis area,
        //Then subtract positive from negative.
        if (right > 0.0f && left < 0.0f)
            return right - left;
        //Otherwise, find bigger number and subtract from smaller
        else
            return Mathf.Max(right, left) - Mathf.Min(right, left);
    }

    float ySize()
    {
        float top = topWall.transform.position.y;
        float bottom = bottomWall.transform.position.y;

        //Same with y-axis walls
        if (top > 0.0f && bottom < 0.0f)
            return top - bottom;
        else
            return Mathf.Max(top, bottom) - Mathf.Min(top, bottom);
    }
}