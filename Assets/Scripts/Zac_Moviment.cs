using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zac_Moviment : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 10.0f; // Nova vari�vel para controlar a velocidade de rota��o
    private CharacterController characterController;
    private Animator animator;
    private Vector3 inputs;
    public float sensitivity = 2.0f;
    private float rotationX = 0.0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        
        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        inputs.Normalize();
        characterController.Move(inputs * Time.deltaTime * speed);

        if (inputs != Vector3.zero)
        {
            animator.SetBool("Andando", true);

            // Calcular o �ngulo desejado
            float targetAngle = Mathf.Atan2(inputs.x, inputs.z) * Mathf.Rad2Deg;

            // Suavizar a rota��o usando Lerp
            float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, Time.deltaTime * rotationSpeed);

            // Aplicar a rota��o suavizada
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
        else
        {
            animator.SetBool("Andando", false);
        }
    }


}

