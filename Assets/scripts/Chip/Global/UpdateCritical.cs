using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpdateCritical : UpgradeBase
{
    public override void entereffect(RaycastResult result)
    {
        base.entereffect(result);
        Player.instance.criticalfactor += currentfactor;
    }

    public override void exiteffect()
    {
        base.exiteffect();
        Player.instance.criticalfactor -= currentfactor;
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

    public override void Start()
    {
        base.Start();
    }

    public override void Upgrade()
    {
        base.Upgrade();
        Player.instance.criticalfactor -= currentfactor;
        currentfactor += growfactor;
        Player.instance.criticalfactor += currentfactor;
    }
}
