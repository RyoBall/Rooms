using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyTex : MonoBehaviour
{
    public static EnergyTex instance;
    private TMP_Text text;
    void Awake()
    {
        instance = this;
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "ฤÜิด:" +Player.instance.energy.ToString();
    }
}
