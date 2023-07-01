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

    // Game Objects
    [SerializeField]
    private float stageLength;
    [SerializeField]
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        StageRemainingSlider.maxValue = stageLength;
        StageRemainingSlider.value = stageLength;
        coinCount.Subscribe(_ => CoinCountText.text = _.ToString()).AddTo(this);
        player.OnGetCoin += GetCoin;
        GameStart();
    }

    private void GameStart()
    {
        coinCount.Value = 0;
        player.SetCharactorState(CharactorState.Run);
    }

    // Update is called once per frame
    void Update()
    {
        StageRemainingSlider.value = stageLength - player.transform.position.z;
    }

    void GetCoin()
    {
        coinCount.Value += 1;
    }
}
