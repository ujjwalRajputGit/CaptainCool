using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePosition;
    public Animator animator;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.Play("Player_Fire");
            fire();
        }

    }

    void fire()
    {
        Instantiate(bullet, firePosition.position, firePosition.rotation);
    }

}
