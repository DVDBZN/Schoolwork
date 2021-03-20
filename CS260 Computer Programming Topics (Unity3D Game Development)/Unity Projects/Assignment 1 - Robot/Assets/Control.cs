using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

    public float forwardSpeed;
    public float backSpeed;
    public float turnSpeed;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Hello World!");
	}
	
	// Update is called once per frame
	void Update ()
    {
        //For continuous movement
        ///*
        if (Input.GetKey("up"))
            transform.Translate(Vector3.back * Time.deltaTime * forwardSpeed);

        else if (Input.GetKey("down"))
            transform.Translate(Vector3.forward * Time.deltaTime * backSpeed);

        else if (Input.GetKey("left"))
            transform.Rotate(Vector2.down * Time.deltaTime * turnSpeed);

        else if (Input.GetKey("right"))
            transform.Rotate(Vector2.up * Time.deltaTime * turnSpeed);

        else if (Input.GetKey("space"))
            transform.Translate(Vector2.up * Time.deltaTime * turnSpeed);
            //*/

        //For unititary movement (the boring way)
        /*
        if (Input.GetKeyDown("up"))
            transform.Translate(Vector3.back * 4);

        else if (Input.GetKeyDown("down"))
            transform.Translate(Vector3.forward * 4);

        else if (Input.GetKeyDown("left"))
            transform.Translate(Vector3.right * 4);

        else if (Input.GetKeyDown("right"))
            transform.Translate(Vector3.left * 4);

        else if (Input.GetKeyDown("space"))
            transform.Translate(Vector3.up * 4);
            */
    }
}
