using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class healthTex : MonoBehaviour
{
    private TMP_Text tex;
    // Start is called before the first frame update
    void Start()
    {
        tex = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int health = (int)Player.instance.health;
        tex.text = health.ToString()+"/"+Player.instance.healthm.ToString();
    }
}
