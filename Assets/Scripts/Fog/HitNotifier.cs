using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HitNotifier : MonoBehaviour
{
    [SerializeField]
    string tagName = "";
    public Action OnHitPlayer;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == tagName)
        {
            OnHitPlayer?.Invoke();
        }
    }
}
