using UnityEngine;
using System.Collections;

public class Delete : MonoBehaviour {

    public int lifetime;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Destroy(gameObject, lifetime);
	}
}
