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
        if (collision.tag == "Player") 
        {
            if(Random.value>Player.instance.hidefactor)
            Player.instance.health-=attack;
        }
    }
}
