using UnityEngine;
using UnityEngine.UI;

public class InitializeObject : MonoBehaviour
{
    public GameObject prefab;
    public GameObject cube;
    public Slider slider;
    public Text text;
    public ParticleSystem particles;

    // Use this for initialization
    void Start()
    {
        //Creats a wall to knock down
        for (float i = 0; i < 8; i++)
        {
            for (float o = -4; o < 5 - i; o++)
            {
                //Space out the blocks from each other and create a triangle pattern
                Vector3 pos = new Vector3(30, i - 1.25f, o + (i / 2f));
                GameObject cubeClone = cube;
                cubeClone = (GameObject)Instantiate(cube, pos, Quaternion.identity);
                cubeClone.SetActive(true);
                cubeClone.GetComponent<Points>().text = text;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //When space is pressed down
        if (Input.GetKeyDown("space"))
        {
            //Reset slider
            slider.value = 0;
            //Create a sphere object
            GameObject clone = prefab;
            clone = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
            clone.SetActive(true);

            //Prefabs don't keep components saved
            //Components are manually added
            clone.GetComponent<Physics>().slider = slider;
            clone.GetComponent<Physics>().particles = particles;
        }
    }
}