using DG.Tweening;
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
    public Transform target;    // 玩家角色Transform
    public float smoothTime = 0.3f; // 平滑时间（值越大延迟越明显）
    private Vector2 velocity = Vector2.zero;
    private bool isDraging;
    public float Distancefactor;
    public float OffsetFactor;
    public float moveTime;
    public float movespeed;
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
    void SmoothFollow()
    {
        //按下H找到主角
        if (target != null && !isDraging)
        {
            Follow();
        }
        //按下鼠标拖动时让摄像机跟随鼠标
        if (isDraging)
        {
            // 获取屏幕中心点（动态适应分辨率变化）
            Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

            // 计算鼠标偏移量（基于屏幕像素）
            Vector2 mouseOffset = (Vector2)Input.mousePosition - screenCenter;
            Vector2 Offset = mouseOffset * Distancefactor;
            // 计算标准化偏移比例
            Vector3 targetPosition = StartPosition + new Vector3(Offset.x, Offset.y, 0);
            targetPosition.z = transform.position.z;
            // 使用SmoothDamp平滑移动
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
    void Follow() 
    {
        /*Vector2 Offset=Player.instance.rb.velocity;
        Vector3 targetPosition = Player.instance.transform.position + new Vector3(Offset.x * OffsetFactor, Offset.y * OffsetFactor, -10);
        if(!(transform.position.x-targetPosition.x<.05f&& transform.position.x - targetPosition.x > -.05f&& transform.position.y - targetPosition.y < .05f && transform.position.y - targetPosition.y > -.05f))
        {
            transform.position += (targetPosition - transform.position).normalized * movespeed * Time.deltaTime;        
        }
        if(transform.position.x - targetPosition.x >10||transform.position.x - targetPosition.x < -10f || transform.position.y - targetPosition.y > 10f || transform.position.y - targetPosition.y < -10) 
        {
            transform.position = Player.instance.transform.position+new Vector3(0,0,-10);
        }*/
        transform.position = Player.instance.transform.position + new Vector3(0, 0, -10);
    }
}
