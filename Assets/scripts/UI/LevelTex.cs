using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTex : MonoBehaviour
{
    public static LevelTex instance;
    private TMP_Text text;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "LV:" + Player.instance.level.ToString();
    }
}
