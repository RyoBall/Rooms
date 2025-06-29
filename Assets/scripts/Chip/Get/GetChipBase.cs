using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetChipBase : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    public int type;
    public int order;
    public TMP_Text Name;
    public TMP_Text Description;
    public Action EnterAction;
    public Action ExitAction;
    public AudioSource audio;
    public GetChipBase(int type, int order)
    {
        this.type = type;
        this.order = order;
    }
    private void Awake()
    {
        EnterAction += EnterTex;
        ExitAction += ExitTex;
        audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        ;
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
        audio.Play();
    }
    public void EnterTex() 
    {
        NameTex.instance.TMP_Text.text = gameManager.instance.chipsDic[type][order].GetComponent<ChipBase>().chipname;
        DescriptionTex.instance.TMP_Text.text = gameManager.instance.chipsDic[type][order].GetComponent<ChipBase>().description;
        NameTex.instance.TMP_Text.enabled = true;
        DescriptionTex.instance.TMP_Text.enabled = true;
    }
    public void ExitTex() 
    {
        NameTex.instance.TMP_Text.enabled = false;
        DescriptionTex.instance.TMP_Text.enabled = false;
        NameTex.instance.TMP_Text.text = null;
        DescriptionTex.instance.TMP_Text.text = null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        EnterAction.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ExitAction.Invoke();
    }
}
