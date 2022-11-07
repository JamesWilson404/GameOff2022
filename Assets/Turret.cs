using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Animator Animator;
    [SerializeField] Collider TurretCollider;

    [SerializeField] Transform TurretHead;
    [SerializeField] float RotationSpeed;

    Transform enemy = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            var direction = enemy.position - transform.position;
            direction.y = transform.position.y;

            var rot = Quaternion.LookRotation(direction, Vector3.up);
            TurretHead.rotation = Quaternion.RotateTowards(
                                             TurretHead.rotation,
                                             rot,
                                             -RotationSpeed * Time.deltaTime);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            enemy = other.transform;
        }
    }

    

}
