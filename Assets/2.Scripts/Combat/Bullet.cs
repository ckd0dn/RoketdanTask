using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    public Rigidbody2D Rb;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        float delay = 3f;
        StartCoroutine(CoDestroyAfterDelay(delay));
    }

    private IEnumerator CoDestroyAfterDelay(float delay)
    {
        var await = new WaitForSeconds(delay); 
        yield return await; // 3초 대기
        Managers.Object.Despawn(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Zombie zombie = other.GetComponent<Zombie>();

        if (zombie != null)
        {
            zombie.OnDamaged(damage);
            Managers.Object.Despawn(this);
        }
    }
}
