using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    public float speed;
    Vector3 pos;

	// Use this for initialization
	void Start ()
    {
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.A))
            speed *= 3;
        if (Input.GetKeyUp(KeyCode.Z))
            speed /= 3;

        if (Input.GetKey(KeyCode.RightArrow))
            pos.x += speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.LeftArrow))
            pos.x -= speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow))
            pos.y += speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.DownArrow))
            pos.y -= speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.KeypadPlus))
            pos.z += speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus))
            pos.z -= speed * Time.deltaTime;
	}

    void FixedUpdate()
    {
        transform.position = pos;
    }
}
