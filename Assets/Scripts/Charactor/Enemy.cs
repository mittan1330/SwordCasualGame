using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public int Power = 1;
    [SerializeField]
    Charactor charactor;

    // Start is called before the first frame update
    void Start()
    {
        charactor.powerText.text = Power.ToString();
    }

    public int GetDamage(int value)
    {
        Power -= value;
        charactor.powerText.text = Power.ToString();
        if (Power > 0) Dead();
        return Power > 0 ? Power : 0;
    }

    public void Dead()
    {
        StartCoroutine(charactor.Dead());
    }
}
