using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class research : MonoBehaviour
{
    private void OnMouseDown()
    {
        int num = Random.Range(0, 3);
        switch (num)
        {
            case 0:
                Player.instance.health += 50;
                break;
            case 1:
                Player.instance.health -= 20;
                break;
            case 2:
                Player.instance.healthm += 20;
                Player.instance.healthm += 20;
                break;
            default:
                return;
        }
    }
}
