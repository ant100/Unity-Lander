using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField]
    private float gravity = 9.8f;
    [SerializeField]
    private float force = 50.0f;
    [SerializeField]
    private float conversionFactor = 0.001f;
    float rightForce;
    float leftForce;
    private Vector3 pos;
    private float lastDownSpeed;
    private float lastUpSpeed;
    private int time;
    private bool acelerating;
    private bool stopAceleration;
    private bool moveRight = false;
    private bool moveLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        acelerating = false;
        stopAceleration = false;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // naturally falls down (h = 0.5gt2)
        if(!acelerating)
        {
            // every frame it acelerates due to gravity
            pos = transform.position;
            pos.y -= downSpeed();
            transform.position = pos;
            time++;            
        }
        
        // stop at bottom edge
        if (transform.position.y <= -350.0f)
        {
            transform.position = new Vector2(transform.position.x, -350.0f);
            /*lastDownSpeed = downSpeed();
            if(lastDownSpeed > 1f)
            {
                Debug.Log(lastDownSpeed);
                Debug.Log("you lost!");
            }
            else
            {
                Debug.Log(lastDownSpeed);
                Debug.Log("you win!");
            }*/
        }

        // if I press the up bottom, stop falling down
        if (Input.GetKeyDown("up"))
        {
            acelerating = true;
            lastDownSpeed = downSpeed();
            time = 0; // start time since going up    
        }

        if (Input.GetKey("up"))
        {
            // add force to current pos, it increments on each frame
            pos.y += (force * time * conversionFactor) - lastDownSpeed;
            transform.position = pos;
            time++;
        }

        /*if (Input.GetKey("right"))
        {
            rightForce = force / 5;
            moveRight = true;
            //moveLeft = false;
        }

        if(moveRight && pos.x >= -470f && rightForce >= 0)
        {
            // add force to current pos, it increments on each frame
            pos.x -= ( (rightForce) * time * conversionFactor);
            transform.position = pos;
            rightForce -= 0.09f;
        }

        if (Input.GetKey("left"))
        {
            leftForce = force / 5;
            moveLeft = true;
            //moveRight = false;
        }

        if(moveLeft && pos.x <= 470f && leftForce >= 0)
        {
            // add force to current pos, it increments on each frame
            pos.x += ((leftForce) * time * conversionFactor);
            transform.position = pos;
            leftForce -= 0.09f;
        }*/

        // I stop acelerating (h = vt + 0.5at2)
        if (Input.GetKeyUp("up"))
        {
            stopAceleration = true;
            lastUpSpeed = force * time * conversionFactor;
            time = -1; // start time since starting to fall
        }

        if (stopAceleration)
        {
            pos.y += (lastUpSpeed/10) - downSpeed(); // (h = vt + 0.5at2)
            transform.position = pos;
            time++;

            if(pos.y < 0)
            {
                acelerating = false;
                stopAceleration = false;
            }
        }

        // this is for testing
        if (transform.position.y >= 350f)
        {
            transform.position = new Vector2(transform.position.x, 350f);
        }
    }

    float downSpeed()
    {
        return time * time * conversionFactor * gravity * 0.5f * Time.deltaTime;
    }
}
