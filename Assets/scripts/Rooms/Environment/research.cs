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
            NameTex.instance.TMP_Text.text = "研究器具";
            if(freepoint<=0)
            DescriptionTex.instance.TMP_Text.text = "消耗"+cost.ToString()+ "能源进行研究,概率获得一个模块，失败会提高下次成功的概率";
            else
            DescriptionTex.instance.TMP_Text.text =  "不消耗能源进行一次研究,概率获得一个模块，失败会提高下次成功的概率";
        }
        else 
        {
            NameTex.instance.TMP_Text.text = "报废的研究器具";
            DescriptionTex.instance.TMP_Text.text =  "使用多次已无法再次进行研究的研究器具";
        }
    }
    private void OnMouseExit()
    {
        NameTex.instance.TMP_Text.text = null;
        DescriptionTex.instance.TMP_Text.text = null;
    }
}
