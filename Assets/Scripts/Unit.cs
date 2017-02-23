using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour 
{
    public enum State
    {
        IDLE,
        MOVE,
        ATTACK,
        DIE,
    }

    // 所有浮点取2位小数并向下取整。
    public class UnitAttr
    {
        int Atk = 3;                // 攻击
        int Spd = 1;                // 速度
        int Hp = 6;                 // 生命
        float Mov = 3;              // 移动力
        float Range = 1;            // 攻击范围
        float Vol = 0.5f;           // 体积
    }

    Unit        _Target;
    UnitAttr    _Attr;
    State       _State;
    Vector3     _TargetPos;
    Vector3     _TargetDir;

    public void OP_SetPos( Vector3 pos )
    {
        transform.position = pos;
    }

    public void OP_MoveTo( Vector3 targetPos )
    {
        _TargetPos = targetPos;
        _TargetDir = ( targetPos - transform.position ).normalized;
        _State = State.MOVE;
    }

    public void OP_MoveForward( Vector3 dir )
    {
        _TargetDir = dir;
    }

    public void OP_Attack( Unit target )
    {
        _Target = target;
        _State = State.ATTACK;
    }

    void Update()
    {
        if( _State == State.MOVE )
        {

        }
        else if( _State == State.ATTACK )
        {

        }
    }
}
