using UnityEngine;
using UnityEngine.UI;

public class Physics : MonoBehaviour
{
    public float velocity;
    public float x = 0f;
    public bool move = false;
    public Slider slider;
    public ParticleSystem particles;

    // Use this for initialization
    void Start(){}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && move == false)
        {
            //Addt to speed while space is held down
            velocity += Time.deltaTime;
            slider.value = velocity;
        }

        //When space is lifted, activate movement of object and start sparks
        if (Input.GetKeyUp("space"))
        {
            move = true;
            particles.GetComponent<ParticleSystem>().startSpeed = velocity * 70;
            particles.GetComponent<ParticleSystem>().Play();
        }
        
        if (move)
        {
            //x equals old position
            //New position is old position (x) + (velocity * time)
            //Since velocity handles both speed/s and time, it is squared
            x += velocity * velocity;
            transform.position = new Vector3(x, 0, 0);
        }
        
        //When sphere flies past 100 on the x axis       
        if (transform.position.x > 100)
        {
            Destroy(gameObject);
        }
    }
}