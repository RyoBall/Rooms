using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetParticle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public List<ParticleSystem> partis;
    public GetChipBase getchip;
    // Start is called before the first frame update
    void Start()
    {
        getchip = GetComponent<GetChipBase>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        for (int i = 0; i < partis.Count; i++)
        {
            partis[i].Play();
        }
        getchip.EnterAction.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        for (int i = 0; i < partis.Count; i++)
        {
            partis[i].Pause();
            partis[i].Clear();
        }
        getchip.ExitAction.Invoke();

    }
}
