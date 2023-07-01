using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    [SerializeField]
    Button playAgainButton;
    [SerializeField]
    Button titleButton;
    [SerializeField]
    Text coinText;
    [SerializeField]
    Text enemyText;

    private void Start()
    {
        playAgainButton.OnClickAsObservable().Subscribe(
            _ =>
            {
                SceneManager.LoadScene("Main");
            }).AddTo(this);

        titleButton.OnClickAsObservable().Subscribe(
            _ =>
            {
                SceneManager.LoadScene("Title");
            }).AddTo(this);
    }

    public void OnGameEnd(int coin, int enemy)
    {
        this.gameObject.SetActive(true);
        coinText.text = coin.ToString();
        enemyText.text = enemy.ToString();
    }
    
}
