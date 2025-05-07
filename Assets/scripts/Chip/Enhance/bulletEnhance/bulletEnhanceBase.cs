using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class bulletEnhanceBase : EnhanceChipBase
{
    public GameObject partA;
    public Vector3 relativePosition;
    public override void checAround()
    {
        base.checAround();
    }

    public override void chipentereffect(ChipBase chip)
    {
        base.chipentereffect(chip);
    }

    public override void chipexiteffect(ChipBase chip)
    {
        base.chipexiteffect(chip);
    }

    public override void entereffect(RaycastResult result)
    {
        base.entereffect(result);
        partA.GetComponent<occupy>().background.getin = true;
    }

    public override void exiteffect()
    {
        base.exiteffect();
        partA.GetComponent<occupy>().background.getin = false;
        partA.GetComponent<occupy>().background = null;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        partA.transform.position = transform.position + relativePosition;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        chosen = false;
        GetComponent<Image>().raycastTarget = true;
        List<RaycastResult> results = new List<RaycastResult>();
        List<RaycastResult> Aresults = new List<RaycastResult>();
        //以下是对副模块检测
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(null, partA.transform.position);
        PointerEventData eventDataA = new PointerEventData(EventSystem.current);
        eventDataA.position = screenPos;
        Debug.Log(eventData.position);
        Debug.Log(eventDataA.position);
        EventSystem.current.RaycastAll(eventDataA, Aresults);
        UIframe Aback = null;
        foreach (var result in Aresults)
        {
            if (result.gameObject.layer == GetinChips.UIcaolayer && result.gameObject.GetComponent<UIframe>().unlock && !result.gameObject.GetComponent<UIframe>().getin)
            {
                Aback = result.gameObject.GetComponent<UIframe>();
            }
        }
        if (Aback != null && Aback.unlock)
        {
            //以下是对主模块检测
            EventSystem.current.RaycastAll(eventData, results);
            foreach (var result in results)
            {
                if (result.gameObject.layer == GetinChips.UIcaolayer && result.gameObject.GetComponent<UIframe>().unlock && !result.gameObject.GetComponent<UIframe>().getin)
                {
                    partA.GetComponent<occupy>().background = Aback;
                    entereffect(result);
                }
            }
        }
        else if (Aback == null)
        {
            Debug.Log("notfind");
        }
        if (!getin)
        {
            returnposition();
        }

    }

    public override void Start()
    {
        base.Start();
        partA = transform.Find("occupy").gameObject;
        relativePosition = partA.transform.position - transform.position;
    }
}
