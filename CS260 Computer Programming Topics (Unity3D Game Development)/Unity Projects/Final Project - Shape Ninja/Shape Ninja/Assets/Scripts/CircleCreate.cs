using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircleCreate : MonoBehaviour
{
    public GameObject prefab;
    GameObject chosen;
    Vector3[] vectors = new Vector3[10];
    public GameObject score;
    public GameObject criticalText;

    // Use this for initialization
    void Start()
    {
        List<GameObject> particles = new List<GameObject>();
        //Get variable from other script
        vectors = GameObject.Find("Game").GetComponent<GamePlay>().vectors;

        //Start as random color
        //There are several problems with this, but it works fine,
        //So I will leave it alone
        Color randColor = new Color(Random.Range(0, 255) - Random.Range(0, 255), Random.Range(0, 255) - Random.Range(0, 255), Random.Range(0, 255) - Random.Range(0, 255), 1);

        //Counters act as positioning for clones
        for (float i = -2; i < 2; i += .1f)
        {
            for (float o = -2; o < 2; o += .1f)
            {
                if ((i * i) + (o * o) <= 4)
                {
                    //Create new cube
                    Vector3 clonePos = new Vector3(i, o, 0);
                    GameObject clone = (GameObject)Instantiate(prefab, clonePos, Quaternion.identity);
                    //Set color
                    clone.GetComponent<Renderer>().material.color = randColor;
                    //Set as child
                    clone.transform.parent = gameObject.transform;
                    //Set active
                    clone.SetActive(true);
                    //Add to list
                    particles.Add(clone);
                }
            }
        }

        //Pick random particle
        int rand = Random.Range(0, particles.Count);
        //Debug.Log(rand);
        chosen = particles[rand];

        //This changes the color of the chosen cube to make it visible
        //chosen.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Let go of left mouse button
        if (Input.GetMouseButtonUp(0))
        {
            float distance = Mathf.Sqrt(Mathf.Pow(vectors[0].x - vectors[9].x, 2) + Mathf.Pow(vectors[0].y - vectors[9].y, 2));

            //Make sure the line goes completely through the shape and the ends are not too close
            //This needs to be dynamic based on number of cubes left or distance between farthest cubes
            if ((((Mathf.Abs(vectors[0].x) > 1.8f || Mathf.Abs(vectors[0].y) > 1.8f) && (Mathf.Abs(vectors[9].x) > 1.8f || Mathf.Abs(vectors[9].y) > 1.8f)) ||
                ((Mathf.Abs(vectors[9].x) > 1.8f || Mathf.Abs(vectors[9].y) > 1.8f) && (Mathf.Abs(vectors[0].x) > 1.8f || Mathf.Abs(vectors[0].y) > 1.8f))) && 
                distance > 3.25f && distance != 0)
            {
                int points = int.Parse(score.GetComponent<TextMesh>().text);
                points--;
                score.GetComponent<TextMesh>().text = points.ToString();

                int left = 0;
                int right = 0;

                //Debug.Log("Valid");

                //Check each line
                for (int i = 0; i < 9; i++)
                {
                    //Use determine function to check which side of the line the chosen cube is on
                    float side = determine(vectors[i], vectors[i + 1], chosen.transform.position);

                    //If distance from line to chosen cube is less than .2
                    float distance2 = Mathf.Sqrt(Mathf.Pow(vectors[i].x - chosen.transform.position.x, 2) + Mathf.Pow(vectors[i].y - chosen.transform.position.y, 2));
                    if (distance2 < .5f)
                    {
                        //Win (near line)
                        left = 0;
                        right = 0;
                        startWin();
                        //Debug.Log("Win");
                        break;
                    }

                    //If on left side
                    else if (side > .1f)
                    {
                        //Left
                        left++;
                        //Debug.Log("Left");
                    }

                    //If on right side
                    else
                    {
                        //Right
                        right++;
                        //Debug.Log("Right");
                    }
                }

                //If more lefts than rights
                if (left > right)
                {
                    //Remove cubes on oppisite side
                    removeRight();
                }

                //If more right than lefts
                else if (right > left)
                {
                    removeLeft();
                }

            }

            //else
                //Debug.Log("Invalid");
        }
    }

    private float determine(Vector3 la, Vector3 lb, Vector3 p)
    {
        //Determinate function
        //This determines if a point is on the left or right side of a line
        return (lb.x - la.x) * (p.y - la.y) - (lb.y - la.y) * (p.x - la.x);
    }

    private void removeLeft()
    {
        //Check each cube
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            //Transform (position) of cube
            Transform cube = gameObject.transform.GetChild(i);

            for (int o = 0; o < 9; o++)
            {
                //Use determine function here too
                float side = determine(vectors[o], vectors[o + 1], cube.position);

                //If cube is on right side, break
                //This way, the cube needs to be on the left side of every line to get removed
                if (side < 0f)
                {
                    break;
                }

                StartCoroutine(remove(cube.gameObject));
            }
        }
    }

    private void removeRight()
    {
        //Check each cube
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform cube = gameObject.transform.GetChild(i);

            for (int o = 0; o < 9; o++)
            {
                float side = determine(vectors[o], vectors[o + 1], cube.position);

                //If cube is on left side, break
                //This way, the cube needs to be on the right side of every line to get removed
                if (side > 0f)
                {
                    break;
                }

                StartCoroutine(remove(cube.gameObject));
            }
        }
    }

    private void startWin()
    {
        //Start coroutine in GamePlay script
        StartCoroutine(GameObject.Find("Game").GetComponent<GamePlay>().win());
    }

    //Remove cubes coroutine
    IEnumerator remove(GameObject cube)
    {
        //If chosen cube is removed
        if (cube == chosen)
        {
            //Critical hit coroutine
            StartCoroutine(critical());
        }

        for (int i = 0; i < 20; i++)
        {
            //Move down slightly
            Vector3 move = new Vector3(cube.transform.position.x, cube.transform.position.y - .01f, 0);
            cube.transform.position = move;
            //Rotate slightly
            cube.transform.Rotate(0, 0, 5);
            //Make slightly more transparent
            Color col = cube.GetComponent<Renderer>().material.color;
            col.a -= .05f;
            cube.GetComponent<Renderer>().material.color = col;
            yield return new WaitForSeconds(.05f);
        }
        //then destroy after twenty iterations of the coroutine
        Destroy(cube);
    }

    IEnumerator critical()
    {
        //Debug.Log("Critical");
        criticalText.GetComponent<TextMesh>().fontSize = 0;
        int font = criticalText.GetComponent<TextMesh>().fontSize;

        //Enlarge critical text
        for (int i = 0; i < 16; i++)
        {
            font += 30;
            criticalText.GetComponent<TextMesh>().fontSize = font;

            yield return new WaitForSeconds(.05f);
        }

        //Shrink critical text
        for (int i = 0; i < 16; i++)
        {
            font -= 50;
            criticalText.GetComponent<TextMesh>().fontSize = font;

            yield return new WaitForSeconds(.05f);
        }
        //Win
        startWin();
    }
}