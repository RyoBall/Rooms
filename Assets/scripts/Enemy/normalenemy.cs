using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalenemy : EnemyBase
{
    public override void Dead()
    {
        base.Dead();
    }

    public override void move()
    {
        base.move();
    }

    public override void Start()
    {
        base.Start();
    }
    
    public override void Update()
    {
        base.Update();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&icytime<=0)
        {
            if (!Player.instance.attacked&&Random.value > Player.instance.hidefactor)
            {
                Debug.Log("attack");
                Player.instance.ChangeState(new PlayerAttackedState());
                Player.instance.health -= attack;
            }
        }
    }
}
