using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnknownRoom : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (segment.instance.targetroom == null) 
        {
        segment.instance.targetroom = this;
        segment.instance.GenerateWheel();
        segment.instance.UIEnter();
        }
    }
}
