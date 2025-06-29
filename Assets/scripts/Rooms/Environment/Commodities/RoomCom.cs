using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCom : ShopObj
{
    //0�Ǵ��أ�1�����ϣ�2���о�
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
    //����ʱ��������
    public GameObject[] levelCube;
    private string roomName;
    private int roomlevel;
    private string[] LevelDescription = new string[3];
    private static Action LevelUPListener;
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
        switch (roomType)
        {
            case RoomType.storage:
                roomName = "������";
                LevelDescription[0] = "�����д���1������񣬴򿪺����5~20��Դ��70%���ʣ��������һ��ģ�飨30%���ʣ�";
                LevelDescription[1] = "�����л����2�����������һ���򿪺����5~20��Դ����������һ�������򿪺��õ������һ��ģ��";
                LevelDescription[2] = "�����л����2�����������һ���򿪺����10~30��Դ����������һ�������򿪺���������һ��ģ�����ͣ����ڸ�����ģ���г�ȡ��������ҽ�����ѡһ";
                break;
            case RoomType.drink:
                roomName = "������";
                LevelDescription[0] = "����ѡ���һ�����ϣ����ϵ�Ч�����������Ϊ��\r\n�ָ�����ֵ���޵�1/3���Ƕȣ�\r\n��������ֵ�����޵����֮һ������ֵ��\r\n���20���Ƕ����ޣ�ͬʱ�ָ�20���Ƕȣ�";
                LevelDescription[1] = "����ѡ���һ�����ϣ����ϵ�Ч�����������Ϊ��\r\n�ָ�����ֵ���޵�2/3���Ƕȣ�\r\n���40����ֵ���ޣ���ͬʱ�ָ�����ֵ��\r\n���20����ֵ���ޣ�ͬʱ�ָ�30����ֵ��";
                LevelDescription[2] = "����ѡ���һ�����ϣ����ϵ�Ч�����������Ϊ��\r\n�ָ�ȫ�����Ƕȣ�\r\n���50����ֵ���ޣ���ͬʱ�ָ�����ֵ��\r\n���30���Ƕ����ޣ�ͬʱ�ָ�30���Ƕȣ���";
                break;
            case RoomType.research:
                roomName = "�о���";
                LevelDescription[0] = "���о��ҿ��Ի�����Դ�����о���\r\n��ʧ������Ҳ���õ��κ���Ʒ�����ɹ����������һ��ģ�飻\r\n��һ���о�����4���о����ᣬ��4�λ�����Դ����Ϊ5/10/15/20��\r\n��ʼ�ɹ�����Ϊ25%�����ô��о�δ�ɹ������´��о��ĳɹ��������25%��\r\n���ô��о��ɹ��򽫳ɹ��������¹�Ϊ25%";
                LevelDescription[1] = "���о��ҿ��Ի�����Դ�����о���\r\n��ʧ������Ҳ���õ��κ���Ʒ�����ɹ����������һ��ģ�飻\r\n��һ���о�����5���о����ᣬ��5�λ�����Դ����Ϊ0/5/10/15/20��\r\n��ʼ�ɹ�����Ϊ25%�����ô��о�δ�ɹ������´��о��ĳɹ��������25%��\r\n���ô��о��ɹ��򽫳ɹ��������¹�Ϊ25%";
                LevelDescription[2] = "���о��ҿ��Ի�����Դ�����о���\r\n��ʧ������Ҳ���õ��κ���Ʒ�����ɹ����������һ��ģ�飻\r\n�����һ���о�����6���о����ᣬ��5�λ�����Դ����Ϊ0/0/5/10/15/20��\r\n��ʼ�ɹ�����Ϊ25%�����ô��о�δ�ɹ������´��о��ĳɹ��������25%��\r\n���ô��о��ɹ��򽫳ɹ��������¹�Ϊ25%";
                break;
        }
        if (prefab.GetComponent<RoomBase>().level < 3)
            description = "NextLevel:" + LevelDescription[prefab.GetComponent<RoomBase>().level + 1];
        else
            description = "MaxLevel";
        itemName = roomName;
        LevelUPListener += ChangeDescription;
        room = prefab.GetComponent<RoomBase>();
        //���óɻ�ɫ
        //����
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
