using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponChipBase : ChipBase//��������ֵ��оƬ����
{
    public GameObject ins;//���ɵ�����
    public WeaponBase insScript;//�����Ľű�
    public GameObject prefab;//����Ԥ����
    public float attackfactor;
    public float range;
    public float cdm;
    public float repelforce;
    public override void entereffect(GameObject BackGround)
    {
        base.entereffect(BackGround);
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
        }//�����Ĺ���ռ�ȣ����٣����з�Χ����оƬ����
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

