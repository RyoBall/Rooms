using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class bulletEnhanceBase : EnhanceChipBase
{
    public GameObject partA;
    public RectTransform partArect;
    public Vector3 relativePosition;
    public override void chipentereffect(ChipBase chip)
    {
        Debug.Log("Enter");
        base.chipentereffect(chip);
    }

    public override void chipexiteffect(ChipBase chip)
    {
        Debug.Log("Exit");
        base.chipexiteffect(chip);
    }

    public override void entereffect(GameObject BackGround)
    {
        base.entereffect(BackGround);
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
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        chosen = false;
        GetComponent<Image>().raycastTarget = true;
        RaycastHit2D[] hits;
        RaycastHit2D[] Ahits;
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, partA.transform.position);
        PointerEventData eventDataA = new PointerEventData(EventSystem.current);
        hits = Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(eventData.position));
        eventDataA.position = screenPos;
        Ahits = Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(eventDataA.position));
        UIframe Aback = null;
        foreach (var hit in Ahits)
        {
            if (hit.collider.gameObject.layer == GetinChips.UIcaolayer && hit.collider.gameObject.GetComponent<UIframe>().unlock && !hit.collider.gameObject.GetComponent<UIframe>().getin)
            {
                Aback = hit.collider.gameObject.GetComponent<UIframe>();
            }
        }
        if (Aback != null && Aback.unlock)
        {
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.layer == GetinChips.UIcaolayer && hit.collider.gameObject.GetComponent<UIframe>().unlock && !hit.collider.gameObject.GetComponent<UIframe>().getin)
                {
                    partA.GetComponent<occupy>().background = Aback;
                    entereffect(hit.collider.gameObject);
                }
            }
        }
        if (!getin)
        {
            returnposition();
        }

    }

    public override void Start()
    {
        base.Start();
        partA = GetComponentInChildren<occupy>().gameObject;
        relativePosition = partA.transform.position - transform.position;
        partArect = partA.GetComponent<RectTransform>();
    }
}
