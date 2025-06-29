using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentCom : ShopObj
{
    public GameObject prefab;
    public static Dictionary<string, bool> unlocks = new Dictionary<string, bool>();
    public static Action UnlockListener;
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }
    static SegmentCom()
    {
        unlocks.Add("�̵����̿�", true);
        unlocks.Add("ͼ������̿�", true);
        unlocks.Add("������԰���̿�", true);
        unlocks.Add("���������̿�", false);
        unlocks.Add("���������̿�", false);
        unlocks.Add("�о������̿�", false);
    }
    private void Start()
    {
        itemID = "Segment";
        itemName = itemName + "���̿�";
        description = "��ȡһ��" + itemName + "���̿�";
        UnlockListener += Unlock;
        if (unlocks[itemName])
        {
            Unlock();
        }
    }

    void Unlock()
    {
        if (unlocks[itemName]) 
        {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        UnlockListener -= Unlock;
        }
    }

    protected override void Buy()
    {
        base.Buy();
        gameManager.instance.GetReplacementInReward(prefab);
    }
}