using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerPower = 1;
    private int remainEnemyHp;
    bool attackSequence = false;

    [SerializeField]
    float playerForwardSpeed = 8.0f;
    [SerializeField]
    float playerSidewaysSpeed = 5.0f;

    [SerializeField]
    float stageWidth = 3.0f;
    [SerializeField]
    FloatingJoystick joystick;

    [SerializeField]
    Animator animator;
    [SerializeField]
    CharactorState charactorState;
    [SerializeField]
    Transform weaponPos;

    [SerializeField]
    private HitNotifier forwardHitNotifier;
    [SerializeField]
    FriendlyController friendlyController;
    private GameObject enemyObject;

    // Start is called before the first frame update
    void Start()
    {
        forwardHitNotifier.OnHit += ForwardHit;
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        switch (charactorState)
        {
            case CharactorState.Run:
                // Playerの移動制御
                animator.SetBool("Run", true);
                transform.Translate(0, 0, playerForwardSpeed * Time.deltaTime);
                var sideMoveSpeed = playerSidewaysSpeed * Time.deltaTime * joystick.Horizontal;
                if (this.transform.position.x >= stageWidth)
                {
                    sideMoveSpeed = sideMoveSpeed > 0 ? 0 : sideMoveSpeed;
                }
                else if (this.transform.position.x <= -stageWidth)
                {
                    sideMoveSpeed = sideMoveSpeed < 0 ? 0 : sideMoveSpeed;
                }
                transform.Translate(sideMoveSpeed, 0, 0);

                // Friendの移動制御
                friendlyController.SetAnimationForAll("Run", AnimationType.Bool);



                break;

            case CharactorState.Attack:
                if (attackSequence)
                {
                    // Friendの移動制御
                    friendlyController.SetAnimationForAll("Idol", AnimationType.Bool);
                    animator.SetBool("Run", false);
                    animator.SetBool("Idol", true);
                    attackSequence = false;

                    StartCoroutine(AttackSequence());
                }
                break;
        }

    }


    IEnumerator AttackSequence()
    {
        animator.SetTrigger("Attack");
        var enemy = enemyObject.GetComponent<Enemy>();
        remainEnemyHp = enemy.GetDamage(PlayerPower);

        if(remainEnemyHp > 0)
        {
            Debug.Log("Player Dead");
            animator.SetTrigger("Dead");
            animator.SetBool("Idol", false);
            // Friendから1人移動させる
            yield return new WaitForSeconds(1.0f);
            // 雲を出す
            animator.SetBool("Idol", true);
            friendlyController.RemoveFriend();
        }
        else
        {
            StartCoroutine(enemy.Dead());
            yield return new WaitForSeconds(2.0f);
            charactorState = CharactorState.Run;
        }
        yield return null;
    }


    private void ForwardHit(string tagName,GameObject other)
    {
        if(tagName == "Friendly")
        {
            Debug.Log("仲間を見つけた！");
            Destroy(other);
            friendlyController.AddFriend();
        }
        if (tagName == "Enemy")
        {
            Debug.Log("敵を見つけた！");
            attackSequence = true;
            enemyObject = other;
            charactorState = CharactorState.Attack;
        }
    }

    private void GameStart()
    {
        charactorState = CharactorState.Run;
    }
}
