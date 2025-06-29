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
        NameTex.instance.TMP_Text.text = "�����ĳ���";
        DescriptionTex.instance.TMP_Text.text = "�ָ���������";
    }
    private void OnMouseExit()
    {
        NameTex.instance.TMP_Text.text = null;
        DescriptionTex.instance.TMP_Text.text = null;
    }
}
