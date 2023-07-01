using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{


    [SerializeField]
    Charactor charactor;
    public bool isBoss = false;

    public int GetDamage(int value)
    {
        charactor.Power.Value -= value;
        if (charactor.Power.Value <= 0) Dead();
        return charactor.Power.Value > 0 ? charactor.Power.Value : 0;
    }

    public void Dead()
    {
        StartCoroutine(charactor.Dead());
    }
}
