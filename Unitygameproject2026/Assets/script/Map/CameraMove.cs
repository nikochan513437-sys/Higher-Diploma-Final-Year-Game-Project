using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject equipPanel, escPanel, dialog;
    public float moveSpeed = 50f;
    public float scrollSpeed = 500f;
    public float minZoom = 5f;
    public float maxZoom = 10f;

    void Start()
    {
        equipPanel = Canvas1.instance.transform.Find("Inventory-EquipPanel").gameObject;
        escPanel = Canvas1.instance.transform.Find("EscPanel").gameObject;
    }

    void Update()
    {
            if (!equipPanel.activeSelf && !escPanel.activeSelf && !dialog.activeSelf)
            {
                if (Input.GetMouseButton(0))
                {
                    MoveCamera();
                }
                LimitCameraBounds();
                ZoomCamera();
            }
        
    }

    void LimitCameraBounds() {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -12, 12);
        pos.y = Mathf.Clamp(pos.y, -9, 9);
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
}
