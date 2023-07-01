using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FriendlyController : MonoBehaviour
{
    [SerializeField]
    Transform playerPos;
    public List<Transform> Positions = new List<Transform>(5);
    public List<Charactor> Friendlies = new List<Charactor>();

    [SerializeField]
    Charactor friendPrefab;
    [SerializeField]
    Vector3 pivot;
    private int friendliesCount = 0;


    public void SetAnimationForAll(string name, AnimationType animationType)
    {
        Friendlies.ForEach(friend =>
        {
            friend.SetAnimation(name, animationType);
        });
    }

    public void AddFriend(int power)
    {
        var friend = Instantiate(friendPrefab, Positions[friendliesCount]) as Charactor;
        friend.transform.position += pivot * 2;
        friend.Power.Value = power;
        Friendlies.Add(friend);
        friendliesCount++;
    }

    public Charactor SetMainCharactor()
    {
        Charactor charactor = Friendlies[0];
        Friendlies.RemoveAt(0);

        int index = 0;
        Friendlies.ForEach(friend =>
        {
            friend.transform.SetParent(Positions[index]);
            friend.transform.localPosition = new Vector3(0, 0, 0);
            friend.transform.position += pivot;
            index++;
        });
        return charactor;
    }

    public void RemoveFriend()
    {
        friendliesCount--;
        Friendlies[friendliesCount].gameObject.SetActive(false);
        //TODO 先頭のキャラをPlayerPosへ移動させる
    }
}
