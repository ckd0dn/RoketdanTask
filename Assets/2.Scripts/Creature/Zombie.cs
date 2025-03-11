using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    protected float speed = 1f;
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
