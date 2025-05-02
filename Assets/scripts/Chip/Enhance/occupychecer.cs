using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class occupychecer : MonoBehaviour
{
    public occupy dadscri;
    // Start is called before the first frame update
    void Start()
    {
        dadscri = GetComponentInParent<occupy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) 
        {
            dadscri.background = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            dadscri.background =null;
        }
    }*/
}
