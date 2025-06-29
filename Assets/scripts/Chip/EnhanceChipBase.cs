using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnhanceChipBase : ChipBase
{
    public LayerMask ChipLayer;
    public List<ChipBase> ChipsAround;
    private int inchipscount;
    public override void Start()
    {
        base.Start();
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        /*if (getin && inchipscount != GetinChips.instance.chips.Count)
        {
            checAround();
        }*/
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
    }
    public override void entereffect(GameObject BackGround)
    {
        base.entereffect(BackGround);
        //checAround();
    }
    public override void exiteffect()
    {
        base.exiteffect();
    }
    public virtual void chipexiteffect(ChipBase chip)
    {
        ChipsAround.Remove(chip);
    }
    public virtual void chipentereffect(ChipBase chip)
    {
        ChipsAround.Add(chip);
    }
}
