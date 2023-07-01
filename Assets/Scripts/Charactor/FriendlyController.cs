using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FriendlyController : MonoBehaviour
{
    [SerializeField]
    Player player;
    public List<Transform> Positions = new List<Transform>(5);
    public List<Charactor> Friendlies = new List<Charactor>();

    [SerializeField]
    Charactor friendPrefab;
    [SerializeField]
    Vector3 pivot;
    [SerializeField]
    float interval;
    private int friendliesCount = 0;


    private void FixedUpdate()
    {
        if (player.charactorState == CharactorState.Run)
        {
            transform.Translate(0, 0, player.playerForwardSpeed * Time.fixedDeltaTime);
            var pos = Positions[0].transform.position;
            pos.z = player.transform.position.z + interval;
            Positions[0].transform.position = pos;
            float posX = 0;

            if(Positions[0].position.x + 0.1f < player.transform.position.x)
            {
                posX = Time.fixedDeltaTime * 3;
            }
            if (Positions[0].position.x - 0.1f > player.transform.position.x)
            {
                posX = Time.fixedDeltaTime * -3;
            }
            //posX = Positions[0].position.x < player.transform.position.x ? Time.deltaTime * 5 : 0;
            Positions[0].position += new Vector3(posX, 0, 0);
        }
    }

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
        var pos = friend.transform.localPosition;
        friend.transform.localPosition = new Vector3(pos.x,0, pos.z);
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
            //var pos = friend.transform.position;
            //friend.transform.position += pivot;
            friend.transform.localPosition = new Vector3(0, 0, 0);
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
