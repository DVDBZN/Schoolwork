using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{

    Random rand;
    public GameObject obstacle;
    public GameObject player;
    public GameObject score;
    public GameObject loseText;

    // Use this for initialization
    void Start ()
    {
        rand = new Random();
    }
	
	// Update is called once per frame
	void Update ()
    {
        int rand = Random.Range(0, 50);

        if (rand == 1)
        {
            Vector2 pos = new Vector2(9, 0);
            GameObject clone = (GameObject)Instantiate<GameObject>(obstacle);
            clone.transform.position = pos;
            clone.GetComponent<MoveObstacle>().player = player;
            clone.GetComponent<MoveObstacle>().score = score;
            clone.SetActive(true);
        }
	}

    public IEnumerator lose()
    {
        loseText.SetActive(true);
        float font = loseText.GetComponent<TextMesh>().characterSize;

        while (font < 5)
        {
            font += .1f;
            loseText.GetComponent<TextMesh>().characterSize = font;

            yield return null;
        }

        loseText.SetActive(false);

        loseText.GetComponent<TextMesh>().characterSize = .01f;

        reset();
    }

    public void reset()
    {
        score.GetComponent<TextMesh>().text = "0";
    }
}
