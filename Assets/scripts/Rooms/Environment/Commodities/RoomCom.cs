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

        /*if (maxStock == 3)
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
        }*/
    }

    protected void Start()
    {
        itemID = "Rooms";
        price = 0;
        maxStock = 4;

        //���óɻ�ɫ
        //����
    }

    protected override void Buy()
    {
        base.Buy();
        if (prefab.GetComponent<RoomBase>().level == -1) 
        {
            SegmentCom.UnlockListener.Invoke();
            gameManager.instance.GetReplacementInReward(gameManager.instance.Segments[prefab.GetComponent<RoomBase>().RoomID]);
        }
        prefab.GetComponent<RoomBase>().level++;
        Destroy(gameObject);
    }
}
