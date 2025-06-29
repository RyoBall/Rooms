using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    public int level;
    public int type;
    private void Awake()
    {
        if (type == 2 && level == 0)
            Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        //��һ������
        if (type == 1)
        {
            switch (level)
            {
                case 0:
                    if (Random.value < .7f)
                    {
                        Player.instance.energy += Random.Range(5, 21);
                    }
                    else
                    {
                        int i = Random.Range(1, 4);
                        gameManager.instance.GetChip(i, Random.Range(0, gameManager.instance.chipsDic[i].Count));
                    }
                    break;
                case 1:
                    Player.instance.energy += Random.Range(5, 21);
                    break;
                case 2:
                    Player.instance.energy += Random.Range(10, 31);
                    break;
                default:
                    break;
            }
        }
        else if (type == 2)
        {
            int i = Random.Range(1, 4);
            switch (level)
            {
                case 1:
                    gameManager.instance.GetChip(i, Random.Range(0, gameManager.instance.chipsDic[i].Count));
                    break;
                case 2:
                    for (int j = 0; j < 3; j++)
                    {
                        gameManager.instance.GetChipButton(i, Random.Range(0, gameManager.instance.chipsDic[i].Count), j);
                    }
                    ChoosePanel.instance.Enter();
                    break;
                default:
                    break;
            }
        }
        OnMouseExit();
        Destroy(gameObject);
    }
    private void OnMouseEnter()
    {
        switch (level)
        {
            case 1:
                NameTex.instance.TMP_Text.text = "�ƾɵĹ���";
                DescriptionTex.instance.TMP_Text.text = "�򿪴���ʻ���������飬С����������һ��ģ��";
                break;
            case 2:
                NameTex.instance.TMP_Text.text = "��ҵĹ���";
                if (type == 1)
                    DescriptionTex.instance.TMP_Text.text = "�򿪻��һЩ����";
                else
                    DescriptionTex.instance.TMP_Text.text = "�򿪻��һ�����ģ��";
                break;
            case 3:
                NameTex.instance.TMP_Text.text = "���µĹ���";
                if (type == 1)
                    DescriptionTex.instance.TMP_Text.text = "�򿪻�ô�������";
                else
                    DescriptionTex.instance.TMP_Text.text = "�򿪻���������ģ����ѡ��һ����ȡ";
                break;
        }
    }
    private void OnMouseExit()
    {
        NameTex.instance.TMP_Text.text = null;
        DescriptionTex.instance.TMP_Text.text = null;
    }
}

