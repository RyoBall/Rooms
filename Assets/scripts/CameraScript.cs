using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float zoomSpeed = 5f;   
    public float minZoom = 10f;     
    public float maxZoom = 20f;    

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // 获取鼠标滚轮输入
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0)
        {
            // 计算新的正交尺寸
            float newSize = cam.orthographicSize - scrollInput * zoomSpeed;
            // 限制缩放范围
            newSize = Mathf.Clamp(newSize, minZoom, maxZoom);
            // 应用缩放
            cam.orthographicSize = newSize;
        }
    }
}
