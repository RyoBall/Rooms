    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpeedGlobalChip : GlobalChipBase
{
    public override void entereffect(RaycastResult result)
    {
        base.entereffect(result);
        Player.instance.speed = Player.instance.speed * 1.2f;
    }

    public override void exiteffect()
    {
        base.exiteffect();
        Player.instance.speed = Player.instance.speed / 1.2f;
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
