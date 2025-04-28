using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponChipBase : ChipBase//武器的数值由芯片决定
{
    public GameObject ins;//生成的武器
    public WeaponBase insScript;//武器的脚本
    public GameObject prefab;//武器预制体
    public float attackfactor;
    public float range;
    public float cdm;
    public override void entereffect(RaycastResult result)
    {
        base.entereffect(result);
        if (ins == null) 
        {
            ins = Instantiate(prefab, Player.instance.transform.position, Quaternion.identity, Player.instance.transform);
            insScript = ins.GetComponent<WeaponBase>();
        }
    }

    public override void exiteffect()
    {
        base.exiteffect();
        Destroy(ins);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (ins != null) 
        {
            insScript.attack = attackfactor;
            insScript.cdm = cdm;
            insScript.range=range;
        }
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

