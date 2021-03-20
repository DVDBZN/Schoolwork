using UnityEngine;
using System.Collections;

public class GamePlay : MonoBehaviour
{
    public Camera camera;
    int vertex = 0;
    LineRenderer[] lines;
    Vector3 previous;
    public Vector3[] vectors = new Vector3[10];
    public GameObject winText;
    public GameObject loseText;
    public GameObject score;
    public GameObject circle;
    public GameObject square;
    int games;
    GameObject circleClone;
    GameObject squareClone;
    GameObject particles;

    void Start()
    {
        //Loads prefab as GameObject
        particles = Resources.Load("Particle") as GameObject;
        //Game counter
        games = 8;
        //Sclice lines
        lines = GetComponentsInChildren<LineRenderer>(true);

        //Set default position of lines
        for (int i = 0; i < 10; i++)
        {
            vectors[i] = new Vector3(10, 10, 0);
        }

        //Random shape
        int num = Random.Range(0, 2);

        if (num ==0)
        {
            //Instantiate from prefab
            circleClone = (GameObject)Instantiate(circle, new Vector3(0, 0, 0), Quaternion.identity);
            //Attach other GameObject as variables
            circleClone.GetComponent<CircleCreate>().prefab = particles;
            circleClone.GetComponent<CircleCreate>().score = GameObject.Find("SlicesLeft");
            circleClone.GetComponent<CircleCreate>().criticalText = GameObject.Find("Critical");
            //Set active
            circleClone.SetActive(true);
        }
        //Same for square
        else
        {
            squareClone = (GameObject)Instantiate(square, new Vector3(0, 0, 0), Quaternion.identity);
            squareClone.GetComponent<SquareCreate>().prefab = particles;
            squareClone.GetComponent<SquareCreate>().score = GameObject.Find("SlicesLeft");
            squareClone.GetComponent<SquareCreate>().criticalText = GameObject.Find("Critical");
            squareClone.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Reset shape in case the current one refuses to get sliced
        if (Input.GetKeyDown("r"))
        {
            games++;
            reset();
        }

        //When mouse is left-clicked
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 1; i < 10; i++)
            {
                for (int o = 0; o < 2; o++)
                {
                    //Set each line to starting mouse position
                    lines[i].SetPosition(o, camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)));
                    vectors[i] = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                }
            }
            //After setting line positions, set previous variable
            previous = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        }

        //When mouse left button is held down
        if (Input.GetMouseButton(0))
        {
            //For first ten lines
            if (vertex < 10)
            {
                //Set current to mouse position
                Vector3 current = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

                //Set one side of line to previous
                lines[vertex + 1].SetPosition(0, previous);
                //Set other side of line to current
                //This will create a consistent line made up of ten lines
                lines[vertex + 1].SetPosition(1, current);
                lines[vertex + 1].enabled = true;

                //Store current
                vectors[vertex] = current;

                //Reset previous
                previous = current;

                vertex++;
            }

            //Once all ten lines have been set, start resetting position from first line
            else
            {
                Vector3 current = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

                //Since the lines have been placed 1-10,
                //All of the lines need to move to the position of the next one,
                //And the tenth line is moved to the new mouse position
                //I could have made this more efficient by moving the first line to the new position
                for (int i = 0; i < 9; i++)
                {
                    lines[i + 1].SetPosition(0, vectors[i]);
                    lines[i + 1].SetPosition(1, vectors[i + 1]);
                    vectors[i] = vectors[i + 1];
                }

                //Last line to new position
                lines[10].SetPosition(0, vectors[9]);
                lines[10].SetPosition(1, current);
                vectors[9] = current;
            }
        }
    }

    //Do this after all other Updates
    void LateUpdate()
    {
        //Let go of left mouse button
        if (Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i < 10; i++)
            {
                for (int o = 0; o < 2; o++)
                {
                    //Move lines out of view
                    lines[i + 1].SetPosition(o, new Vector3(0, 0, 0));
                    vectors[i] = new Vector3(0, 0, 0);
                }
                //Disable lines
                lines[i + 1].enabled = false;
            }

            vertex = 0;

            if (int.Parse(score.GetComponent<TextMesh>().text) < 0)
            {
                StartCoroutine(lose());
            }
        }
    }

    public IEnumerator win()
    {
        //Change font size of text
        int font = winText.GetComponent<TextMesh>().fontSize;

        //Make it larger
        for (int i = 0; i < 16; i++)
        {
            font += 30;
            winText.GetComponent<TextMesh>().fontSize = font;

            yield return new WaitForSeconds(.05f);
        }

        //Then smaller
        for (int i = 0; i < 16; i++)
        {
            font -= 50;
            winText.GetComponent<TextMesh>().fontSize = font;

            yield return new WaitForSeconds(.05f);
        }

        //Then reset level
        reset();
    }

    //Same for lose text
    IEnumerator lose()
    {
        int font = loseText.GetComponent<TextMesh>().fontSize;

        while (font < 500)
        {
            font += 30;
            loseText.GetComponent<TextMesh>().fontSize = font;

            yield return new WaitForSeconds(.05f);
        }

        //Instead of making it smaller, reset to one
        font = 1;
        loseText.GetComponent<TextMesh>().fontSize = font;

        reset();
    }

    public void reset()
    {
        winText.GetComponent<TextMesh>().fontSize = 0;
        loseText.GetComponent<TextMesh>().fontSize = 0;
        //If number of slices starts out as one (on the seventh level), reset to eight
        if (games == 1)
            games = 8;

        //This variable determines difficulty by distating the goal number of slices
        games--;

        //Destroy current shape
        Destroy(circleClone);
        Destroy(squareClone);
        //Reset score
        score.GetComponent<TextMesh>().text = games.ToString();

        int num = Random.Range(0, 2);

        //Pick random shape
        if (num == 0)
        {
            circleClone = (GameObject)Instantiate(circle, new Vector3(0, 0, 0), Quaternion.identity);
            circleClone.GetComponent<CircleCreate>().prefab = particles;
            circleClone.GetComponent<CircleCreate>().score = GameObject.Find("SlicesLeft");
            circleClone.GetComponent<CircleCreate>().criticalText = GameObject.Find("Critical");
            circleClone.SetActive(true);
        }
        else
        {
            squareClone = (GameObject)Instantiate(square, new Vector3(0, 0, 0), Quaternion.identity);
            squareClone.GetComponent<SquareCreate>().prefab = particles;
            squareClone.GetComponent<SquareCreate>().score = GameObject.Find("SlicesLeft");
            squareClone.GetComponent<SquareCreate>().criticalText = GameObject.Find("Critical");
            squareClone.SetActive(true);
        }
    }
}
