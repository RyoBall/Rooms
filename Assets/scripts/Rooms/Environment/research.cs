using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class research : MonoBehaviour
{
    public int cost;
    public float percent;
    public GameObject tipText;
    public float tipcorrectfactor;
    public int level;
    public int freepoint;
    private void OnMouseDown()
    {
        if (freepoint > 0)
        {
            freepoint--;
            if (Random.value > percent)
            {
                Success();
            }
            else
            {
                fail();
            }
        }
        else
        {
            if (cost <= 20)
            {
                if (Player.instance.energy >= cost)
                {
                    Player.instance.energy -= cost;
                    cost += 5;
                    if (Random.value > percent)
                    {
                        Success();
                    }
                    else
                    {
                        fail();
                    }
                }
                else
                {
                    GameObject tex = Instantiate(tipText, transform.position + Vector3.up * Random.Range(-tipcorrectfactor, tipcorrectfactor) + Vector3.left * Random.Range(-tipcorrectfactor, tipcorrectfactor), Quaternion.identity);
                    tex.GetComponentInChildren<TMP_Text>().text = "NoEnergy";
                }
            }
        }
    }
    void Success()
    {
        percent = .25f;
        int a = Random.Range(0, 4);
        GameObject ins = gameManager.instance.GetChip(a, Random.Range(0, gameManager.instance.chipsDic[a].Count));
        GameObject tex = Instantiate(tipText, transform.position + Vector3.up * Random.Range(1, tipcorrectfactor) + Vector3.left * Random.Range(-tipcorrectfactor, tipcorrectfactor), Quaternion.identity);
        tex.GetComponent<TMP_Text>().text = ins.GetComponent<ChipBase>().chipname;
    }
    void fail()
    {
        percent += .25f;
        GameObject tex = Instantiate(tipText, transform.position + Vector3.up * Random.Range(-tipcorrectfactor, tipcorrectfactor) + Vector3.left * Random.Range(-tipcorrectfactor, tipcorrectfactor), Quaternion.identity);
        tex.GetComponent<TMP_Text>().text = "FAIL";
    }
    private void Start()
    {
        freepoint = level;
        cost = 5;
    }
    private void OnMouseOver()
    {
        if (cost <= 20) 
        {
            NameTex.instance.TMP_Text.text = "�о�����";
            if(freepoint<=0)
            DescriptionTex.instance.TMP_Text.text = "����"+cost.ToString()+ "��Դ�����о�,���ʻ��һ��ģ�飬ʧ�ܻ�����´γɹ��ĸ���";
            else
            DescriptionTex.instance.TMP_Text.text =  "��������Դ����һ���о�,���ʻ��һ��ģ�飬ʧ�ܻ�����´γɹ��ĸ���";
        }
        else 
        {
            NameTex.instance.TMP_Text.text = "���ϵ��о�����";
            DescriptionTex.instance.TMP_Text.text =  "ʹ�ö�����޷��ٴν����о����о�����";
        }
    }
    private void OnMouseExit()
    {
        NameTex.instance.TMP_Text.text = null;
        DescriptionTex.instance.TMP_Text.text = null;
    }
}
