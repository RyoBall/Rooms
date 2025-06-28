using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPSlider : MonoBehaviour
{
    public Material targetMaterial;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        targetMaterial.SetFloat("_Current", Player.instance.exp / Player.instance.expm);
    }
}
