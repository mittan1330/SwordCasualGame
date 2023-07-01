using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float playerSpeed = 10.0f;
    [SerializeField]
    Animator animator;
    [SerializeField]
    CharactorState charactorState;


    // Start is called before the first frame update
    void Start()
    {
        charactorState = CharactorState.Run;
    }

    // Update is called once per frame
    void Update()
    {
        switch (charactorState)
        {
            case CharactorState.Run:
                animator.SetBool("Run", true);
                break;

        }
        transform.Translate(0, 0, playerSpeed * Time.deltaTime);
    }
}
