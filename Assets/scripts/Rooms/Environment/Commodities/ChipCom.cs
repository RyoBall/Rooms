using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChipCom : ShopObj
{
    public enum ChipType
    {
        random = 0,
        BulletEffect = 1,
        Global = 2,
        BulletEnhace = 3,
    }
    private ChipType chipType;
    private int order;

    //需要四个
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        //展示
    }

    private void Start()
    {
        RandomChip();
    }

    public void RandomChip()
    {
        if (chipType == ChipType.random)
            chipType = (ChipType)Random.Range(1, 4);
        order = Random.Range(0, gameManager.instance.chipsDic[(int)chipType].Count);
        insSprite();
        ChipBase chipBase = gameManager.instance.chipsDic[(int)chipType][order].GetComponent<ChipBase>();
        itemID = "Chip";
        itemName = chipBase.chipname;
        price = 1;
        maxStock = 0;
        description = chipBase.description;
    }
    void insSprite() //获取芯片商品图片
    {
        GameObject inschip = Instantiate(gameManager.instance.chipsDic[(int)chipType][order], transform.position, Quaternion.identity);
        Destroy(inschip.GetComponent<ChipBase>());
        if (chipType == ChipType.BulletEffect)
        {
            Destroy(inschip.GetComponentInChildren<occupy>());
        }
    }

    protected override void Buy()
    {
        base.Buy();
        gameManager.instance.GetChipButton((int)chipType, order, 2);
        ChoosePanel.instance.Enter();
    }
}
