using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    public enum ObjectType
    {
        Player,
        Monster,
    }

    public enum CreatureState
    {
        Idle,
        Walk,
        Attack,
        Hurt,
        Death,
    }

}
