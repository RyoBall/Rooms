using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segmentpos : MonoBehaviour
{
    public RectTransform targetUI; // 要检测的目标UI
    public int i;
    private void Start()
    {
        targetUI = GameObject.Find("pos").GetComponent<RectTransform>();
    }
    void Update()
    {
        ;
    }
    IEnumerator checroutine(float waittime) 
    {
        yield return new WaitForSeconds(waittime);
        Checpos();
    }
    private void Checpos() 
    {
        // 获取当前UI的屏幕位置
        Vector2 currentUIPosition = RectTransformUtility.WorldToScreenPoint(
            null,
            transform.position
        );

        // 检测目标UI是否包含当前UI的位置
        if (RectTransformUtility.RectangleContainsScreenPoint(
            targetUI,
            currentUIPosition,
            null // 可传入特定Camera（如果是World Space Canvas）
        ))
        {
            ;
        }
    }
}
