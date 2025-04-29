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
        Debug.Log(i);
        Destroy(segment.instance.targetroom.gameObject);
        Instantiate(room, segment.instance.targetroom.transform.position, Quaternion.identity);
        //以下考虑放在segment里
        segment.instance.targetroom = null;
        segment.instance.UIExit();
    }
}