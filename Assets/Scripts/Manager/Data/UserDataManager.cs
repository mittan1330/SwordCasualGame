using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UserDataManager : MonoBehaviour
{

    public ReactiveProperty<string> UserName { get; private set; }
    public ReactiveProperty<int> UserLevel { get; private set; }

    private void Awake()
    {
        Initialized();
    }

    private void Initialized()
    {
        UserName = new ReactiveProperty<string>();
        UserLevel = new ReactiveProperty<int>();
    }

    public void DataSet(string name, int level)
    {
        UserName.Value = name;
        UserLevel.Value = level;
    }
}
