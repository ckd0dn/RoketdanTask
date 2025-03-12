using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;     
    public float bulletSpeed = 10f; 
    public float spreadAngle = 15f; 

    public void FireBullet(Transform target)
    {
        if (target == null) return; 

        Vector2 direction = (target.position - firePoint.position).normalized;
        
        Shoot(direction, 0);                
        Shoot(direction, spreadAngle);       
        Shoot(direction, -spreadAngle);    
    }

    private void Shoot(Vector2 direction, float angleOffset)
    {
    
        Bullet bullet = Managers.Object.Spawn<Bullet>("Bullet.prefab");
        bullet.transform.position = firePoint.position;
        
        if (bullet.Rb != null)
        {
            Vector2 rotatedDirection = RotateVector(direction, angleOffset);
            bullet.Rb.velocity = rotatedDirection * bulletSpeed; 
        }
    }

    private Vector2 RotateVector(Vector2 vector, float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float cos = Mathf.Cos(radian);
        float sin = Mathf.Sin(radian);

        return new Vector2(
            vector.x * cos - vector.y * sin,
            vector.x * sin + vector.y * cos
        );
    }
}
