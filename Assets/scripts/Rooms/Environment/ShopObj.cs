using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopObj : MonoBehaviour
{
    public string itemID;         // ��Ʒ��ʶ
    public string itemName;       // ��ʾ����
    public int price;             // �۸�
    public int maxStock = 1;      // ����棨0��ʾ���ޣ�
    [TextArea] public string description; // ��Ʒ����

    virtual protected void OnMouseDown()
    {
        //������ʲô�����ж�Ǯ�ǲ��Ǵ��ڼ۸�
        if (Player.instance.energy>=price)
        {
            if(maxStock > 1 && Player.instance.energy >= price)
            {
                maxStock--;
                Player.instance.energy -= price;
            }
        }
    }
}
