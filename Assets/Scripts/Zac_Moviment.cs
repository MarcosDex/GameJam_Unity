using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Zac_Moviment : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform cameraTransform; // Refer�ncia � c�mera
    public float jumpforce = 3.0f;
    public float mass = 3.0f;
    private Rigidbody rigidbody;
    private bool isGround = false;






     void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.mass= mass;
    }



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

        if (!Input.GetKeyDown(KeyCode.Space) || !isGround)
            return;

        //Adicionamos uma for�a ao Rigidbody
        rigidbody.AddForce(
            Vector3.up * jumpforce, //Para fazer o personagem pular, ent�o multiplicamos (0, 1, 0) pelo valor do pulo
            ForceMode.Impulse // Ajustamos a for�a para o tipo Impulse
            );
    }

    //Verifica se o personagem tocou no ch�o
    void OnCollisionEnter(Collision collision)
    {
        isGround = true;
    }

    //Verifica se o personagem saiu do ch�o
    void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }
}


