using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    //0代表紫色，1代表绿色，2代表蓝色
    public int color;

    private void Start()
    {
        switch (color)
        {
            case 0:
                gameManager.instance.GetChip(1,1);
                //改变颜色
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
        //把模块给予玩家
        //唤出模块装配画面
    }
}
