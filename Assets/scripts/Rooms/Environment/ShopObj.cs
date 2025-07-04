using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopObj : MonoBehaviour
{
    public string itemID;         // 商品标识
    public string itemName;       // 显示名称
    public int price;             // 价格
    public int maxStock = 1;      // 最大库存（0表示无限）
    [TextArea] public string description; // 商品描述
    virtual protected void OnMouseDown()
    {
        //货币是什么？（判断钱是不是大于价格
        if (Player.instance.energy >= price)
        {
            if ((maxStock > 1 ||maxStock<=0)&& Player.instance.energy >= price)
            {
                Buy();
                OnMouseExit();
                maxStock--;
                Player.instance.energy -= price;
            }
        }
    }
    virtual protected void Buy()
    {
        ;
    }
    protected virtual void Update()
    {
        if(maxStock==1)
        Destroy(gameObject);
    }
    protected virtual void OnMouseEnter()
    {
        NameTex.instance.TMP_Text.text = itemName;
        DescriptionTex.instance.TMP_Text.text = "消耗能源:" + price.ToString() + "\r\n" + description;
    }
    protected virtual void OnMouseExit()
    {
        NameTex.instance.TMP_Text.text = null;
        DescriptionTex.instance.TMP_Text.text = null;
    }
}
