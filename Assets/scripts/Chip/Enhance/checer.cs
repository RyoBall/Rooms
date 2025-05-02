using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checer : MonoBehaviour
{
    public EnhanceChipBase dad;
    public List<GameObject> nochec = new List<GameObject>();
    private void Start()
    {
        dad = transform.parent.GetComponent<EnhanceChipBase>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!nochec.Contains(collision.gameObject))
        {
            if (dad.getin && collision.tag == "chip")
            {
                ChipBase a = collision.GetComponent<ChipBase>();
                if (!dad.ChipsAround.Contains(a) && a.getin)
                    dad.chipentereffect(a);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "chip")
        {
            ChipBase a = collision.GetComponent<ChipBase>();
            if (dad.ChipsAround.Contains(a))
                dad.chipexiteffect(a);
        }
    }
}

