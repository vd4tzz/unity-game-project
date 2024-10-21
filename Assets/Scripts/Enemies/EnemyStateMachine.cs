using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    private EnemyState currentState;
    public  EnemyController enemy;

    private EnemyState patrol;
    private EnemyState detect;
    private EnemyState attack;
    private EnemyState die;
    private EnemyState hit;

    public EnemyState Patrol => patrol;
    public EnemyState Detect => detect;
    public EnemyState Attack => attack;
    public EnemyState Die    => die;
    public EnemyState Hit    => hit;

    public EnemyStateMachine(EnemyController enemy)
    {
        this.enemy = enemy;

        patrol = new PatrolState(this);
        detect = new DetectState(this);
        attack = new AttackState(this);
        die    = new DieState(this);
        hit    = new HitState(this);
    }

    public void ChangeState(EnemyState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        currentState.Execute();
    }
}
