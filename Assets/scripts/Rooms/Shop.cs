using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : RoomBase
{
    //��Ʒ�б�
    public List<ShopObj> allItems = new List<ShopObj>();
    public int displayNum = 9;
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        //�Ҿ����̵�Ӧ���ǽ����˲��ܿ�����Ʒ��
        //����currentItems�����Ʒ
    }

    protected override void Start()
    {
        base.Start();
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
