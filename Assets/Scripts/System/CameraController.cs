using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    private Vector3 initialPosition;

    private void Start()
    {
        // Lưu vị trí ban đầu của camera
        initialPosition = transform.position;

	    // Tạo animation kéo camera lên trên theo trục y
        transform.DOMoveY(0f, 0.5f).SetEase(Ease.Linear);
    }

    private void ResetCameraPosition()
    {
        // Đặt lại vị trí camera về vị trí ban đầu
        transform.position = initialPosition;
    }
}
