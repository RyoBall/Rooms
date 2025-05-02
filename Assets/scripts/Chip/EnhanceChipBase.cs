using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnhanceChipBase : ChipBase
{
    public LayerMask ChipLayer;
    public List<RaycastHit2D> hits;
    public List<ChipBase> ChipsAround;
    public int inchipscount;
    public List<Vector2> aroundposition;
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
    public override void entereffect(RaycastResult result)
    {
        base.entereffect(result);
        //checAround();
    }
    public override void exiteffect()
    {
        base.exiteffect();
        for (int i = 0; i < ChipsAround.Count; i++)
        {
            chipexiteffect(ChipsAround[i]);
        }
    }
    public virtual void chipexiteffect(ChipBase chip)
    {
        ChipsAround.Remove(chip);
    }
    public virtual void chipentereffect(ChipBase chip)
    {
        ChipsAround.Add(chip);
    }
    public virtual void checAround()
    {
        inchipscount = GetinChips.instance.chips.Count;
        for (int i = 0; i < GetinChips.instance.chips.Count; i++)
        {
            ChipBase a = GetinChips.instance.chips[i];
            for (int j = 0; j < aroundposition.Count; j++)
            {
                if (a.position.x - position.x == aroundposition[j].x && a.position.y - position.y == aroundposition[j].y)
                {
                    if (!ChipsAround.Contains(a))
                    {
                        chipentereffect(a);
                    }
                }
            }
        }
        for (int i = 0; i < ChipsAround.Count; i++)
        {
            if (!ChipsAround[i].getin)
                chipexiteffect(ChipsAround[i]);
        }
    }
}
