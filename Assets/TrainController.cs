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
        var vDirection = Input.GetAxis("Vertical");
        var hDirection = Input.GetAxis("Horizontal");
        var direction = 0f;

        if (vDirection == 0 && hDirection == 0)
        {
            if (Speed > 0)
            {
                Speed = Mathf.Max(0, Speed - Deceleration);
            }
            else if (Speed < 0)
            {
                Speed = Mathf.Min(0, Speed + Deceleration);
            }
            return;
        }

        if (Mathf.Abs(vDirection) > Mathf.Abs(hDirection))
        {
            direction = Mathf.Sign(vDirection);
        }
        else
        {
            direction = -Mathf.Sign(hDirection);
        }


        if (Input.GetKey(KeyCode.W))
        {
            Speed = Mathf.Clamp(Speed - Acceleration, -MaxSpeed, MaxSpeed);
            enginesApplied = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Speed = Mathf.Clamp(Speed + Acceleration, -MaxSpeed, MaxSpeed);
            enginesApplied = true;
        }

        if (!enginesApplied)
        {
            if (Mathf.Abs(direction) > 0.2f)
            {
                Speed += direction * -Acceleration;
                enginesApplied = true;
            }
        }




    }
}
