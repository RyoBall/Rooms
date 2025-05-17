using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipCom : ShopObj
{
    public enum ChipType
    {
        weapon = 1,
        global = 2,
        buff = 3,
        special = 4
    }
    private ChipType chipType;
    private int order;

    //ģ���gameobject?����
    public GameObject[] chips;
    //��Ҫ�ĸ�
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        //չʾ
        gameManager.instance.GetChip((int)chipType,order);
    }

    private void Start()
    {
        RandomChip();
    }

    public void RandomChip()
    {
        //������Ŀ����
        switch ((int)chipType)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                return;
        }

        ChipBase chipBase = chips[0].GetComponent<ChipBase>();
        //chips[order].SetActive(true);����ģ��
        itemID = "Chip";
        itemName = chipBase.chipname;
        price = 1;
        maxStock = 0;
        description = chipBase.description;

    }
}
