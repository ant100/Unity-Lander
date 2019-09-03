using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour
{
    [SerializeField]
    private RocketThrust rocketThrust;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime);
        //transform.position = transform.position - new Vector3(0, 0.7f, 0);



        if (transform.position.y <= -350.0f)
        {
            // game over
            /*bool win = checkDownSpeed(rocketThrust.GravityAccel);
            if (win)
            {
                Debug.Log("You win!");
            }
            else
            {
                Debug.Log("You lost!");
            }*/
        }
    }

    private bool checkDownSpeed(float gravityAccel)
    {
        return gravityAccel <= 0.01f;
    }


}
