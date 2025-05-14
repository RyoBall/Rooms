using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private void OnMouseDown()
    {
        Player.instance.health = Player.instance.healthm;
        Destroy(gameObject);
    }
}
