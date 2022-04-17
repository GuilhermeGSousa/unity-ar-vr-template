using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float initialSpeed = 10f;
    
    void Start()
    {
        rb.velocity = transform.forward * initialSpeed;
    }
}
