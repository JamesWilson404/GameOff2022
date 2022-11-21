using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField] float MaxSpeed;
    [SerializeField] float Acceleration;
    [SerializeField] float Deceleration;
    [SerializeField] float BrakingPower;

    float Speed;


    // Update is called once per frame
    void Update()
    {
        ResolveInput();
        Speed = Mathf.Clamp(Speed, -MaxSpeed, MaxSpeed);
        transform.Translate(Speed * Time.deltaTime, 0, 0);
    }

    private void ResolveInput()
    {
        bool thisFrameInput = false;

        //  Right Movement
        if (Input.GetKey(KeyCode.D))
        {
            thisFrameInput = true;
            if (Speed >= 0)
            {
                Speed += Acceleration;
            }
            else
            {
                Speed = Mathf.Clamp(Speed + Acceleration, -MaxSpeed, 0);
            }
        }

        //  Left Movement
        if (Input.GetKey(KeyCode.A))
        {
            thisFrameInput = true;
            if (Speed <= 0)
            {
                Speed -= Acceleration;
            }
            else
            {
                Speed = Mathf.Clamp(Speed - Acceleration, 0, MaxSpeed);
            }
        }

        //  Braking
        if (Input.GetKey(KeyCode.S))
        {
            if (Speed < 0)
            {
                Speed = Mathf.Clamp(Speed + BrakingPower, -MaxSpeed, 0);
            }
            else if (Speed > 0)
            {
                Speed = Mathf.Clamp(Speed - BrakingPower, 0, MaxSpeed);
            }
        }
        


    }
}
