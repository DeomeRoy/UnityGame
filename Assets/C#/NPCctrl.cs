using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NPCctrl : MonoBehaviour{
    // 變數宣告
    NavMeshAgent NPCnav;
    Animator NPCanimator;
    public Transform Target;
    float NPCwalkSpeed;
    public static bool NPCisAttking = false;

    // NPC血量相關
    public int NPC_maxHP = 100;
    public int NPC_HP;
    public Image NPC_HPimg;

    void Start(){
        NPCnav = GetComponent<NavMeshAgent>();
        NPCanimator = GetComponent<Animator>();

        GameObject player = GameObject.Find("Idle");
        
        Target = player.transform;
        NPCwalkSpeed = NPCnav.velocity.magnitude;

        Transform NPC_HPbar = transform.Find("NPC_Canvas/NPC_HPbar");
        NPC_HPimg = NPC_HPbar.GetComponent<Image>();

        NPC_HP = NPC_maxHP;
    }

    void Update(){
        // NPC_HPimg.fillAmount = (float)NPC_HP / NPC_maxHP;
        NPCwalkSpeed = NPCnav.velocity.magnitude;
        NPCanimator.SetFloat("WalkSpeed", NPCwalkSpeed);
        float MPCplayeristance = Vector3.Distance(Target.position, transform.position);
        if (MPCplayeristance < 5f){
            NPCnav.SetDestination(Target.position);
            // if(NPCplayeristance < 0.75f){
            //     Vector3 TargetPos = Target.position;
            //     TargetPos.y = transform.position.y;
            //     transform.LookAt(TargetPos);
            //     NPCisAttking = NPCanimator.SetFloat("NPC-PunchTime")> 0.01f? true : false;
            // }
        }
    }
}
