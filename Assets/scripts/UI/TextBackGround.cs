using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBackGround : MonoBehaviour
{
    private Image image;
    [SerializeField]private Image backimage;
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
            backimage.enabled = false;
        }
        else 
        {
            image.enabled = true;
            backimage.enabled = true;
        }
    }
}
