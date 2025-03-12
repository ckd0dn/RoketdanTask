using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _attackDelay = 1f; 
    private Animator _animator;
    private Gun _gun;


    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _gun = GetComponentInChildren<Gun>();
    }

    private void Start()
    {
        StartCoroutine(CoAttack());
    }

    private IEnumerator CoAttack()
    {
        var wait = new WaitForSeconds(_attackDelay);
        
        while (true) 
        {
            Attack(); 
            yield return wait; 
        }
    }

    private void Attack()
    {
        Zombie zombie = GetClosestZombie();
        
        if (zombie != null)
        {
            RotateGun(zombie.transform);
            // animation
            _animator.SetTrigger("Attack");
            // shot bullet
            _gun.FireBullet(zombie.transform);
        }
    }

    private Zombie GetClosestZombie()
    {
        return Managers.Object.ZombieMelees
            .OrderBy(zombie => Vector3.Distance(transform.position, zombie.transform.position))
            .FirstOrDefault();
    }
    
    private void RotateGun(Transform target)
    {
        if (target == null) return;

        Vector3 direction = target.position - _gun.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        _gun.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
        
}
