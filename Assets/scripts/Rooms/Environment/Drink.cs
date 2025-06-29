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
        for(int i = 0; i < 3; i++) 
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
                //��ʵû��Ҫ�����ﵫ����д��д�˶����ú���
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
}
