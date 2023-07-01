using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class GameManager : MonoBehaviour
{
    // UIs
    [SerializeField]
    private Slider StageRemainingSlider;
    [SerializeField]
    private Text CoinCountText;
    public ReactiveProperty<int> coinCount;
    [SerializeField]
    private Text EnemyCountText;
    public ReactiveProperty<int> enemyCount;
    // UI sets
    [SerializeField]
    Result gameOverResult;
    [SerializeField]
    Result gameClearResult;

    // Game Objects
    [SerializeField]
    private float stageLength;
    [SerializeField]
    private Player player;
    [SerializeField]
    private Enemy boss;

    // Start is called before the first frame update
    void Start()
    {
        StageRemainingSlider.maxValue = stageLength;
        coinCount.Subscribe(_ => CoinCountText.text = _.ToString()).AddTo(this);
        enemyCount.Subscribe(_ => EnemyCountText.text = _.ToString()).AddTo(this);

        player.OnGetCoin += AddCoin;
        player.OnEnemyKill += AddEnemyCount;
        player.OnGameOver += GameOver;
        boss.OnDeadBoss += GameClear;
        GameStart();
    }

    private void GameStart()
    {
        coinCount.Value = 0;
        enemyCount.Value = 0;
        player.SetCharactorState(CharactorState.Run);
    }

    // Update is called once per frame
    void Update()
    {
        StageRemainingSlider.value = player.transform.position.z;
    }

    void AddCoin()
    {
        coinCount.Value += 1;
    }

    void AddEnemyCount()
    {
        enemyCount.Value += 1;
    }

    void GameOver()
    {
        StartCoroutine(GameOverCoroutine());
    }

    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        gameOverResult.OnGameEnd(coinCount.Value, enemyCount.Value);
    }

    void GameClear()
    {
        StartCoroutine(GameClearCoroutine());
    }

    IEnumerator GameClearCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        gameClearResult.OnGameEnd(coinCount.Value, enemyCount.Value);
    }
}
