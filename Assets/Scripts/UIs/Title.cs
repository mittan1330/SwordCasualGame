using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField]
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        button.OnClickAsObservable().Subscribe(_ => SceneManager.LoadScene("Main")).AddTo(this);
    }
}
