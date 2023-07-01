using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Slider StageRemainingSlider;
    [SerializeField]
    private float stageLength;
    [SerializeField]
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        StageRemainingSlider.maxValue = stageLength;
        StageRemainingSlider.value = stageLength;
    }

    // Update is called once per frame
    void Update()
    {
        StageRemainingSlider.value = stageLength - player.transform.position.z;
    }
}
