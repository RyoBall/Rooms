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
        unlocks.Add("ÉÌµêÂÖÅÌ¿é", true);
        unlocks.Add("Í¼Êé¹İÂÖÅÌ¿é", true);
        unlocks.Add("Äş¾²»¨Ô°ÂÖÅÌ¿é", true);
        unlocks.Add("ÒûÁÏÊÒÂÖÅÌ¿é", false);
        unlocks.Add("´¢²ØÊÒÂÖÅÌ¿é", false);
        unlocks.Add("ÑĞ¾¿ÊÒÂÖÅÌ¿é", false);
    }
    private void Start()
    {
        itemID = "Segment";
        itemName = itemName + "ÂÖÅÌ¿é";
        description = "»ñÈ¡Ò»¿é" + itemName + "ÂÖÅÌ¿é";
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