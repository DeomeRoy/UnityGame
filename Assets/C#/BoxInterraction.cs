using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInterraction : MonoBehaviour
{
    public PlayerCtrl _PlayerCtrl;
    void Start()
    {
        GameObject player = GameObject.Find("Idle");
        _PlayerCtrl = player.GetComponent<PlayerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider hit){
        if (hit.gameObject.name == "Player_Sword" && _PlayerCtrl.PlayerAttacking){
            Destroy(gameObject);
            print("hit Cube");
        }
    }
}
