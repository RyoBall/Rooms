using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class bombEnhance : bulletEnhanceBase
{
    public override void checAround()
    {
        base.checAround();
    }

    public override void chipentereffect(ChipBase chip)
    {
        base.chipentereffect(chip);
        if (chip.gameObject.GetComponent<WeaponChipBase>() != null)
        {
            chip.gameObject.GetComponent<WeaponChipBase>().insScript.bombattacklevel++;
        }
    }

    public override void chipexiteffect(ChipBase chip)
    {
        base.chipexiteffect(chip);
        if (chip.gameObject.GetComponent<WeaponChipBase>() != null)
        {
            chip.gameObject.GetComponent<WeaponChipBase>().insScript.bombattacklevel--;
        }
    }

    public override void entereffect(RaycastResult result)
    {
        base.entereffect(result);
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
