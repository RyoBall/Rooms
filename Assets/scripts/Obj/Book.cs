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
        switch (color)
        {
            case Color.purple:
                for(int i = 0; i < 3; i++) 
                {
                    gameManager.instance.GetChipButton(1, Random.Range(0, gameManager.instance.chipsDic[1].Count),i);
                }
                //改变颜色
                break;
            case Color.green:
                for (int i = 0; i < 3; i++)
                {
                    gameManager.instance.GetChipButton(1, Random.Range(0, gameManager.instance.chipsDic[3].Count), i);
                }
                //
                break;
            case Color.blue:
                for (int i = 0; i < 3; i++)
                {
                    gameManager.instance.GetChipButton(1, Random.Range(0, gameManager.instance.chipsDic[2].Count), i);
                }
                //
                break;
            default:
                return;
        }
    }

    private void OnMouseDown()
    {
        //Destroy(gameObject);
        //把模块给予玩家
        //唤出模块装配画面
    }
}
