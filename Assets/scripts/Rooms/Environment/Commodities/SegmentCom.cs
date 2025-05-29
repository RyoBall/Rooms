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
        unlocks.Add("Shop", true);
        unlocks.Add("Lib", true);
        unlocks.Add("Garden", true);
        unlocks.Add("Drink", false);
        unlocks.Add("Storage", false);
        unlocks.Add("Research", false);
    }
    private void Start()
    {
        itemID = "Segment";
        price = 1;
        maxStock = 1;
        description = "»ñÈ¡Ò»¿é" + itemName + "ÂÖÅÌ¿é";
        if (unlocks[itemName])
        {
            Unlock();
        }
        else 
        {
            UnlockListener += Unlock;
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