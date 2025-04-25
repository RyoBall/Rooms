using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnknownRoom : MonoBehaviour
{
    private void OnMouseDown()
    {
        if(segment.instance.targetroom)
        segment.instance.targetroom = this;
        segment.instance.GenerateWheel();
    }
}
