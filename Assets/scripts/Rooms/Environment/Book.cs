using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    //0������ɫ��1������ɫ��2������ɫ
    public enum Color { purple,green,blue};
    public Color color;

    private void Start()
    {
        
    }

    private void OnMouseDown()
    {
        switch (color)
        {
            case Color.purple:
                for (int i = 0; i < 3; i++)
                {
                    gameManager.instance.GetChipButton(1, Random.Range(0, gameManager.instance.chipsDic[1].Count), i);
                }
                    ChoosePanel.instance.Enter();
                //�ı���ɫ
                break;
            case Color.green:
                for (int i = 0; i < 3; i++)
                {
                    gameManager.instance.GetChipButton(1, Random.Range(0, gameManager.instance.chipsDic[3].Count), i);
                }
                    ChoosePanel.instance.Enter();
                //
                break;
            case Color.blue:
                for (int i = 0; i < 3; i++)
                {
                    gameManager.instance.GetChipButton(1, Random.Range(0, gameManager.instance.chipsDic[2].Count), i);
                }
                    ChoosePanel.instance.Enter();
                //
                break;
            default:
                return;
        }
        Destroy(gameObject);
        //GetComponentInParent<Lib>().DestroyBook();
        //��ģ��������
        //����ģ��װ�仭��
    }
}
