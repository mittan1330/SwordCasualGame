using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FriendlyController : MonoBehaviour
{
    [SerializeField]
    Transform playerPos;
    public List<GameObject> Friendlies = new List<GameObject>();
    private int friendliesCount = 0;


    public void SetAnimationForAll(string name, AnimationType animationType)
    {
        Friendlies.ForEach(friend =>
        {
            friend.GetComponent<Charactor>().SetAnimation(name, animationType);
        });
    }

    public void AddFriend()
    {
        Friendlies[friendliesCount].gameObject.SetActive(true);
        friendliesCount++;
    }

    public void RemoveFriend()
    {
        friendliesCount--;
        Friendlies[friendliesCount].gameObject.SetActive(false);
        //TODO 先頭のキャラをPlayerPosへ移動させる
    }
}
