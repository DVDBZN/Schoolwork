using UnityEngine;

public class MovePaddle2 : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}

    // Update is called once per frame
    void Update()
    {
        //This one is much more trickier
        //The paddle object is rotated
        //Then based on that rotation, a formula is used to find the new point

        //Set limits here, too
        if (Input.GetKey("up") && (gameObject.transform.eulerAngles.z < 72 || gameObject.transform.eulerAngles.z > 280))
        {
            //Increase rotation by certain amount
            gameObject.transform.Rotate(0, 0, 3);

            //Convert rotation to radians. Deg2Rad is equal to (PI * 2) / 360
            float radian = gameObject.transform.eulerAngles.z * Mathf.Deg2Rad;

            //Find x and y position using formula
            //Zero is center, or what the angle is based off of
            //And three is the distance from the center
            float radx = 0 + 3 * Mathf.Cos(radian);
            float rady = 0 + 3 * Mathf.Sin(radian);

            //Place on new point
            gameObject.transform.position = new Vector3(radx, rady, 0);
        }

        if (Input.GetKey("down") && (gameObject.transform.eulerAngles.z > 287 || gameObject.transform.eulerAngles.z < 80))
        {
            gameObject.transform.Rotate(0, 0, -3);

            float radian = gameObject.transform.eulerAngles.z * Mathf.Deg2Rad;

            float radx = 0 + 3 * Mathf.Cos(radian);
            float rady = 0 + 3 * Mathf.Sin(radian);

            gameObject.transform.position = new Vector3(radx, rady, 0);
        }
    }
}
