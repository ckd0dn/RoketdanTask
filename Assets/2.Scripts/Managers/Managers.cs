using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : Singleton<Managers>
{
    ResourceManager resourceManager = new ResourceManager();
    ObjectManager objectManager = new ObjectManager();
    PoolManager poolManager = new PoolManager();
    UIManager uIManager = new UIManager();
   

    public static ResourceManager Resource { get { return Instance.resourceManager; } }
    public static ObjectManager Object { get { return Instance.objectManager; } }
    public static PoolManager Pool { get { return Instance.poolManager; } }
    public static UIManager UI { get { return Instance.uIManager; } }
 


}
