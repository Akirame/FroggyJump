using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {


    private GameObject player;

    private void Start()
    {
        player = Player.Get().gameObject;
    }
    private void Update()
    {
        transform.position = player.transform.position;
    }
}
