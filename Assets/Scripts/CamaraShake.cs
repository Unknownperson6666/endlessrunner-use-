using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration = 0.3f;
    public float magnitude = 0.2f;

    private Vector3 originalPos;
    private float shakeTime = 0f;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        if (shakeTime > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * magnitude;
            shakeTime -= Time.deltaTime;
        }
        else
        {
            shakeTime = 0f;
            transform.localPosition = originalPos;
        }
    }

    public void Shake()
    {
        shakeTime = duration;
    }
}
