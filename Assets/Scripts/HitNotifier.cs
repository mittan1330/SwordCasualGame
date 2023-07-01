using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HitNotifier : MonoBehaviour
{
    public Action<string> OnHit;

    private void OnTriggerEnter(Collider other)
    {
        OnHit?.Invoke(other.tag);
    }
}
