using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public int speed;

	// Use this for initialization
	void Start () {
        Debug.Log("type message here");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("up"))
            transform.Translate(Vector3.back * Time.deltaTime * speed);

        else if (Input.GetKey("down"))
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

        else if (Input.GetKey("left"))
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        else if (Input.GetKey("right"))
            transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
