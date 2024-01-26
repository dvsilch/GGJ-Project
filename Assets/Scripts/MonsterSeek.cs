using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSeek : Action
{
    private Monster monster;

    public SharedGameObject target;

    public SharedVector3 targetPosition;


    public override void OnStart()
    {
        Debug.Log("MonsterSeek.OnStart");
        monster = GetComponent<Monster>();
    }

    public override TaskStatus OnUpdate()
    {
        if (target.Value != null)
        {
            targetPosition.Value = target.Value.transform.position;
            monster.player = target.Value;
            monster.enabled = true;
        }
        if (monster.catched)
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }
}
