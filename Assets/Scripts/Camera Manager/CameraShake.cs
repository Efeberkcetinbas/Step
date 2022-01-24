using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { private set; get; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    [SerializeField] private Camera _camera;

    Vector3 cameraInitialPos;

    [SerializeField] private float _shakeMagnitude = 0.05f, _shakeTime = 0.5f;

    public void DoShake()
    {
        cameraInitialPos = _camera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", _shakeTime);
    }

    void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * _shakeMagnitude * 2 - _shakeMagnitude;
        float cameraShakingOffsetY = Random.value * _shakeMagnitude * 2 - _shakeMagnitude;

        Vector3 cameraIntermediatePos = _camera.transform.position;

        cameraIntermediatePos.x += cameraShakingOffsetX;
        cameraIntermediatePos.y += cameraShakingOffsetY;
        _camera.transform.position = cameraIntermediatePos;
    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        _camera.transform.position = cameraInitialPos;
    }
}
