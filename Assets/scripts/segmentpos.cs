using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segmentpos : MonoBehaviour
{
    public RectTransform targetUI; // Ҫ����Ŀ��UI
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
        // ��ȡ��ǰUI����Ļλ��
        Vector2 currentUIPosition = RectTransformUtility.WorldToScreenPoint(
            null,
            transform.position
        );

        // ���Ŀ��UI�Ƿ������ǰUI��λ��
        if (RectTransformUtility.RectangleContainsScreenPoint(
            targetUI,
            currentUIPosition,
            null // �ɴ����ض�Camera�������World Space Canvas��
        ))
        {
            ;
        }
    }
}
