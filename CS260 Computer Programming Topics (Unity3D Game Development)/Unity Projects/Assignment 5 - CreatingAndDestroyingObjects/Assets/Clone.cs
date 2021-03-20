using UnityEngine;
using System.Collections;

public class Clone : MonoBehaviour
{
    //Variables
    public GameObject cube;
    public float frames;
    float x;
    float y;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Only placed cube on certain frames
        if (Time.frameCount % frames == 0)
        {
            //Tries three times
            for (int i = 0; i < 3; i++)
            {
                //Random value
                x = Random.Range(0, 11);
                y = Random.Range(0, 11);

                //Vector with random x and y
                Vector3 cubePos = new Vector3(x, y, 0);

                //If no other cube occupies the point with .4 units
                if (!Physics.CheckSphere(cubePos, 0.4f))
                {
                    //Sets template cube as active, clones it, and makes it inactive
                    cube.SetActive(true);
                    Instantiate(cube, cubePos, Quaternion.identity);
                    cube.SetActive(false);
                    break;
                }
            } 
        }
    }
}