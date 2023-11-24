using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class ControlaCamera : MonoBehaviour
{
    [SerializeField] private AxisState xAxis;
    [SerializeField] private AxisState yAxis;
    [SerializeField] private Transform olhando;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Console.Clear();
    }
    private void Update()
    {
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);

        olhando.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, xAxis.Value, 0), 5 * Time.deltaTime);
    }
}


