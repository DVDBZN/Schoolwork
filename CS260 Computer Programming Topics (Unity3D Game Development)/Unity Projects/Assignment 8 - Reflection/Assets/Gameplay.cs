using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public GameObject prefab;
    public GameObject topWall;
    public GameObject bottomWall;
    public GameObject rightWall;
    public GameObject leftWall;

    // Use this for initialization
    void Start (){}

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            //Create clone of prefab
            GameObject clone = prefab;
            clone = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
            clone.SetActive(true);
            //Assign objects to clone's variables
            clone.GetComponent<Physics>().topWall = topWall;
            clone.GetComponent<Physics>().bottomWall = bottomWall;
            clone.GetComponent<Physics>().rightWall = rightWall;
            clone.GetComponent<Physics>().leftWall = leftWall;
        }
	}
}