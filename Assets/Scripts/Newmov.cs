using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newmov : MonoBehaviour
{
    private float inputX;
    private float inputY;
    private CharacterController characterController;
    private Animator animator;
    private int inputXHash = Animator.StringToHash("inputX");
    private int inputYHash = Animator.StringToHash("inputY");





    Interagir playerInteraction;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerInteraction = GetComponentInChildren<Interagir>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
        Interact();
    }

    public void Movimento()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        animator.SetFloat(inputXHash, inputX);
        animator.SetFloat(inputYHash, inputY);

        characterController.Move(transform.TransformDirection(new Vector3(inputX, -1, inputY)).normalized * Time.deltaTime * 3);
    }

    public void Interact()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerInteraction.Interact();
        }
    }
}
