using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBackGround : MonoBehaviour
{
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NameTex.instance.TMP_Text.text == ""||NameTex.instance.TMP_Text.text == null)
        {
            image.enabled = false;
        }
        else
            image.enabled = true;
    }
}
