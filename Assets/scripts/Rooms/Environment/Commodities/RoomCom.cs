using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCom : ShopObj
{
    //0�Ǵ��أ�1�����ϣ�2���о�
    public GameObject prefab;
    public Image image;
    public enum RoomType
    {
        storage = 0,
        drink = 1,
        research = 2,
    }
    private RoomType roomType;
    //����ʱ��������
    public GameObject[] levelCube;
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        prefab.GetComponent<RoomBase>().level++;
        if (maxStock == 3)
        {   //��������
            segment.instance.UIEnter();
            //���滻


            //��Ϊ������ɫ
            //����
        }
        else if (maxStock == 2)
        {
            //��һ����������
            //����
        }
        else if (maxStock == 1)
        {
            //���ǿ������˰ɣ�

            //�ڶ�����������
        }
    }

    protected void Start()
    {
        itemID = "Rooms";
        itemName = "Rooms";
        price = 0;
        maxStock = 4;

        //���óɻ�ɫ
        //����
    }
}
