using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform exitPoint;

    public void Shoot()
    {
        Instantiate(bullet, exitPoint.position, exitPoint.rotation);
    }
}
