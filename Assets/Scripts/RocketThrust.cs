using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketThrust : MonoBehaviour
{
    private float gravitySpeed = 25f;
    private float impulseFactor = 0.2f;
    private float gravityAccelFactor = 0.001f;
    private float gravityAccel = 0;
    private float currentImpulse = 0;

    private EnumAccelerationState currentAccelerationState;

    public float GravityAccel { get => gravityAccel;  }

    private enum EnumAccelerationState//relacionado al impulso cuando apretas espacio
    {
        Stand,
        Accelerating,
        Decelerating
    }

    // Start is called before the first frame update
    void Start()
    {
        currentAccelerationState = EnumAccelerationState.Stand;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        float posY = transform.position.y;

        gravityAccel += gravityAccelFactor;
        //Debug.Log(gravityAccel);
        float gravityForce = (gravitySpeed * dt *10) + gravityAccel;

        if (Input.GetKey("space"))
        {
            currentAccelerationState = EnumAccelerationState.Accelerating;
        }
        if (Input.GetKeyUp("space"))
        {
            currentAccelerationState = EnumAccelerationState.Decelerating;
        }

        switch (currentAccelerationState)
        {
            case EnumAccelerationState.Stand:
                currentImpulse = 0;
                break;
            case EnumAccelerationState.Accelerating:
                currentImpulse += impulseFactor;
                break;
            case EnumAccelerationState.Decelerating:
                currentImpulse -= impulseFactor;
                gravityAccel = 0;
                if (currentImpulse <= 0)
                {
                    currentAccelerationState = EnumAccelerationState.Stand;
                }
                break;
            default:
                break;
        }

        float impulseForce = currentImpulse * dt * 10;
                Debug.Log("impulseForce " + impulseForce + "____" + gravityForce);
        posY = posY - gravityForce + impulseForce; // == posY -= gravityForce;
        transform.position = new Vector2(transform.position.x, posY);

        //if (transform.position.y <= -350.0f)
        //{
        //    transform.position = new Vector2(transform.position.x, -350.0f);

        //}
    }

    bool checkDownSpeed(float downAccel)
    {
        return downAccel <= 0.01f;
    }
}
