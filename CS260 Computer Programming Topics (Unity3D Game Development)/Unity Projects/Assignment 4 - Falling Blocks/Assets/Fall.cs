using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour {

    public int frameWait;
    int[] colors = { 0, 0, 0};

    // Use this for initialization
    void Start ()
    {
     
    }
	
	// Update is called once per frame
	void Update ()
    {
        //If number of frames is divisible by frameWait, move object by one unit
        if (Time.frameCount % frameWait == 0)
        {
            transform.Translate(Vector3.down * 1);

            //Change color on each movement
            GetComponent<Renderer>().material.color = new Color(colors[0], colors[1], colors[2], 0);

            //Increment random RGB value
            colors[Random.Range(0, 3)]++;
            //Decrement random RGB value to let the colors keep changing, rather than turn white
            colors[Random.Range(0, 3)]--;
        }

        //If object reaches bottom of view, move back to top
        if (transform.position.y == 0)
        {
            transform.Translate(Vector2.up * 11);
        }
	}
}
