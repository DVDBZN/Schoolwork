using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public GameObject prefab;

    public GameObject player1;
    public GameObject player2;

    public GameObject score1;
    public GameObject score2;

    public GameObject winnerText;

    // Use this for initialization
    void Start (){}
	
	// Update is called once per frame
	void Update ()
    {
        //On "space", create new ball
        if (Input.GetKeyDown("space"))
        {
            //Clear winner text
            winnerText.GetComponent<Text>().text = "";

            GameObject clone = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
            clone.SetActive(true);

            clone.GetComponent<Physics>().player1 = player1;
            clone.GetComponent<Physics>().player2 = player2;
            clone.GetComponent<Physics>().score1 = score1;
            clone.GetComponent<Physics>().score2 = score2;
        }

        //On "r" reset score
        if (Input.GetKeyDown("r"))
        {
            //Show winner
            if (int.Parse(score1.GetComponent<Text>().text) > int.Parse(score2.GetComponent<Text>().text))
                winnerText.GetComponent<Text>().text = "Player 1 wins!";
            else
                winnerText.GetComponent<Text>().text = "Player 2 wins!";

            score1.GetComponent<Text>().text = "0";
            score2.GetComponent<Text>().text = "0";
        }
	}
}
