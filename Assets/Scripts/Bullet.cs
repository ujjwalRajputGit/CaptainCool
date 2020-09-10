﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float bulletSelfDestroyTime = 3f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, bulletSelfDestroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer == 9)
        {
            Destroy(collision.gameObject);
        }
    }
    
}
