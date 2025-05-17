using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : ShopObj
{
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        float current = Player.instance.currentSanity;
        float max = Player.instance.maxSanity;
        Player.instance.currentSanity = current < max* 0.5f ?
            current + max * 0.5f : max;
    }

    private void Start()
    {
        itemID = "Recover";
        itemName = "Recover";
        price = 1;
        maxStock = 0;
        description = "emmmm";
    }
}
