﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotateScript : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 50f;
    private bool canRotate;
    private float angle;
    /// <summary>Awake is called when the script instance is begin loaded</summary>
    void Awake()
    {
        canRotate = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            RotateTheCircle();
        }
    }

    void RotateTheCircle()
    {
        angle = transform.rotation.eulerAngles.z;
        angle += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
