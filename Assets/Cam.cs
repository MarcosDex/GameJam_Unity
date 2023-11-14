using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    public float velocidadeMovimento = 5f;
    public float velocidadeRotacao = 2f;
    public float altura = 2f;
    public float distancia = 5f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Controle de rota��o horizontal
        float mouseX = Input.GetAxis("Mouse X") * velocidadeRotacao;
        transform.Rotate(Vector3.up * mouseX);

        // Controle de rota��o vertical
        float mouseY = Input.GetAxis("Mouse Y") * velocidadeRotacao;
        altura -= mouseY;
        altura = Mathf.Clamp(altura, 1f, 5f);

        // Movimenta��o do jogador
        float movimentoFrente = Input.GetAxis("Vertical") * velocidadeMovimento * Time.deltaTime;
        float movimentoLado = Input.GetAxis("Horizontal") * velocidadeMovimento * Time.deltaTime;

        transform.Translate(Vector3.forward * movimentoFrente);
        transform.Translate(Vector3.right * movimentoLado);

        // Atualiza a posi��o da c�mera em rela��o ao jogador
        Vector3 posicaoDesejada = transform.position - transform.forward * distancia + Vector3.up * altura;
        transform.position = Vector3.Lerp(transform.position, posicaoDesejada, Time.deltaTime * 10f);

        // Faz com que a c�mera olhe para o jogador
        transform.LookAt(transform.position + transform.forward * 5f);
    }

}


