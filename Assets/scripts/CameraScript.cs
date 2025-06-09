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
    public Vector3 StartPosition;
    public Transform target;    // ��ҽ�ɫTransform
    public float smoothTime = 0.3f; // ƽ��ʱ�䣨ֵԽ���ӳ�Խ���ԣ�
    private Vector2 velocity = Vector2.zero;
    private bool isDraging;
    public float Distancefactor;
    void Start()
    {
        target = Player.instance.transform;
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        sizeControl();
        moveCamera();
    }
    private void LateUpdate()
    {
        SmoothFollow();
    }
    void moveCamera()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartPosition = Player.instance.transform.position;
            isDraging = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isDraging = false;
        }
    }
    void sizeControl()
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
    void SmoothFollow()
    {
        //����H�ҵ�����
        if (target != null && !isDraging)
        {
            Vector3 targetPosition = target.position;
            targetPosition.z = transform.position.z;
            Vector2 smoothposition = Vector2.SmoothDamp(
                transform.position,
                targetPosition,
                ref velocity,
                smoothTime,
                Mathf.Infinity,
                Time.deltaTime
            );
            transform.position = new Vector3(smoothposition.x, smoothposition.y, transform.position.z);
        }
        //��������϶�ʱ��������������
        if (isDraging)
        {
            // ��ȡ��Ļ���ĵ㣨��̬��Ӧ�ֱ��ʱ仯��
            Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

            // �������ƫ������������Ļ���أ�
            Vector2 mouseOffset = (Vector2)Input.mousePosition - screenCenter;
            Vector2 Offset = mouseOffset * Distancefactor;
            // �����׼��ƫ�Ʊ���
            Vector3 targetPosition = StartPosition + new Vector3(Offset.x, Offset.y, 0);
            targetPosition.z = transform.position.z;
            // ʹ��SmoothDampƽ���ƶ�
            Vector2 smoothposition = Vector2.SmoothDamp(
     transform.position,
     targetPosition,
     ref velocity,
     smoothTime,
     Mathf.Infinity,
     Time.deltaTime
 );
            transform.position = new Vector3(smoothposition.x, smoothposition.y, transform.position.z);
        }
    }


}
