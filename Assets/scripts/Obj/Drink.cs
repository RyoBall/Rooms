using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    public int num;
    private void OnMouseDown()
    {
        num = Random.Range(0, 3);
        switch (num)
        {
            case 0:
                Player.instance.currentSanity += 50;
                break;
            case 1:
                Player.instance.currentSanity -= 20;
                break;
            case 2:
                Player.instance.maxSanity += 20;
                Player.instance.currentSanity += 20;
                break;
            default:
                return;
        }
        //Destroy(gameObject);
    }
}
