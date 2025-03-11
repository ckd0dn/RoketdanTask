using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : Singleton<GameScene>
{
    public event Action StartLoadCallback; 
    private void Awake()
    {
        Managers.Resource.LoadAllAsync<GameObject>("Prefabs", (key, count, totalCount) =>
        {
            Debug.Log($"{key} {count}/{totalCount}");

            if (count == totalCount)
            {
                StartLoad();
            }
        });
    }
    
    void StartLoad()
    {
        StartLoadCallback?.Invoke();
    }
}
