using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text text;
    bool once = true;

	// Use this for initialization
	void Start(){}

	// Update is called once per frame
	void Update()
    {
        //Increase point value when block falls off of platform (indicated as y axis < -2)
        if (gameObject.transform.position.y < -2 && once)
        {
            int score = int.Parse(text.GetComponent<Text>().text);
            score += 1;
            text.GetComponent<Text>().text = score.ToString();
            once = false;
        }
	}
}