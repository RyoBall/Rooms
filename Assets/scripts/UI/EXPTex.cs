using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EXPTex : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = Player.instance.exp.ToString() + '/' + Player.instance.expm.ToString();
    }
}
