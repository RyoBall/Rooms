using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : RoomBase
{
    //商品列表
    public List<ShopObj> allItems = new List<ShopObj>();
    public int displayNum = 9;
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        //我觉得商店应该是进入了才能看见商品？
        //生成currentItems里的商品
    }

    protected override void Start()
    {
        base.Start();
    }


    //随机顺序
    private void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

}
