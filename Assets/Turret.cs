using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Animator Animator;
    [SerializeField] Collider TurretCollider;

    [SerializeField] Transform TurretHead;
    [SerializeField] float RotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ResolveInput();
    }

    public void ResolveInput()
    {
        bool rdirection = Input.GetButton("Fire1");
        bool ldirection = Input.GetButton("Fire2");
        if (rdirection && ldirection)
        {
            return;
        }

        if (Input.GetKey(KeyCode.A) || rdirection)
        {
            TurretHead.Rotate(Vector3.up, -RotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D) || ldirection)
        {
            TurretHead.Rotate(Vector3.up, RotationSpeed);
        }


    }


}
