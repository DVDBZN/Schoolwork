using UnityEngine;

public class MovePaddle1 : MonoBehaviour
{

    // Use this for initialization
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        //I had two methods for moving the paddle
        //Both perform just about the same, but this one is far shorter
        //For this one, I offset the center of the paddle object to the center of the world, then used rotation

        //Set limits for rotation
        if (Input.GetKey("w") && (gameObject.transform.eulerAngles.z <= 80 || gameObject.transform.eulerAngles.z > 287))
        {
            //Rotate 3 degrees
            gameObject.transform.Rotate(0, 0, -3);
        }

        if (Input.GetKey("s") && (gameObject.transform.eulerAngles.z >= 280 || gameObject.transform.eulerAngles.z < 72))
        {
            //Rotate negative 3 degrees
            gameObject.transform.Rotate(0, 0, 3);
        }
    }
}
