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

    //模块的gameobject?有吗（
    public GameObject[] chips;
    //需要四个
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        //展示
        gameManager.instance.GetChip((int)chipType,order);
    }

    private void Start()
    {
        RandomChip();
    }

    public void RandomChip()
    {
        //各个数目待定
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
        //chips[order].SetActive(true);启动模块
        itemID = "Chip";
        itemName = chipBase.chipname;
        price = 1;
        maxStock = 0;
        description = chipBase.description;

    }
}
