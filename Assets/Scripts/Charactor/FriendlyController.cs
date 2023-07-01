using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Friendly
{
    public GameObject Charactor;
    public Animator animator;
    public CharactorState CharactorState;
    private string playAnimationName;

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

public class FriendlyController : MonoBehaviour
{
    [SerializeField]
    Transform playerPos;
    public List<Friendly> Friendlies = new List<Friendly>();
    private int friendliesCount = 0;


    public void SetAnimationForAll(string name, AnimationType animationType)
    {
        Friendlies.ForEach(friend =>
        {
            friend.SetAnimation(name, animationType);
        });
    }

    public void AddFriend()
    {
        Friendlies[friendliesCount].Charactor.SetActive(true);
        friendliesCount++;
    }

    public void RemoveFriend()
    {
        friendliesCount--;
        Friendlies[friendliesCount].Charactor.SetActive(false);
        //TODO 先頭のキャラをPlayerPosへ移動させる
    }
}
