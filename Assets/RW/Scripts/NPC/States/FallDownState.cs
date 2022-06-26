using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPCStateMachine
{
    public class FallDownState : NPCState<string>
    {
        const string name = "Fall Down";

        NPC npc;

        Transform rhino;
        Vector3 fallLocation;
        float elap1, elap2;
        bool getUpAlready;

        public FallDownState(NPCSM<string> _sm, NPC _npc) : base(_sm, name)
        {
            npc = _npc;
        }

        public override void Enter()
        {
            rhino = GameObject.Find("Rhino").transform;

            npc.anim.SetFloat("Speed", 0);
            npc.anim.SetTrigger(Animator.StringToHash("FallDown"));

            npc.transform.LookAt(new Vector3(rhino.position.x, npc.transform.position.y, rhino.position.z));
            fallLocation = npc.transform.position - (npc.transform.forward * 3);

            elap1 = elap2 = 0f;
            getUpAlready = false;
        }

        public override void Execute()
        {
            if (elap1 > 3.8f && !getUpAlready)
            {
                npc.anim.SetTrigger(Animator.StringToHash("GetUp"));
                getUpAlready = true;
            }
            else elap1 += Time.deltaTime;

            if (elap2 > 5.4f)
            {
                sm.SetState("Standstill");
            }
            else elap2 += Time.deltaTime;

            npc.transform.position =
                Vector3.MoveTowards(npc.transform.position, fallLocation, 8 * Time.deltaTime);
        }

        public override void Exit()
        {
            npc.FallDown = false;
        }
    }
}