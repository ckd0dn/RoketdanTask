using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    public Player Player { get; private set; }
    public HashSet<Monster> Monsters { get; private set; } = new HashSet<Monster>();
    
    public T Spawn<T>(string key) where T : MonoBehaviour
    {
        System.Type type = typeof(T);

        if (type == typeof(Player))
        {
            GameObject go = Managers.Resource.Instantiate(key, pooling: true);
            Player p = go.GetComponent<Player>();

            Player = p;

            return p as T;
        }
        else if (type == typeof(Monster))
        {
            GameObject go = Managers.Resource.Instantiate(key, pooling: true);
            Monster m = go.GetComponent<Monster>();
            
            Monsters.Add(m);
            return m as T;
        }

        return null;
    }

    public void Despawn<T>(T obj) where T : MonoBehaviour
    {
        System.Type type = typeof(T);

        if (type == typeof(Player))
        {

        }
        else if (type == typeof(Monster))
        {
            Monsters.Remove(obj as Monster);
            Managers.Resource.Destroy(obj.gameObject);
        }

    }
}
