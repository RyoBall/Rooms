using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCom : ShopObj
{
    //0是储藏，1是饮料，2是研究
    public GameObject prefab;
    public Image image;
    public enum RoomType
    {
        storage = 0,
        drink = 1,
        research = 2,
    }
    private RoomType roomType;
    //升级时点亮方块
    public GameObject[] levelCube;
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        prefab.GetComponent<RoomBase>().level++;
        if (maxStock == 3)
        {   //唤起轮盘
            segment.instance.UIEnter();
            //待替换


            //变为正常颜色
            //文字
        }
        else if (maxStock == 2)
        {
            //第一个方块亮起
            //文字
        }
        else if (maxStock == 1)
        {
            //但是看不到了吧？

            //第二个方块亮起
        }
    }

    protected void Start()
    {
        itemID = "Rooms";
        itemName = "Rooms";
        price = 0;
        maxStock = 4;

        //设置成灰色
        //文字
    }
}
