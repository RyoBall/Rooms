using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnLockPointText : MonoBehaviour
{
    public static UnLockPointText instance;
    public TMP_Text text;
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
        text.text = "¿É½âËøµÄÐ¾Æ¬²Û:" + Player.instance.unlockpoint.ToString();
    }
}
