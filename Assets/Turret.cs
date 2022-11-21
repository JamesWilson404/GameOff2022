using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Animator Animator;
    [SerializeField] Transform TurretHead;
    [SerializeField] Transform Muzzle;
    [SerializeField] float RotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ResolveInput();
        Debug.DrawRay(Muzzle.position, TurretHead.forward);
    }

    public void ResolveInput()
    {
        var direction = Input.GetAxis("CanonRotate");
        TurretHead.Rotate(Vector3.up, RotationSpeed * direction);

        Animator.SetBool("Fire", Input.GetButton("Fire1"));

    }

    public void ShootTurret()
    {
        AudioManager.Instance.PlaySound(SoundFX.LASER_SHOOT);
    }
}
