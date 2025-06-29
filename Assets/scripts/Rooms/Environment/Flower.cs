using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private void OnMouseDown()
    {
        Player.instance.health = Player.instance.healthm;
        OnMouseExit();
        Destroy(gameObject);
    }
    private void OnMouseEnter()
    {
        NameTex.instance.TMP_Text.text = "宁静的长椅";
        DescriptionTex.instance.TMP_Text.text = "恢复部分理智";
    }
    private void OnMouseExit()
    {
        NameTex.instance.TMP_Text.text = null;
        DescriptionTex.instance.TMP_Text.text = null;
    }
}
