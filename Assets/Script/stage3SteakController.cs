using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3SteakController : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        float playerPosY = player.transform.position.y;
        float playerPosX = player.transform.position.x;
        transform.position = new Vector3(Random.Range(playerPosX + -6, playerPosX + 6), playerPosY + 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
