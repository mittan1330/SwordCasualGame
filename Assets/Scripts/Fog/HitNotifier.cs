using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HitNotifier : MonoBehaviour
{

    public Action OnHitPlayer;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            OnHitPlayer?.Invoke();
        }
    }
}
