using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastShooter : shooter
{
    public override void Attack()
    {
        base.Attack();
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }
        if (cd <= 0 && enemysin.Count != 0)
        {
            if (heavyattacklevel > 0)
                cd = cdm * (1.4f + heavyattacklevel * .2f);
            else
                cd = cdm;
            DIR();
            shoot();
            doubleattackpoint = doubleattacklevel;
            StartCoroutine(doubleroutine(doubleattacklevel));
        }
    }


    public override void DIR()
    {
        base.DIR();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void shoot()
    {
        base.shoot();
    }

    public override IEnumerator doubleroutine(float doubleattackpoint)
    {
        return base.doubleroutine(doubleattackpoint);
    }
}

