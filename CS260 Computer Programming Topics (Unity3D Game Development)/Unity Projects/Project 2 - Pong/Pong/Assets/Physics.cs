using UnityEngine;
using UnityEngine.UI;
using System;

public class Physics : MonoBehaviour
{
    //Here is the most complex and frustrating code
    //I had several methods for the ball reflection, but most did not work
    //I left them here as comments, so that extends the code quite a bit

    public float xVel;
    public float xPos;
    public float yVel;
    public float yPos;

    public GameObject player1;
    public GameObject player2;

    public GameObject score1;
    public GameObject score2;

    public double distance;
    bool once = true;

    // Use this for initialization
    void Start ()
    {
        //Create random starting velocities
        //These values also determine the direction
        xVel = UnityEngine.Random.Range(-10.0f, 10.0f);
        yVel = UnityEngine.Random.Range(-10.0f, 10.0f);        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Reset
        if (Input.GetKeyDown("r"))
        {
            Destroy(gameObject);
        }

        int score = 0;

        //Add velocities to x and y positions
        xPos += xVel;
        yPos += yVel;

        //Move object to new poistion
        //Divide be 100 because the playing field is so small
        transform.position = new Vector3(xPos / 100, yPos / 100, 0);

        //Only on x and y are used because the other is 0 and 0
        distance = Mathf.Sqrt(Mathf.Pow(xPos / 100, 2) + Mathf.Pow(yPos / 100, 2));

        //If ball has reached circumference
        if (distance >= 2.9)
        {
            //Check for collision with paddle
            //At first it was a bool,
            //But one of the methods needed a distance from tha paddle
            //So I changed it to float
            //If there is no collision, the function returns 0f
            if (bounce() != 0f)
            {
                //This method would find the angle of incedence
                //Then reflect at that angle, but starting from the circumference
                /*
                //float fromPad = bounce();
                float slope = (xPos - (xPos + xVel)) / (yPos - (yPos + yVel));
                float rads = Mathf.Atan(slope);
                float degs = rads * Mathf.Rad2Deg;
                float refdegs = -degs;
                float refrads = refdegs * Mathf.Deg2Rad;
                float refslope = Mathf.Tan(refdegs);

                float num = Mathf.Abs(refslope * 100);
                float den = 100;
                
                int num2 = (int)num;

                //while (num2 >= 2)
                {
                    if (den % num2 == 0 && num % num2 == 0)
                    {
                        den /= num2;
                        num /= num2;
                    }
                    num2--;
                }
                

                if (gameObject.transform.position.x > 0 && gameObject.transform.position.y < 0)
                    den *= -1;
                else if (gameObject.transform.position.x < 0 && gameObject.transform.position.y > 0)
                    num *= -1;
                else if (gameObject.transform.position.x < 0 && gameObject.transform.position.y < 0)
                {
                    num *= -1;
                    den *= -1;
                }
                yVel = num / 25;
                xVel = den / 25;
                */

                //float angle = radAngle * Mathf.Rad2Deg;

                //float radx = 0 + 3 * Mathf.Cos(radian);
                //float rady = 0 + 3 * Mathf.Sin(radian);

                /*
                float angle2 = angle * -1;
                float radian = angle2 * Mathf.Deg2Rad;

                float refradx = xPos + xVel * Mathf.Cos(radian);
                float refrady = yPos + yVel * Mathf.Sin(radian);

                xVel = refradx - xPos;
                yVel = refrady - yPos;
                */

                //Change direction

                //If angle of travel is equal to angle(location based) of circle, negate both
                //If angle is divisible by 90, average both

                /*
                if (gameObject.transform.position.y > 0)
                {
                    float temp = xVel;
                    xVel = -yVel;
                    yVel = -temp;
                }

                else
                {
                    float temp = xVel;
                    xVel = -yVel;
                    yVel = -temp;
                }
                */
                //xVel *= -1;
                //yVel *= -1;


                //This is the method that I kept
                //It is not perfect, bit it did get the most realistic effect
                //So far, this is the part that can be improved the most

                //Find position
                float radx = gameObject.transform.position.x;
                float rady = gameObject.transform.position.y;

                //Get radian angle based on position
                //I should have based this on angle of travel,
                //Not angle based on 0,0
                float radAngle = Mathf.Atan2(rady, radx);

                //Find new point based on new angle and previous point
                float radX = (xPos / 100) + xVel * Mathf.Cos(radAngle);
                float radY = (yPos / 100) + yVel * Mathf.Sin(radAngle);

                //New direction is is implemented

                xVel = -radX;
                yVel = -radY;
            }
         
            //If no collision
            else
            {
                //Increase point and destroy after two seconds
                if (gameObject.transform.position.x > 0 && once)
                {
                    score = int.Parse(score1.GetComponent<Text>().text);
                    score += 1;
                    score1.GetComponent<Text>().text = score.ToString();
                }

                else if (once)
                {
                    score = int.Parse(score2.GetComponent<Text>().text);
                    score += 1;
                    score2.GetComponent<Text>().text = score.ToString();
                }

                //Limits to one point per ball
                once = false;

                Destroy(gameObject, 2);
            }
        }
	}

    float bounce()
    {
        float p1x = player1.transform.position.x;
        float p1y = player1.transform.position.y;

        float p2x = player2.transform.position.x;
        float p2y = player2.transform.position.y;

        //Distance from paddle
        float dist1 = Mathf.Sqrt(Mathf.Pow((xPos / 100) - p1x, 2) + Mathf.Pow((yPos / 100) - p1y, 2));
        float dist2 = Mathf.Sqrt(Mathf.Pow((xPos / 100) - p2x, 2) + Mathf.Pow((yPos / 100) - p2y, 2));

        //If distance is less than .8, hitting the paddle
        //Then return distance based on which paddle is closer
        if (dist1 < .8f || dist2 < .8f)
        {
            if (gameObject.transform.position.x < 0)
                return dist1;
            else
                return dist2;
        }

        //Otherwise send bool replacement
        else
            return 0f;
    }
}
