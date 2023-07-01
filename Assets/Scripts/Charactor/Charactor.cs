using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class Charactor : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    GameObject smokePrefab;
    [SerializeField]
    private Text powerText;
    public ReactiveProperty<int> Power;

    public CharactorState CharactorState;
    private string playAnimationName;

    private void Start()
    {
        powerText.text = Power.Value.ToString();
        Power.Subscribe(_ =>
        {
            powerText.text = _ <= 0 ? "" :_.ToString();
        }).AddTo(this);
    }

    public IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetTrigger("Dead");
        yield return new WaitForSeconds(0.5f);
        var smoke = Instantiate(smokePrefab);
        smoke.transform.position = this.transform.position;
        Destroy(this.gameObject);
    }



    public void SetAnimation(string name, AnimationType animationType)
    {
        switch (animationType)
        {
            case AnimationType.Bool:
                animator.SetBool(playAnimationName, false);
                animator.SetBool(name, true);
                playAnimationName = name;
                break;
            case AnimationType.Trigger:
                animator.SetBool(playAnimationName, false);
                animator.SetTrigger(name);
                break;
        }
    }
}
