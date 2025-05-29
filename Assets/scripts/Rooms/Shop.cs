using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : RoomBase
{
    //��Ʒ�б�
    public List<ShopObj> allItems = new List<ShopObj>();
    //����˳�����Ʒ�б�
    private List<ShopObj> currentItems = new List<ShopObj>();
    //
    private Dictionary<string, int> stockDictionary = new Dictionary<string, int>();
    public int displayNum = 9;
    protected override void OnMouseDown()
    {
        EnterAction += RefreshShop;
        base.OnMouseDown();
        //�Ҿ����̵�Ӧ���ǽ����˲��ܿ�����Ʒ��
        //����currentItems�����Ʒ
    }

    protected override void Start()
    {
        base.Start();
    }

    public void RefreshShop()
    {
        currentItems.Clear();
        // ��ʼ������ֵ�
        foreach (ShopObj item in allItems)
        {
            if (item.maxStock == 0)
            {
                stockDictionary[item.itemID] = -1; // ���޿��
            }
            else if (item.maxStock > 1)
            {
                {
                    stockDictionary[item.itemID] = item.maxStock; // ���޿��
                }

                /*if (item.CompareTag("Chip"))
                {
                    item.GetComponent<ChipCom>().RandomChip();
                }*///chipcom����random����
            }
        }
        
        // ���˿�����Ʒ�����>0�����ޣ�1�ǲ�����
        /*var availableItems = allItems.FindAll(item =>
            stockDictionary[item.itemID] > 1 || item.maxStock == 0);

        // �������ѡ��
        Shuffle(availableItems);
        for (int i = 0; i < Mathf.Min(displayNum, availableItems.Count); i++)
        {
            currentItems.Add(availableItems[i]);
        }*/

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
