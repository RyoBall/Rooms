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
    public List<RectTransform> backpacktrans;
    public int backpackcount;

    public int energy = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetChip(int type,int order) 
    {
        GameObject ins;
        switch (type) 
        {
            //1:武器 2：全局 3：增益
            case 1:
                ins = Instantiate(weaponChips[order-1],backpackpanel.transform);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                backpackcount++;
                break;
            case 2:
                ins = Instantiate(globalChips[order-1], backpackpanel.transform);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                backpackcount++;
                break;
            case 3:
                ins = Instantiate(enhanceChips[order - 1], backpackpanel.transform);
                ins.GetComponent<RectTransform>().position = backpacktrans[backpackcount].position;
                backpackcount++;
                break;
        }
    }
}
