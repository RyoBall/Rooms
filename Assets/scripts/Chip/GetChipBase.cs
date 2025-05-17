using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetChipBase : MonoBehaviour, IPointerClickHandler
{
    public int type;
    public int order;
    public TMP_Text Name;
    public TMP_Text Description;
    public GetChipBase(int type, int order)
    {
        this.type = type;
        this.order = order;
    }
    // Start is called before the first frame update
    void Start()
    {
        Name = transform.Find("Name").GetComponent<TMP_Text>();
        Description = transform.Find("Description").GetComponent<TMP_Text>();
        Name.text = gameManager.instance.chipsDic[type][order].GetComponent<ChipBase>().chipname;
        Description.text = gameManager.instance.chipsDic[type][order].GetComponent<ChipBase>().description;
    }
    // Update is called once per frame
    void Update()
    {
        ;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameManager.instance.GetChip(type, order);
        ChoosePanel.instance.Exit();
    }


}
