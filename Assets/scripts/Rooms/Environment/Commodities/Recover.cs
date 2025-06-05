using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : ShopObj
{
    protected override void Buy()
    {
        base.Buy();
        float current = Player.instance.health;
        float max = Player.instance.healthm;
        Player.instance.health = current < max * 0.5f ?
            current + max * 0.5f : max;
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    private void Start()
    {
        itemID = "Recover";
        itemName = "Recover";
        price = 1;
        maxStock = 1;
        description = "»Ö¸´Ò»°ëµÄÀíÖÇ";
    }
}
