using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public int Health { get; set; } = 10;
    public int MaxHealth { get; set; } = 10;
    private SpriteRenderer[] _sprites;
    protected HpBar hpbar;

    protected virtual void Awake()
    {
        _sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Init();
    }

    private void Update()
    {
        if(hpbar != null)
        {
            hpbar.UpdatePosition(transform);
        }
    }

    private void Init()
    {
        Health = MaxHealth;
        
        hpbar = Managers.Object.Spawn<HpBar>("HpBar.prefab");

        foreach (SpriteRenderer sr in _sprites)
        {
            sr.color = Color.white;
        }
    }

    public virtual void OnDamaged(int damage)
    {
        if (Health <= 0)
            return;

        Health -= damage;
        
        if(hpbar != null) hpbar.UpdateHpBar(MaxHealth, Health);
        
        TakeHit();

        if (Health <= 0)
        {
            Health = 0;
            OnDead();
        }
    }
    
    protected virtual void OnDead()
    {
        Managers.Object.Despawn<HpBar>(hpbar);
        hpbar = null;
    }
    
    private void TakeHit()
    {
        StartCoroutine(HitEffectCoroutine());
    }

    private IEnumerator HitEffectCoroutine()
    {
        Dictionary<SpriteRenderer, Color> originalColors = new Dictionary<SpriteRenderer, Color>();
    
        foreach (SpriteRenderer sr in _sprites)
        {
            originalColors[sr] = sr.color; 
            sr.color = Color.red;
        }

        yield return new WaitForSeconds(0.2f); 

        foreach (SpriteRenderer sr in _sprites)
        {
            sr.color = originalColors[sr]; 
        }
    }

 
}
