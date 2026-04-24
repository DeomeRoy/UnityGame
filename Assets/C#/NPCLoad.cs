using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NPC_spawner npc01 = new NPC_spawner();
        npc01.spwanerNPC(120, 5, 10, pos);

        NPC_spawner npc02 = new NPC_spawner();
        npc02.spwanerNPC(200, 10, 20, pos);
    }

    // Update is called once per frame
    void Update()
    {
        float numer = Random.Range(0, 2000f);
        if(NPC_Total > 0 && numer < 1){
            GameObject NPC = Instantiate(Resources.Load("NPC",typeof(GameObject))) as GameObject;
            NPC.transform.position = transform.position + Vector3(Random.Range(-2f, 2), 0, Random.Range(-2f, 2));
            NPC_Total--;
        }
    }
}

public class NPC_spawner: MonoBehaviour{
    public void spwanerNPC(int hp,int DeteDist,int attkPower,Vector3 pos){
        GameObject NPC = Instantiate(Resources.Load("NPC",typeof(GameObject))) as GameObject;
        NPC.transform.position = pos;
        NPCctrl npcctrl = NPC.GetComponent<NPCctrl>();
        npcctrl.NPC_maxHP = hp;
    }
}