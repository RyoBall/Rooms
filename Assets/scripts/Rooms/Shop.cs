using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : RoomBase
{
    public List<ShopObj> allItems = new List<ShopObj>();
    private List<ShopObj> currentItems = new List<ShopObj>();
    private Dictionary<string, int> stockDictionary = new Dictionary<string, int>();
    public int displayNum = 5;
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        //我觉得商店应该是进入了才能看见商品？
        RefreshShop();
        //生成currentItems里的商品
    }

    protected override void Start()
    {
        base.Start();
        
    }

    public void RefreshShop()
    {
        currentItems.Clear();

        // 过滤可用商品（库存>0或无限）
        var availableItems = allItems.FindAll(item =>
            stockDictionary[item.itemID] > 0 || item.maxStock == 0);

        // 随机排序并选择
        Shuffle(availableItems);
        for (int i = 0; i < Mathf.Min(displayNum, availableItems.Count); i++)
        {
            currentItems.Add(availableItems[i]);
        }
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
