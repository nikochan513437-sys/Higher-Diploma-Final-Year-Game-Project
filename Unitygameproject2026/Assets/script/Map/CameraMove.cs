using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour
{
    public GameObject equipPanel, escPanel, dialog;
    public float moveSpeed;
    public float scrollSpeed = 500f;
    public float minZoom = 5f;
    public float maxZoom = 10f;
    public float maxLimX;
    public float minLimX;
    public float maxLimY;
    public float minLimY;
    public float cameraZOffset = -10f;

    void Start()
    {
        equipPanel = Canvas1Spawn.instance.transform.Find("Inventory-EquipPanel").gameObject;
        escPanel = Canvas1Spawn.instance.transform.Find("EscPanel").gameObject;

        if (Setting.Instance != null)
        {
            moveSpeed = Setting.Instance.MapMoveSpeed;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameMap")
        {
            if (!GameManage.CanAct())
                return;
        }
        if (dialog != null && dialog.activeSelf)
            return;

        if (Setting.Instance != null)
        {
            moveSpeed = Setting.Instance.MapMoveSpeed;
        }
        if (Input.GetMouseButton(0))
          {
            MoveCamera();
          }
        LimitCameraBounds();
        ZoomCamera(); 

    }

    void LimitCameraBounds() {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minLimX, maxLimX);
        pos.y = Mathf.Clamp(pos.y, minLimY, maxLimY);
        transform.position = pos;
    }

    void ZoomCamera() {
        float scrollVar = -Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;
        Camera.main.orthographicSize += scrollVar;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);

    }
    void MoveCamera() {
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Translate(-mouseX * moveSpeed * Time.deltaTime, -mouseY * moveSpeed * Time.deltaTime, 0, Space.World);
    }

    public void FocusOnPlayer(int playerIndex)
    {
        if (GameManage.MapPoints != null && playerIndex >= 0 && playerIndex < GameManage.MapPoints.Length)
        {
            MapPoint targetPoint = GameManage.MapPoints[playerIndex];

            if (targetPoint != null)
            {
                Vector3 targetPos = targetPoint.transform.position;

                transform.position = new Vector3(targetPos.x, targetPos.y, cameraZOffset);

            }
        }
    }
}

