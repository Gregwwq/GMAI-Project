using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCHealthBar : MonoBehaviour
{
    Transform npc;
    NPC npcScript;

    Image bar;
    float maxHP;

    void Start()
    {
        npc = GameObject.Find("Infected").transform;
        npcScript = npc.gameObject.GetComponent<NPC>();
        bar = transform.Find("Health").gameObject.GetComponent<Image>();

        maxHP = npcScript.Health;
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.position = npc.position + (Vector3.up * 4f);

        bar.fillAmount = npcScript.Health / maxHP;
    }
}
