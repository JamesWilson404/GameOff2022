using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField] float MaxSpeed;
    [SerializeField] float Acceleration;
    [SerializeField] float Deceleration;

    float Speed;


    // Update is called once per frame
    void Update()
    {
        ResolveInput();

        if (Speed != 0)
        {
            transform.Translate(Speed, 0, 0);
        }

    }

    private void ResolveInput()
    {
        bool enginesApplied = false;
        if (Input.GetKey(KeyCode.A))
        {
            Speed = Mathf.Clamp(Speed - Acceleration, -MaxSpeed, MaxSpeed);
            enginesApplied = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Speed = Mathf.Clamp(Speed + Acceleration, -MaxSpeed, MaxSpeed);
            enginesApplied = true;
        }

        if (!enginesApplied)
        {
            var direction = Input.GetAxis("Horizontal");
            if (Mathf.Abs(direction) > 0.2f)
            {
                Speed += direction * Acceleration;
                enginesApplied = true;
            }
        }


        if (!enginesApplied)
        {
            if (Speed > 0)
            {
                Speed = Mathf.Max(0, Speed - Deceleration);
            }
            else if (Speed < 0)
            {
                Speed = Mathf.Min(0, Speed + Deceleration);
            }
        }



    }
}
