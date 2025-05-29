using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : RoomBase
{
    //商品列表
    public List<ShopObj> allItems = new List<ShopObj>();
    //打乱顺序的商品列表
    private List<ShopObj> currentItems = new List<ShopObj>();
    //
    private Dictionary<string, int> stockDictionary = new Dictionary<string, int>();
    public int displayNum = 9;
    protected override void OnMouseDown()
    {
        EnterAction += RefreshShop;
        base.OnMouseDown();
        //我觉得商店应该是进入了才能看见商品？
        //生成currentItems里的商品
    }

    protected override void Start()
    {
        base.Start();
    }

    public void RefreshShop()
    {
        currentItems.Clear();
        // 初始化库存字典
        foreach (ShopObj item in allItems)
        {
            if (item.maxStock == 0)
            {
                stockDictionary[item.itemID] = -1; // 无限库存
            }
            else if (item.maxStock > 1)
            {
                {
                    stockDictionary[item.itemID] = item.maxStock; // 有限库存
                }

                /*if (item.CompareTag("Chip"))
                {
                    item.GetComponent<ChipCom>().RandomChip();
                }*///chipcom本身random过了
            }
        }
        
        // 过滤可用商品（库存>0或无限）1是不卖的
        /*var availableItems = allItems.FindAll(item =>
            stockDictionary[item.itemID] > 1 || item.maxStock == 0);

        // 随机排序并选择
        Shuffle(availableItems);
        for (int i = 0; i < Mathf.Min(displayNum, availableItems.Count); i++)
        {
            currentItems.Add(availableItems[i]);
        }*/

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
