using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPSlider : MonoBehaviour
{
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Player.instance.exp / Player.instance.expm;
    }
}
