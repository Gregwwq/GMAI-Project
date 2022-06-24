using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPCStateMachine;

public class NPC : MonoBehaviour
{
    NPCSM<string> sm;
    NPCState<string> idle; 

    void Start()
    {
        sm = new NPCSM<string>();

        idle = new IdleState(sm);
    }

    private void Update()
    {
        sm.Update();
    }

    public void UpdateFallDownPosition()
    {
        Vector3 center = transform.Find("Infected").gameObject.GetComponent<Renderer>().bounds.center;
        //transform.position = new Vector3(center.x, transform.position.y, center.z);
    }
}
