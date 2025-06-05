using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateHealth :UpgradeBase
{
    public override void entereffect(GameObject BackGround)
    {
        base.entereffect(BackGround);
        Player.instance.healthm += currentfactor;
        Player.instance.health += currentfactor;
    }

    public override void exiteffect()
    {
        base.exiteffect();
        Player.instance.healthm -= currentfactor;
        Player.instance.health -= currentfactor;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
    }

    public override void Upgrade()
    {
        base.Upgrade();
        Player.instance.healthm -= currentfactor;
        Player.instance.health -= currentfactor;
        currentfactor += growfactor;
        Player.instance.healthm += currentfactor;
        Player.instance.health += currentfactor;
    }


}
