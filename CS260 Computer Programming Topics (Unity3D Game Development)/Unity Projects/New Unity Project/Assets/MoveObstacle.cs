using UnityEngine;
using System.Collections;

public class MoveObstacle : MonoBehaviour
{
    public GameObject player;
    public GameObject score;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 newpos = new Vector2(gameObject.transform.position.x + -10 * Time.deltaTime, 0);
        gameObject.transform.position = newpos;

        if (gameObject.transform.position.x < -9)
        {
            Destroy(gameObject);

            int points = int.Parse(score.GetComponent<TextMesh>().text);
            points++;
            score.GetComponent<TextMesh>().text = points.ToString();
        }

        if (gameObject.transform.position.x < .5f && gameObject.transform.position.x > -.5f && player.transform.position.y < .5f)
            StartCoroutine(GameObject.Find("Game").GetComponent<Game>().lose());
	}
}
