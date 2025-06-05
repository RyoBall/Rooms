using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeBase : GlobalChipBase
{
    public int currentfactor;
    public int growfactor;
    public int maxfactor;
    public override void entereffect(GameObject BackGround)
    {
        base.entereffect(BackGround);
        enemyGeneratorController.instance.ExitAction+=(Upgrade);
    }

    public override void exiteffect()
    {
        base.exiteffect();
        enemyGeneratorController.instance.ExitAction -= (Upgrade);
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
    public virtual void Upgrade() 
    {
        ;
    }
}
