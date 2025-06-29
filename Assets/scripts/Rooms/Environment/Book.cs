using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    //0代表紫色，1代表绿色，2代表蓝色
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
                //改变颜色
                break;
            case Color.green:
                for (int i = 0; i < 3; i++)
                {
                    gameManager.instance.GetChipButton(3, Random.Range(0, gameManager.instance.chipsDic[3].Count), i);
                }
                    ChoosePanel.instance.Enter();
                //
                break;
            case Color.blue:
                for (int i = 0; i < 3; i++)
                {
                    gameManager.instance.GetChipButton(2, Random.Range(0, gameManager.instance.chipsDic[2].Count), i);
                }
                    ChoosePanel.instance.Enter();
                //
                break;
            default:
                return;
        }
        NameTex.instance.TMP_Text.text = null;
        DescriptionTex.instance.TMP_Text.text = null;
        GetComponentInParent<Lib>().DestroyBook();
        //GetComponentInParent<Lib>().DestroyBook();
        //把模块给予玩家
        //唤出模块装配画面
    }
    private void OnMouseEnter()
    {
        switch (color) 
        {
            case Color.purple:
                NameTex.instance.TMP_Text.text = "紫色图书";
                DescriptionTex.instance.TMP_Text.text = "随机获得一个子弹效果(紫色)模块";
                break;
            case Color.green:
                NameTex.instance.TMP_Text.text = "绿色图书";
                DescriptionTex.instance.TMP_Text.text = "随机获得一个子弹增益(绿色)模块";
                break;     
            case Color.blue:
                NameTex.instance.TMP_Text.text = "蓝色图书";
                DescriptionTex.instance.TMP_Text.text = "随机获得一个全局(蓝色)模块";
                break;
        }
    }
    private void OnMouseExit()
    {
        NameTex.instance.TMP_Text.text =null;
        DescriptionTex.instance.TMP_Text.text =null;
    }
}
