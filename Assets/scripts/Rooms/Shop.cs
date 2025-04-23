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
        //�Ҿ����̵�Ӧ���ǽ����˲��ܿ�����Ʒ��
        RefreshShop();
        //����currentItems�����Ʒ
    }

    protected override void Start()
    {
        base.Start();
        
    }

    public void RefreshShop()
    {
        currentItems.Clear();

        // ���˿�����Ʒ�����>0�����ޣ�
        var availableItems = allItems.FindAll(item =>
            stockDictionary[item.itemID] > 0 || item.maxStock == 0);

        // �������ѡ��
        Shuffle(availableItems);
        for (int i = 0; i < Mathf.Min(displayNum, availableItems.Count); i++)
        {
            currentItems.Add(availableItems[i]);
        }
    }

    //���˳��
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
