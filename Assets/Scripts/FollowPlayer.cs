using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset = new Vector3();
    [SerializeField] Vector3 offRound = new Vector3();
    void Start() 
    {
        transform.rotation = Quaternion.Euler(offRound);
    }
    void LateUpdate()
    {
        // offset the camera behind the player by addding to player's position.
        transform.position = player.transform.position + offset;
    }
}
