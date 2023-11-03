using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zac_Moviment : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform cameraTransform; // Refer�ncia � c�mera

    private void Update()
    {
        //Horizontal e Vertical s�o respectivamente Cima e Baixo e Esquerda e Direta/ A  D, W  S
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime;

        transform.Translate(movement);


        if (cameraTransform != null)
        {
            // Mantenha a posi��o da c�mera em rela��o ao personagem
            cameraTransform.position = transform.position + new Vector3(0, 2, -5); 
        }
    }
}