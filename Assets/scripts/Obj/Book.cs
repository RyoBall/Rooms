using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    //0������ɫ��1������ɫ��2������ɫ
    public int color;

    private void Start()
    {
        switch (color)
        {
            case 0:
                gameManager.instance.GetChip(1,1);
                //�ı���ɫ
                break;
            case 1:
                gameManager.instance.GetChip(3, 1);
                break;
            case 2:
                gameManager.instance.GetChip(2, 1);
                break;
            default:
                return;
        }
    }

    private void OnMouseDown()
    {
        //Destroy(gameObject);
        //��ģ��������
        //����ģ��װ�仭��
    }
}
