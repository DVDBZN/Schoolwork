using UnityEngine;
using System.Collections;

public class Plot : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    for (int counter = 1; counter < Time.frameCount; counter++)
        {
            if (Time.frameCount % counter == 0)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(Time.frameCount, counter, 0);
            }
        }
	}
}
