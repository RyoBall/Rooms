using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DeleteCom : ShopObj
{
    //���߸���ѡ��ģ�ͣ�Ҳ����Ի��ɰ�����
    public GameObject[] roomPrefabs;
    public RectTransform rt;
    public GameObject[] segmentPrefabs;
    public Image[] segmentImages;
    private UnityEvent<int> ChooseRoom;

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        //��������
        segment.instance.UIEnter();
        //����ѡ�񷿼��б�
        GenerateOptions();
    }
    private void GenerateOptions()
    {      
        int num = 0;
        RectTransform rect = rt;
        ChooseRoom.AddListener(ClearOptionsAndChangeWheel);
        for(int i = 0; i < roomPrefabs.Length; i++)
        {
            GameObject room;
            if (UnlockRommManager.instance.unlockRooms[i])
            {
                //��Ҫ����λ��
                rect.anchoredPosition += new Vector2(0, -num * 20);
                room = Instantiate(roomPrefabs[i],rect);
                room.transform.SetParent(transform,false);
                Button btn = gameObject.AddComponent<Button>();
                btn.onClick.AddListener(() => ChooseRoom?.Invoke(i));
            }
        }
    }
    private void ClearOptionsAndChangeWheel(int i)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        segment.instance.isNewRoom = true;
        segment.instance.GenerateWheel();
    }

    private void Start()
    {
        itemID = "Delete";
        itemName = "emmm";
        price = 1;
        maxStock = 5;
        description = "emmm";
    }
}
