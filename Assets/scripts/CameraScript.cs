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

    public Transform target;    // 玩家角色Transform
    public float smoothTime = 0.3f; // 平滑时间（值越大延迟越明显）
    private Vector3 velocity = Vector3.zero;
    private bool isDraging;

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
    private void LateUpdate()
    {
        SmoothFollow();
    }
    void SmoothFollow()
    {
        //按下H找到主角
        if (target != null && Input.GetKeyDown(KeyCode.H))
        {
            // 计算目标位置（保持当前镜头高度）
            Vector3 targetPosition = target.position;
            targetPosition.z = transform.position.z; // 保持Z轴不变（适用于2D）

            // 使用SmoothDamp平滑移动
            transform.position = Vector3.SmoothDamp(
                transform.position,
                targetPosition,
                ref velocity,
                smoothTime,
                Mathf.Infinity,
                Time.deltaTime
            );
        }
        //按下鼠标拖动时让摄像机跟随鼠标
        if(isDraging)
        {                                     
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            targetPosition.z = transform.position.z;
            // 使用SmoothDamp平滑移动
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
