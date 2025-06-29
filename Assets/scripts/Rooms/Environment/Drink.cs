using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    public int level;
    public DrinkRoom dad;
    private void OnMouseDown()
    {
        int num = Random.Range(0, 3);
        switch (level)
        {
            case 0:
                Level0(num);
                break;
            case 1:
                Level1(num);
                break;
            case 2:
                Level2(num);
                break;
            default:
                break;
        }
        NameTex.instance.TMP_Text.text = null;
        DescriptionTex.instance.TMP_Text.text = null;
        for (int i = 0; i < 3; i++) 
        {
            Destroy(dad.gameObjects[i]);
        }
    }


    private static void Level0(int num)
    {
        
        switch (num)
        {
            case 0:
                CheckAndRecover((int)Player.instance.healthm / 3);
                break;
            case 1:
                Player.instance.health -= Player.instance.healthm * .2f;
                break;
            case 2:
                Player.instance.healthm += 20;
                Player.instance.health += 20;
                break;
            default:
                return;
        }
    }

    private static void Level1(int num)
    {
        switch (num)
        {
            case 0:
                CheckAndRecover((int)Player.instance.healthm *2 /3);
                break;
            case 1:
                Player.instance.healthm += 40;
                break;
            case 2:
                Player.instance.healthm += 20;
                CheckAndRecover(30);
                break;
            default:
                return;
        }
    }
    private void Level2(int num)
    {
        switch (num)
        {
            case 0:
                Player.instance.health = Player.instance.healthm;
                break;
            case 1:
                Player.instance.healthm += 50;
                break;
            case 2:
                Player.instance.healthm += 30;
                CheckAndRecover(30);
                break;
            default:
                return;
        }
    }

    private static void CheckAndRecover(int health)
    {
        float current = Player.instance.health;
        float max = Player.instance.healthm;
        Player.instance.health = current + health < max  ?
            current + health : max;
    }
    private void OnMouseEnter()
    {
        switch (level) 
        {
            case 1:
                NameTex.instance.TMP_Text.text = "诡异的饮料";
                DescriptionTex.instance.TMP_Text.text = "随机触发以下效果之一：恢复理智值上限的1/3理智度；\r\n降低理智值总上限的五分之一的理智值；\r\n提高20理智度上限，同时恢复20理智度";
                break;
            case 2:
                NameTex.instance.TMP_Text.text = "疑似正常的饮料";
                DescriptionTex.instance.TMP_Text.text = "随机触发以下效果之一:恢复理智值上限的2/3理智度；\r\n提高40理智值上限，不同时恢复理智值；\r\n提高20理智值上限，同时恢复30理智值；";
                break;
            case 3:
                NameTex.instance.TMP_Text.text = "看起来不错的饮料";
                DescriptionTex.instance.TMP_Text.text = "随机触发以下效果之一:恢复全部理智度；\r\n提高50理智值上限，不同时恢复理智值；\r\n提高30理智度上限，同时恢复30理智度；";
                break;
        }
    }
    private void OnMouseExit()
    {
        NameTex.instance.TMP_Text.text = null;
        DescriptionTex.instance.TMP_Text.text = null;
    }
}
