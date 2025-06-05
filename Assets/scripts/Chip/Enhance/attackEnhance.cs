using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class attackEnhance : EnhanceChipBase
{
    // Start is called before the first frame update

    public override void chipentereffect(ChipBase chip)
    {
        base.chipentereffect(chip);
        if (chip.gameObject.GetComponent<WeaponChipBase>() != null) 
        {
            chip.gameObject.GetComponent<WeaponChipBase>().attackfactor = chip.gameObject.GetComponent<WeaponChipBase>().attackfactor*1.25f;
        }
    }

    public override void chipexiteffect(ChipBase chip)
    {
        base.chipexiteffect(chip);
        if (chip.gameObject.GetComponent<WeaponChipBase>() != null)
        {
            chip.gameObject.GetComponent<WeaponChipBase>().attackfactor = chip.gameObject.GetComponent<WeaponChipBase>().attackfactor/1.25f;
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
