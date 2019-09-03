using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedRocket : MonoBehaviour
{
    [SerializeField]
    private float gravity = 0.1f;
    [SerializeField]
    private float velocityX = 0f;
    [SerializeField]
    private float velocityY = 0f;
    [SerializeField]
    private float thrust = 0f;
    private Vector3 pos;
    private float angle = Mathf.PI / 180;
    private bool rotatingLeft = false;
    private bool rotatingRight = false;
    private bool engineOn = false;

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        pos.x += velocityX;
        pos.y += velocityY; 

        if(Input.GetKeyDown("right"))
        {
            rotatingRight = true;
        }
        else if(Input.GetKeyDown("left"))
        {
            rotatingLeft = true;
        }
        else if (Input.GetKeyDown("up"))
        {
            engineOn = true;
        }

        if (Input.GetKeyUp("right"))
        {
            rotatingRight = false;
        }
        else if (Input.GetKeyUp("left"))
        {
            rotatingLeft = false;
        }
        else if (Input.GetKeyUp("up"))
        {
            engineOn = false;
        }

        if (rotatingRight)
        {
            angle += Mathf.PI / 180;
        }
        else if(rotatingLeft)
        {
            angle -= Mathf.PI / 180;
        }

        if(engineOn)
        {
            velocityX += thrust * Mathf.Sin(-angle);
            velocityY += thrust * Mathf.Cos(angle);
        }
        velocityY -= gravity;
        transform.position = pos;

        if (transform.position.y <= -350.0f)
        {
            transform.position = new Vector2(transform.position.x, -350.0f);
        }

        if (transform.position.x <= -470.0f)
        {
            transform.position = new Vector2(-470f, transform.position.y);
        }

        if (transform.position.x >= 470.0f)
        {
            transform.position = new Vector2(470f, transform.position.y);
        }
    }
}
