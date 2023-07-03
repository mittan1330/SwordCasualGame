using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private int remainEnemyHp;
    bool attackSequence = false;

    public float playerForwardSpeed = 8.0f;
    [SerializeField]
    float playerSidewaysSpeed = 5.0f;

    [SerializeField]
    float stageWidth = 3.0f;
    [SerializeField]
    FloatingJoystick joystick;

    [SerializeField]
    Charactor mainCharactor;
    [SerializeField]
    Transform mainCharactorTransform;

    public CharactorState charactorState;
    [SerializeField]
    Transform weaponPos;

    [SerializeField]
    private HitNotifier forwardHitNotifier;
    [SerializeField]
    FriendlyController friendlyController;
    private GameObject enemyObject;

    public Action OnGetCoin;
    public Action OnEnemyKill;
    public Action OnGameOver;

    bool runCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        forwardHitNotifier.OnHit += ForwardHit;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (charactorState)
        {
            case CharactorState.Run:


                transform.Translate(0, 0, playerForwardSpeed * Time.fixedDeltaTime);
                var sideMoveSpeed = playerSidewaysSpeed * Time.fixedDeltaTime * joystick.Horizontal;
                if (this.transform.position.x >= stageWidth)
                {
                    sideMoveSpeed = sideMoveSpeed > 0 ? 0 : sideMoveSpeed;
                }
                else if (this.transform.position.x <= -stageWidth)
                {
                    sideMoveSpeed = sideMoveSpeed < 0 ? 0 : sideMoveSpeed;
                }
                transform.Translate(sideMoveSpeed, 0, 0);

                if (!runCheck)
                {
                    // Playerの移動制御
                    mainCharactor.SetAnimation("Run", AnimationType.Bool);
                    // Friendの移動制御
                    friendlyController.SetAnimationForAll("Run", AnimationType.Bool);
                    runCheck = true;
                }

                break;

            case CharactorState.Attack:
                if (attackSequence)
                {
                    // Friendの移動制御
                    friendlyController.SetAnimationForAll("Idol", AnimationType.Bool);
                    mainCharactor.SetAnimation("Idol", AnimationType.Bool);

                    attackSequence = false;

                    StartCoroutine(AttackSequence());
                }
                break;
        }

    }


    IEnumerator AttackSequence()
    {
        while (mainCharactor != null)
        {
            mainCharactor.SetAnimation("Attack", AnimationType.Trigger);

            var enemy = enemyObject.GetComponent<Enemy>();
            remainEnemyHp = enemy.GetDamage(mainCharactor.Power.Value);

            if (remainEnemyHp > 0)
            {
                StartCoroutine(mainCharactor.Dead());
                yield return new WaitForSeconds(1.2f);

                if(friendlyController.Friendlies.Count <= 0)
                {
                    Debug.Log("GameOver");
                    OnGameOver?.Invoke();
                    yield return null;
                    break;
                }

                mainCharactor = friendlyController.SetMainCharactor();
                mainCharactor.transform.SetParent(mainCharactorTransform);
                mainCharactor.transform.localPosition = new Vector3(0, 0, 0);
                // TODO 将来的にDOTWEENさせたい
                //mainCharactor.transform.DOMove(new Vector3(0, 0, 0), 1).SetRelative(true);
                yield return new WaitForSeconds(1.0f);
            }
            else
            {
                OnEnemyKill?.Invoke();
                yield return new WaitForSeconds(2.0f);
                charactorState = CharactorState.Run;
                runCheck = false;
                break;
            }

        }
        yield return null;
    }


    private void ForwardHit(string tagName,GameObject other)
    {
        if(tagName == "Friendly")
        {
            Debug.Log("仲間を見つけた！");
            int power = other.GetComponent<FriendlyStand>().charactor.Power.Value;
            Destroy(other);
            friendlyController.AddFriend(power);
            runCheck = false;
        }
        if (tagName == "Enemy")
        {
            Debug.Log("敵を見つけた！");
            attackSequence = true;
            enemyObject = other;
            charactorState = CharactorState.Attack;
            runCheck = false;
        }
        if(tagName == "Coin")
        {
            Destroy(other);
            OnGetCoin?.Invoke();
        }
    }

    public void SetCharactorState(CharactorState state)
    {
        charactorState = state;
        runCheck = false;
    }
}
