using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float zoomSpeed = 5f;   
    public float minZoom = 10f;     
    public float maxZoom = 20f;    

    private Camera cam;

    public Transform target;    // ��ҽ�ɫTransform
    public float smoothTime = 0.3f; // ƽ��ʱ�䣨ֵԽ���ӳ�Խ���ԣ�
    private Vector3 velocity = Vector3.zero;
    private bool isDraging;

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
    private void LateUpdate()
    {
        SmoothFollow();
    }
    void SmoothFollow()
    {
        //����H�ҵ�����
        if (target != null && Input.GetKeyDown(KeyCode.H))
        {
            // ����Ŀ��λ�ã����ֵ�ǰ��ͷ�߶ȣ�
            Vector3 targetPosition = target.position;
            targetPosition.z = transform.position.z; // ����Z�᲻�䣨������2D��

            // ʹ��SmoothDampƽ���ƶ�
            transform.position = Vector3.SmoothDamp(
                transform.position,
                targetPosition,
                ref velocity,
                smoothTime,
                Mathf.Infinity,
                Time.deltaTime
            );
        }
        //��������϶�ʱ��������������
        if(isDraging)
        {                                     
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            targetPosition.z = transform.position.z;
            // ʹ��SmoothDampƽ���ƶ�
            transform.position = Vector3.SmoothDamp(
                transform.position,
                targetPosition,
                ref velocity,
                smoothTime,
                Mathf.Infinity,
                Time.deltaTime
            );
        }
    }

    private void OnMouseDown()
    {
        isDraging = true;
    }

    private void OnMouseUp()
    {
        isDraging = false;
    }
}
