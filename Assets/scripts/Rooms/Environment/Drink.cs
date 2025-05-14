using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    private void OnMouseDown()
    {
        int num = Random.Range(0, 3);
        switch (num)
        {
            case 0:
                Player.instance.health += Player.instance.healthm*.5f;
                break;
            case 1:
                Player.instance.health -= Player.instance.healthm * .2f;
                break;
            case 2:
                Player.instance.healthm += Player.instance.healthm * .2f;
                Player.instance.healthm += Player.instance.healthm * .2f    ;
                break;
            default:
                return;
        }
        Destroy(gameObject);
    }
}
