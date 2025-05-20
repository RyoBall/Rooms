using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    public int level;
    private void OnMouseDown()
    {
        Debug.Log(1);
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
        Destroy(gameObject);
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
                //其实没必要用这里但是我写都写了多用用好啦
                CheckAndRecover(30);
                break;
            default:
                return;
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

    private static void CheckAndRecover(int health)
    {
        float current = Player.instance.currentSanity;
        float max = Player.instance.maxSanity;
        Player.instance.currentSanity = current + health < max  ?
            current + health : max;
    }
}
