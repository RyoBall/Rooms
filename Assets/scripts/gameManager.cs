using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    [Header("GetChip")]
    public GameObject backpackpanel;
    public List<GameObject> weaponChips;
    public List<GameObject> globalChips;
    public List<GameObject> enhanceChips;
    public List<GameObject> specialChips;
    public Dictionary<int, List<GameObject>> chipsDic=new Dictionary<int,List<GameObject>>();
    public List<RectTransform> backpacktrans;
    public List<RectTransform> buttonpacktrans;
    public int backpackcount;
    public GameObject chipGetButton;
    public GameObject chipGetButtonParent;
    public int energy = 0;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        InitDic();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            GetChipButton(1, 0,0);
        }
    }
    void InitDic() 
    {
        chipsDic.Add(1, weaponChips);
        chipsDic.Add(2, globalChips);
        chipsDic.Add(3, enhanceChips);
        chipsDic.Add(4, specialChips);
    }
    public void GetChip(int type,int order) 
    {
        GameObject ins;
        switch (type) 
        {
            //1:武器 2：全局 3：增益 4:特殊
            case 1:
                ins = Instantiate(weaponChips[order],backpackpanel.transform);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                backpackcount++;
                break;
            case 2:
                ins = Instantiate(globalChips[order], backpackpanel.transform);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                backpackcount++;
                break;
            case 3:
                ins = Instantiate(enhanceChips[order], backpackpanel.transform);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                backpackcount++;
                break;
            case 4:
                ins = Instantiate(enhanceChips[order], backpackpanel.transform);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                backpackcount++;
                break;
        }
    }
    public void GetChipButton(int type,int order,int position) 
    {
        GameObject chipbutton = Instantiate(chipGetButton, buttonpacktrans[position].position, Quaternion.identity,chipGetButtonParent.transform);
        ChoosePanel.instance.choice.Add(chipbutton);
        chipbutton.GetComponent<RectTransform>().position = buttonpacktrans[position].position;
        GameObject ins;
        GetChipBase insscript;
        switch (type)
        {
            //1:武器 2：全局 3：增益 4:特殊
            case 1:
                ins = Instantiate(weaponChips[order], chipbutton.transform.Find("chipPosition").position, Quaternion.identity, chipbutton.transform.Find("chipPosition"));
                Destroy(ins.GetComponent<ChipBase>());
                if (ins.GetComponentInChildren<occupy>() != null) 
                {
                    Destroy(ins.GetComponent<occupy>());
                }
                insscript=chipbutton.AddComponent<GetChipBase>();
                insscript.type = type;
                insscript.order = order;
                break;
            case 2:
                ins = Instantiate(globalChips[order], chipbutton.transform.Find("chipPosition").position, Quaternion.identity, chipbutton.transform.Find("chipPosition"));
                Destroy(ins.GetComponent<ChipBase>());
                if (ins.GetComponentInChildren<occupy>() != null)
                {
                    Destroy(ins.GetComponent<occupy>());
                }
                insscript = chipbutton.AddComponent<GetChipBase>();
                insscript.type = type;
                insscript.order = order;
                break;
            case 3:
                ins = Instantiate(enhanceChips[order], chipbutton.transform.Find("chipPosition").position,Quaternion.identity, chipbutton.transform.Find("chipPosition"));
                Destroy(ins.GetComponent<ChipBase>());
                if (ins.GetComponentInChildren<occupy>() != null)
                {
                    Destroy(ins.GetComponent<occupy>());
                }
                insscript = chipbutton.AddComponent<GetChipBase>();
                insscript.type = type;
                insscript.order = order;
                break;
            case 4:
                ins = Instantiate(enhanceChips[order], chipbutton.transform.Find("chipPosition").position, Quaternion.identity, chipbutton.transform.Find("chipPosition"));
                Destroy(ins.GetComponent<ChipBase>());
                if (ins.GetComponentInChildren<occupy>() != null)
                {
                    Destroy(ins.GetComponent<occupy>());
                }
                insscript = chipbutton.AddComponent<GetChipBase>();
                insscript.type = type;
                insscript.order = order;
                break;
        }
    }
}
