using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FactorText : MonoBehaviour
{
    public enum Type {Attack,Critical,CriticalAttack,Hide,DamageEffect };
    private TMP_Text tmp;
    [SerializeField]Type type;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (type) 
        {
            case Type.Attack:
                tmp.text = "¹¥»÷:" + Player.instance.attack.ToString();
                break;
            case Type.Critical:
                tmp.text = "±©»÷ÂÊ:" + (Player.instance.criticalfactor * 100).ToString() + '%';
                break;
            case Type.CriticalAttack:
                tmp.text = "±©»÷ÉËº¦:" + (Player.instance.criticalattackfactor*100).ToString()+'%';
                break;
            case Type.Hide:
                tmp.text = "ÉÁ±ÜÂÊ:" + (Player.instance.hidefactor*100).ToString()+'%';
                break;
            case Type.DamageEffect:
                tmp.text = "ÉËº¦¼Ó³É:" + (Player.instance.attackfactor * 100).ToString() + '%';
                break;
        }
    }
}
