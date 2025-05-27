using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipCom : ShopObj
{
    public enum ChipType
    {
        BulletEffect = 1,
        Global = 2,
        BulletEnhace = 3,
        Weapon = 4
    }
    private ChipType chipType;
    private int order;

    //��Ҫ�ĸ�
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        //չʾ
        gameManager.instance.GetChipButton((int)chipType, order, 2);
        ChoosePanel.instance.Enter();
    }

    private void Start()
    {
        RandomChip();
    }

    public void RandomChip()
    {   
        insSprite();
        ChipBase chipBase = gameManager.instance.chipsDic[(int)chipType][order].GetComponent<ChipBase>();
        itemID = "Chip";
        itemName = chipBase.chipname;
        price = 1;
        maxStock = 0;
        description = chipBase.description;
    }
    void insSprite() //��ȡоƬ��ƷͼƬ
    {
        GameObject inschip = Instantiate(gameManager.instance.chipsDic[(int)chipType][order], transform.position, Quaternion.identity);
        Destroy(inschip.GetComponent<ChipBase>());
        if (chipType == ChipType.BulletEffect)
        {
            Destroy(inschip.GetComponentInChildren<occupy>());
        }
    }
}
