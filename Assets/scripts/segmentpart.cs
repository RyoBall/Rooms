using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;

public class segmentpart : MonoBehaviour
{
    public RectTransform targetUI; // 要检测的目标UI
    public GameObject room;
    public int i;

    public void Effect() 
    {
        Debug.Log("enterpos");
        Destroy(segment.instance.targetroom.gameObject);
        Instantiate(room, segment.instance.targetroom.transform.position, Quaternion.identity);
        segment.instance.targetroom = null;
        segment.instance.UIExit();
    }
}