using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class icyEnhance : bulletEnhanceBase
{

    public override void chipentereffect(ChipBase chip)
    {
        base.chipentereffect(chip);
        if (chip.gameObject.GetComponent<WeaponChipBase>() != null)
        {
            chip.gameObject.GetComponent<WeaponChipBase>().insScript.icyattacklevel++;
        }
    }

    public override void chipexiteffect(ChipBase chip)
    {
        base.chipexiteffect(chip);
        if (chip.gameObject.GetComponent<WeaponChipBase>() != null)
        {
            chip.gameObject.GetComponent<WeaponChipBase>().insScript.icyattacklevel--;
        }
    }

    public override void entereffect(GameObject BackGround)
    {
        base.entereffect(BackGround);
    }

    public override void exiteffect()
    {
        base.exiteffect();
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
