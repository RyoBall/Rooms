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
        // ��ȡ����������
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0)
        {
            // �����µ������ߴ�
            float newSize = cam.orthographicSize - scrollInput * zoomSpeed;
            // �������ŷ�Χ
            newSize = Mathf.Clamp(newSize, minZoom, maxZoom);
            // Ӧ������
            cam.orthographicSize = newSize;
        }
    }
}
