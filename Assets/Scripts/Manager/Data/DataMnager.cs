using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMnager : MonoBehaviour
{
    [SerializeField]
    private UserDataManager userDataManager;

    public UserDataManager UserData => userDataManager;
}
