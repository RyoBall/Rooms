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
        //第一个柜子
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
                NameTex.instance.TMP_Text.text = "破旧的柜子";
                DescriptionTex.instance.TMP_Text.text = "打开大概率获得少量经验，小概率随机获得一个模块";
                break;
            case 2:
                NameTex.instance.TMP_Text.text = "落灰的柜子";
                if (type == 1)
                    DescriptionTex.instance.TMP_Text.text = "打开获得一些经验";
                else
                    DescriptionTex.instance.TMP_Text.text = "打开获得一个随机模块";
                break;
            case 3:
                NameTex.instance.TMP_Text.text = "精致的柜子";
                if (type == 1)
                    DescriptionTex.instance.TMP_Text.text = "打开获得大量经验";
                else
                    DescriptionTex.instance.TMP_Text.text = "打开会从三个随机模块中选择一个获取";
                break;
        }
    }
    private void OnMouseExit()
    {
        NameTex.instance.TMP_Text.text = null;
        DescriptionTex.instance.TMP_Text.text = null;
    }
}

