using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class occupy : MonoBehaviour
{
    public UIframe background;
    public bulletEnhanceBase dad;



    // Start is called before the first frame update
    void Start()
    {
        dad = GetComponentInParent<bulletEnhanceBase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
