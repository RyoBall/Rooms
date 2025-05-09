using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetParticle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public List<ParticleSystem> partis;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(1);
        for (int i = 0; i < partis.Count; i++)
        {
            partis[i].Play();
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        for (int i = 0; i < partis.Count; i++)
        {
            partis[i].Pause();
            partis[i].Clear();
        }

    }
}
