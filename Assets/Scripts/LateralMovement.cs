using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralMovement : MonoBehaviour
{
    private Vector2 pos;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("right"))
        {
            pos = transform.position;
            pos.x += -1f;
            transform.position = pos;
        }

        if (Input.GetKey("left"))
        {
            pos = transform.position;
            pos.x += 1f;
            transform.position = pos;
        }

        if (transform.position.x < -470.0f)
        {
            transform.position = new Vector2(-470f, transform.position.y);
        }
        else if(transform.position.x > 470.0f)
        {
            transform.position = new Vector2(470f, transform.position.y);
        }
    }
}
