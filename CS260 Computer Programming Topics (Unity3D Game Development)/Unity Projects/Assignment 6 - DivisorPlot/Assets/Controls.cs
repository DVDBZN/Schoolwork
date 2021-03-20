using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

    public int speed;

	// Use this for initialization
	void Start ()
    {
 
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("up"))
            transform.Translate(Vector3.up * Time.deltaTime * speed);

        else if (Input.GetKey("down"))
            transform.Translate(Vector3.down * Time.deltaTime * speed);

        else if (Input.GetKey("left"))
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        else if (Input.GetKey("right"))
            transform.Translate(Vector3.right * Time.deltaTime * speed);

        //Plus (+) and NumPad Plus ([+]) zoom in, Minus (-) and NumPad Minus (-) zoom out
        else if (Input.GetKey("+") || Input.GetKey("[+]"))
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

        else if (Input.GetKey("-") || Input.GetKey("[-]"))
            transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
