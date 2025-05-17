using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    public int level;
    public int type;

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
                        RandomAllChip();
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
            switch (level)
            {
                case 1:
                    RandomAllChip();
                    break;
                case 2:
                    RandomTypeChip();
                    break ;
                default:
                    break;
            }
        }
        Destroy(gameObject);
    }

    private static void RandomTypeChip()
    {
        int type = Random.Range(1, 5);
        //根据不同类型随机模块
        switch (type)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        }
        //gameManager.instance.ShowChipAndButton(type,
    }

    void RandomAllChip()
    {
        //这里需要确定总数
        //gameManager.instance.ShowChipAndButton
    }

}

