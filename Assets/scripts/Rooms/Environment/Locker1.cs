using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker1 : MonoBehaviour
{
    public int level;

    private void OnMouseDown()
    {
        switch (level)
        {
            case 0:
                if (Random.value < .7f)
                {
                    Player.instance.energy += Random.Range(5, 21);
                }
                else
                    //这里需要确定总数
                    //gameManager.instance.GetChip
                    ;
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
        Destroy(gameObject);
    }
}
