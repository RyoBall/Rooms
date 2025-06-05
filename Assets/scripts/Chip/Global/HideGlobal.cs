using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HideGlobal : GlobalChipBase
{
    public override void entereffect(GameObject BackGround)
    {
        base.entereffect(BackGround);
        Player.instance.hidefactor+=8;
    }

    public override void exiteffect()
    {
        base.exiteffect();
        Player.instance.hidefactor-=8;
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
}