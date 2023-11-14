using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Zac_Moviment : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpforce = 3.0f;
    public float mass = 3.0f;
    public float sensitivity = 2.0f; // Sensibilidade do mouse
    private Rigidbody rigidbody;
    private bool isGround = false;
    private float rotationX = 0.0f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.mass = mass;

        // Bloquear e esconder o cursor do mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Movimentação do jogador
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Rotação da câmera com o mouse
        RotateWithMouse();

        // Pulo do jogador
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rigidbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }

    void RotateWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotação horizontal do corpo do jogador
        transform.Rotate(Vector3.up * mouseX * sensitivity);

        // Rotação vertical da câmera, limitando o ângulo
        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, 20.0f, 20.0f);
    }

    // Verifica se o personagem tocou no chão
    void OnCollisionEnter(Collision collision)
    {
        isGround = true;
    }

    // Verifica se o personagem saiu do chão
    void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }
}
