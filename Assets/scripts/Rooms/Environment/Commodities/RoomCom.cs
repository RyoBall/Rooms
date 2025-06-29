using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCom : ShopObj
{
    //0是储藏，1是饮料，2是研究
    public GameObject prefab;
    public RoomBase room;
    public Image image;
    public enum RoomType
    {
        storage = 0,
        drink = 1,
        research = 2,
    }
    [SerializeField]private RoomType roomType;
    //升级时点亮方块
    public GameObject[] levelCube;
    private string roomName;
    private int roomlevel;
    private string[] LevelDescription = new string[3];
    private static Action LevelUPListener;
    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        /*if (maxStock == 3)
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
        }*/
    }
    protected void Start()
    {
        itemID = "Rooms";
        switch (roomType)
        {
            case RoomType.storage:
                roomName = "储藏室";
                LevelDescription[0] = "房间中存在1个储物柜，打开后会获得5~20能源（70%概率）或随机的一个模块（30%概率）";
                LevelDescription[1] = "房间中会存在2个储物柜，其中一个打开后会获得5~20能源奖励，另外一个储物柜打开后会得到随机的一个模块";
                LevelDescription[2] = "房间中会存在2个储物柜，其中一个打开后会获得10~30能源奖励，另外一个储物柜打开后会随机锁定一种模块类型，并在该类型模块中抽取三个，玩家进行三选一";
                break;
            case RoomType.drink:
                roomName = "饮料室";
                LevelDescription[0] = "可以选择喝一杯饮料，饮料的效果随机，可能为：\r\n恢复理智值上限的1/3理智度；\r\n降低理智值总上限的五分之一的理智值；\r\n提高20理智度上限，同时恢复20理智度；";
                LevelDescription[1] = "可以选择喝一杯饮料，饮料的效果随机，可能为：\r\n恢复理智值上限的2/3理智度；\r\n提高40理智值上限，不同时恢复理智值；\r\n提高20理智值上限，同时恢复30理智值；";
                LevelDescription[2] = "可以选择喝一杯饮料，饮料的效果随机，可能为：\r\n恢复全部理智度；\r\n提高50理智值上限，不同时恢复理智值；\r\n提高30理智度上限，同时恢复30理智度；；";
                break;
            case RoomType.research:
                roomName = "研究室";
                LevelDescription[0] = "在研究室可以花费能源进行研究；\r\n若失败则玩家不会得到任何物品，若成功则会随机获得一个模块；\r\n在一间研究室有4次研究机会，该4次花费能源依次为5/10/15/20；\r\n初始成功概率为25%，若该次研究未成功，则下次研究的成功概率提高25%；\r\n若该次研究成功则将成功概率重新归为25%";
                LevelDescription[1] = "在研究室可以花费能源进行研究；\r\n若失败则玩家不会得到任何物品，若成功则会随机获得一个模块；\r\n在一间研究室有5次研究机会，该5次花费能源依次为0/5/10/15/20；\r\n初始成功概率为25%，若该次研究未成功，则下次研究的成功概率提高25%；\r\n若该次研究成功则将成功概率重新归为25%";
                LevelDescription[2] = "在研究室可以花费能源进行研究；\r\n若失败则玩家不会得到任何物品，若成功则会随机获得一个模块；\r\n玩家在一间研究室有6次研究机会，该5次花费能源依次为0/0/5/10/15/20；\r\n初始成功概率为25%，若该次研究未成功，则下次研究的成功概率提高25%；\r\n若该次研究成功则将成功概率重新归为25%";
                break;
        }
        if (prefab.GetComponent<RoomBase>().level < 3)
            description = "NextLevel:" + LevelDescription[prefab.GetComponent<RoomBase>().level + 1];
        else
            description = "MaxLevel";
        itemName = roomName;
        LevelUPListener += ChangeDescription;
        room = prefab.GetComponent<RoomBase>();
        //设置成灰色
        //文字
    }

    void ChangeDescription()
    {
        if (prefab.GetComponent<RoomBase>().level < 3)
            description = "NextLevel:" + LevelDescription[prefab.GetComponent<RoomBase>().level + 1];
        else
            description = "MaxLevel";
    }
    protected override void Buy()
    {
        base.Buy();
        LevelUPListener.Invoke();
        if (prefab.GetComponent<RoomBase>().level == -1)
        {
            SegmentCom.UnlockListener.Invoke();
            gameManager.instance.GetReplacementInReward(gameManager.instance.Segments[prefab.GetComponent<RoomBase>().RoomID]);
        }
        prefab.GetComponent<RoomBase>().level++;
        Destroy(gameObject);
    }

    protected override void Update()
    {
        base.Update();
        maxStock = 3 - room.level;
    }
}
