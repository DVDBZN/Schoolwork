using UnityEngine;
using System.Collections.Generic;

public class Slide : MonoBehaviour
{
    //Variables
    public int xDim;
    public int yDim;
    public GameObject prefab;
    public Camera camera;
    public GameObject winText;
    public GameObject script;
    private float timer = 0f;
    private float stopTimer = 0;

    //I found two ways of making 2D arrays, but chose the latter.
    //private List<GameObject[,]> tiles = new List<GameObject[,]>();
    private List<List<GameObject>> tiles = new List<List<GameObject>>();

    // Use this for initialization
    void Start()
    {
        //Position camera based on puzzle size.
        //Works pretty well, but not perfectly
        camera.transform.position = new Vector3((xDim - 1) / 2.0f, (xDim + yDim) / 2.0f, -((yDim - 1) / 2.0f));

        GameObject clone = prefab;
        int counter = 0;

        //For loop that creates tiles
        for (int y = 0; y < yDim; y++)
        {
            //Creates 1D array that will be part of 2D array
            List<GameObject> tilesSubList = new List<GameObject>();

            for (int x = 0; x < xDim; x++)
            {
                counter++;

                //Coordinates based on x and y incrementing
                Vector3 newPos = new Vector3(x, 0, -y);

                //Create clone of cube at new coordinate and set as active
                clone = (GameObject)Instantiate(prefab, newPos, Quaternion.identity);
                clone.SetActive(true);

                //Set number of tile
                clone.GetComponentInChildren<TextMesh>().text = counter.ToString();

                //Add tile to array
                tilesSubList.Add(clone);
            }
            //Add array to 2D array
            tiles.Add(tilesSubList);
        }
        //Last tile is "removed" and renamed
        clone.SetActive(false);
        clone.name = "Empty";

        //Shuffle
        shuffle();

        //Update position
        updatePos();
    }

    // Update is called once per frame
    void Update()
    {
        //Timer to be revealed at end of game
        timer += Time.deltaTime;

        //Restart
        if (Input.GetKeyDown("r"))
        {
            shuffle();
            timer = 0;
            winText.SetActive(false);
        }

        //For each direction:
        //    •Check that "Empty" is moveable (e.g. for "up", it is not on bottom row)
        //    •Find empty
        //    •Switch with proper tile
        //    •Update position
        if (Input.GetKeyDown("up") && up())
        {
            int y = 0;
            int x = 0;
            bool found = false;

            for (y = 0; y < yDim - 1; y++)
            {
                for (x = 0; x < xDim; x++)
                {
                    if (tiles[y][x].name == "Empty")
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                    break;
            }

            if (y < yDim - 1)
            {
                GameObject temp = tiles[y + 1][x];
                tiles[y + 1][x] = tiles[y][x];
                tiles[y][x] = temp;

                updatePos();
            }
        }

        else if (Input.GetKeyDown("down") && down())
        {
            int y = 0;
            int x = 0;
            bool found = false;

            for (y = 1; y < yDim; y++)
            {
                for (x = 0; x < xDim; x++)
                {
                    if (tiles[y][x].name == "Empty")
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                    break;
            }

            GameObject temp = tiles[y - 1][x];
            tiles[y - 1][x] = tiles[y][x];
            tiles[y][x] = temp;

            updatePos();

        }

        else if (Input.GetKeyDown("right") && right())
        {
            int y = 0;
            int x = 0;
            bool found = false;

            for (y = 0; y < yDim; y++)
            {
                for (x = 1; x < xDim; x++)
                {
                    if (tiles[y][x].name == "Empty")
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                    break;
            }

            if (x < xDim)
            {
                GameObject temp = tiles[y][x - 1];
                tiles[y][x - 1] = tiles[y][x];
                tiles[y][x] = temp;

                updatePos(); 
            }
        }

        else if (Input.GetKeyDown("left") && left())
        {
            int y = 0;
            int x = 0;
            bool found = false;

            for (y = 0; y < yDim; y++)
            {
                for (x = 0; x < xDim - 1; x++)
                {
                    if (tiles[y][x].name == "Empty")
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                    break;
            }

            GameObject temp = tiles[y][x + 1];
            tiles[y][x + 1] = tiles[y][x];
            tiles[y][x] = temp;

            updatePos();
        }

        //Check for winning condition
        if (checkWin() && stopTimer == 0)
        {
            //Stop timer
            stopTimer = timer;
            //Show winText and add timer to it
            winText.SetActive(true);
            winText.GetComponentInChildren<TextMesh>().text += timer.ToString("n2") + "s";
        }
    }

    //Update position function
    void updatePos()
    {
        for (int y = 0; y < yDim; y++)
        {
            for (int x = 0; x < xDim; x++)
            {
                //Move tile to location based on shuffled array
                Vector3 movePosition = new Vector3(x, .25f, -y);
                tiles[y][x].transform.position = movePosition;
            }
        }
    }

    //Check if "Empty" tile is not on "forbidden row/column" (e.g. "up's" "forbidden row" is the bottom one)
    bool up()
    {
        for (int y = 0; y < yDim - 1; y++)
        {
            for (int x = 0; x < xDim; x++)
            {
                if (tiles[y][x].name == "Empty")
                {
                    return true;
                }
            }
        }
        return false;
    }

    bool down()
    {
        for (int y = 1; y < yDim; y++)
        {
            for (int x = 0; x < xDim; x++)
            {
                if (tiles[y][x].name == "Empty")
                {
                    return true;
                }
            }
        }
        return false;
    }

    bool right()
    {
        for (int y = 0; y < yDim; y++)
        {
            for (int x = 1; x < xDim; x++)
            {
                if (tiles[y][x].name == "Empty")
                {
                    return true;
                }
            }
        }
        return false;
    }

    bool left()
    {
        for (int y = 0; y < yDim; y++)
        {
            for (int x = 0; x < xDim - 1; x++)
            {
                if (tiles[y][x].name == "Empty")
                {
                    return true;
                }
            }
        }
        return false;
    }

    //Check if tiles are in numerical order
    bool checkWin()
    {
        int counter = 1;
        for (int y = 0; y < yDim; y++)
        {
            for (int x = 0; x < xDim; x++)
            {
                if (tiles[y][x].GetComponentInChildren<TextMesh>().text != counter.ToString())
                    return false;
                counter++;
            }
        }
        return true;
    }

    //Shuffle array
    void shuffle()
    {
        for (int n = 0; n < 5; n++)
        {
            for (int x = 0; x < xDim; x++)
            {
                for (int y = 0; y < yDim; y++)
                {
                    GameObject temp = tiles[y][x];
                    int k = Random.Range(x, xDim);
                    int l = Random.Range(y, yDim);
                    tiles[y][x] = tiles[l][k];
                    tiles[l][k] = temp;
                }
            }
        }

        updatePos();
    }
}