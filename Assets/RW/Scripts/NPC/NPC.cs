using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPCStateMachine;
using Pathfinding;


public class NPC : MonoBehaviour
{
    public float Speed = 1f;
    public float ChaseSpeed = 2.5f;
    public float RotationSpeed = 250f;
    public float Health = 3f;

    [HideInInspector]
    public bool FallDown = false;
    [HideInInspector]
    public bool GetHit = false;

    NPCSM<string> sm;
    NPCState<string> standStill, wander, chase, fallDown, getHit, attack;

    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public Pathfinder pf;
    [HideInInspector]
    public NodeManager nm;
    [HideInInspector]
    public Transform player;

    void Start()
    {
        anim = GetComponent<Animator>();
        nm = GameObject.Find("Grid").GetComponent<NodeManager>();
        pf = new Pathfinder(nm);
        player = GameObject.Find("Character").transform;

        sm = new NPCSM<string>();

        standStill = new StandStillState(sm, this);
        wander = new WanderState(sm, this);
        chase = new ChaseState(sm, this);
        fallDown = new FallDownState(sm, this);
        getHit = new GetHitState(sm, this);
        attack = new AttackState(sm, this);

        sm.AddState(standStill);
        sm.AddState(wander);
        sm.AddState(chase);
        sm.AddState(fallDown);
        sm.AddState(getHit);
        sm.AddState(attack);

        sm.SetState("Standstill");
    }

    private void Update()
    {
        sm.Update();
    }

    public bool IsPlayerCrouching()
    {
        return player.gameObject.GetComponent<RayWenderlich.Unity.StatePatternInUnity.Character>().Crouching;
    }
}
