using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float playerForwardSpeed = 8.0f;
    [SerializeField]
    float playerSidewaysSpeed = 5.0f;

    bool attackCheck = true;
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

                break;

            case CharactorState.Attack:
                if (attackCheck)
                {
                    animator.SetTrigger("Attack");
                    attackCheck = false;
                }

                break;
        }



    }

    private void ForwardHit(string tagName)
    {
        if(tagName == "Friendly")
        {
            Debug.Log("仲間を見つけた！");
        }
        if (tagName == "Enemy")
        {
            Debug.Log("敵を見つけた！");
            charactorState = CharactorState.Attack;
            attackCheck = true;
        }
    }

    private void GameStart()
    {
        charactorState = CharactorState.Run;
    }
}
