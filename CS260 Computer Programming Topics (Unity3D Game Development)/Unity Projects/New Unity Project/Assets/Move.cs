using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    bool fall = false;

	// Use this for initialization
	void Start ()
    {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && gameObject.transform.position.y < 2f && !fall)
        {
            Vector2 newpos = new Vector2(0, gameObject.transform.position.y + 5 * Time.deltaTime);
            gameObject.transform.position = newpos;

            if (gameObject.transform.position.y > 2f)
                fall = true;
        }

        if (Input.GetKeyUp("space"))
        {
            fall = true;
        }

        if (gameObject.transform.position.y > 0f && fall)
        {
            Vector2 newpos = new Vector2(0, gameObject.transform.position.y + -5 * Time.deltaTime);
            gameObject.transform.position = newpos;

            if (gameObject.transform.position.y <= 0f)
                fall = false;
        }

    }
}
