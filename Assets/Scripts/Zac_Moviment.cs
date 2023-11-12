using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zac_Moviment : MonoBehaviour
{
    public float speed = 5.0f;
    private CharacterController characterController;
    private Animator animator;
    private Vector3 inputs;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(inputs * Time.deltaTime * speed);

        if (inputs != Vector3.zero)
        {
            // Verifica se o movimento é predominantemente horizontal ou vertical
            bool isHorizontalMovement = Mathf.Abs(inputs.x) > Mathf.Abs(inputs.z);

            animator.SetBool("Andando", true);

            // Se o movimento for predominantemente horizontal, ajusta apenas o eixo X
            // Se for vertical, ajusta apenas o eixo Z
            float targetAngle = isHorizontalMovement ? Mathf.Atan2(inputs.x, 0) : Mathf.Atan2(0, inputs.z);
            transform.rotation = Quaternion.Euler(0, targetAngle * Mathf.Rad2Deg, 0);
        }
        else
        {
            animator.SetBool("Andando", false);
        }
    }
}
