using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    [SerializeField] private CinemachineVirtualCamera zoomedInCamera;
    [SerializeField] private CinemachineVirtualCamera zoomedOutCamera;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;

        ZoomOut();
    }

    private void Start()
    {
        SetFollowTarget();
    }

    private void SetFollowTarget()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        zoomedInCamera.Follow = player;
        zoomedOutCamera.Follow = player;
    }

    public void ZoomIn()
    {
        zoomedInCamera.Priority = 1;
        zoomedOutCamera.Priority = 0;
    }
    public void ZoomOut()
    {
        zoomedInCamera.Priority = 0;
        zoomedOutCamera.Priority = 1;
    }
}
