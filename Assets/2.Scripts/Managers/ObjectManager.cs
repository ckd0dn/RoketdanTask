using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    public Hero Hero { get; private set; }
    public HashSet<ZombieMelee> ZombieMelees { get; private set; } = new HashSet<ZombieMelee>();
    public HashSet<Bullet> Bullets { get; private set; } = new HashSet<Bullet>();
    
    public T Spawn<T>(string key) where T : MonoBehaviour
    {
        System.Type type = typeof(T);

        if (type == typeof(Hero))
        {
            GameObject go = Managers.Resource.Instantiate(key, pooling: false);
            Hero p = go.GetComponent<Hero>();

            Hero = p;

            return p as T;
        }
        else if (type == typeof(ZombieMelee))
        {
            GameObject go = Managers.Resource.Instantiate(key, pooling: true);
            ZombieMelee m = go.GetComponent<ZombieMelee>();
            
            ZombieMelees.Add(m);
            return m as T;
        }
        else if (type == typeof(Bullet))
        {
            GameObject go = Managers.Resource.Instantiate(key, pooling: true);
            Bullet m = go.GetComponent<Bullet>();
            
            Bullets.Add(m);
            return m as T;
        }
        return null;
    }

    public void Despawn<T>(T obj) where T : MonoBehaviour
    {
        System.Type type = typeof(T);

        if (type == typeof(Hero))
        {

        }
        else if (type == typeof(ZombieMelee))
        {
            ZombieMelees.Remove(obj as ZombieMelee);
            Managers.Resource.Destroy(obj.gameObject);
        }
        else if (type == typeof(Bullet))
        {
            Bullets.Remove(obj as Bullet);
            Managers.Resource.Destroy(obj.gameObject);
        }
    }
}
