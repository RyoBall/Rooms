using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class pack : ChipBase
{
    public GameObject ins;//���ɵ�����
    public GameObject prefab;//����Ԥ����
    public override void entereffect(RaycastResult result)
    {
        base.entereffect(result);
        if (ins == null)
            ins = Instantiate(prefab, Player.instance.transform.position, Quaternion.identity, Player.instance.transform);
    }

    public override void exiteffect()
    {
        base.exiteffect();
        Destroy(ins);
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
