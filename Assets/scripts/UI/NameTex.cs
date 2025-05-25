using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameTex : MonoBehaviour
{
    public static NameTex instance;
    public TMP_Text TMP_Text;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
