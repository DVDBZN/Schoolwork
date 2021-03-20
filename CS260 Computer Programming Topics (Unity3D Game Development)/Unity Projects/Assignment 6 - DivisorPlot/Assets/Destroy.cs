using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{

    public int lifetime;
    public Color lerpedColor = Color.white;
    public float t = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Color fades from white to black over time
        lerpedColor = Color.Lerp(Color.white, Color.black, t);

        //Increment counter for fade
        if (t < 1)
        {
            t += .005f;
        }

        //Set color to slightly darker color from previous
        GetComponent<Renderer>().material.color = lerpedColor;

        //Destroy after lifetime
        Destroy(gameObject, lifetime);
    }
}
