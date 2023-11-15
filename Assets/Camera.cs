using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform alvo; // Refer�ncia ao transform do personagem
    public float sensibilidadeMouse = 2f;
    public float rotacaoMinima = -80f; // Limite m�nimo de rota��o
    public float rotacaoMaxima = 80f;  // Limite m�ximo de rota��o

    private Vector3 offset; // Armazena a posi��o inicial relativa � c�mera

    void Start()
    {
        if (alvo == null)
        {
            Debug.LogError("Por favor, atribua o objeto do personagem � vari�vel 'alvo' no Inspector.");
            return;
        }

        // Calcula e armazena a posi��o inicial relativa � c�mera
        offset = transform.position - alvo.position;
    }

    void Update()
    {
        if (alvo == null)
        {
            Debug.LogError("Por favor, atribua o objeto do personagem � vari�vel 'alvo' no Inspector.");
            return;
        }

        // Obt�m o movimento do mouse no eixo horizontal
        float movimentoMouseX = Input.GetAxis("Mouse X");

        // Calcula a rota��o com base no movimento do mouse
        float rotacaoY = movimentoMouseX * sensibilidadeMouse;

        // Rotaciona a c�mera em torno do eixo vertical (up) mantendo a posi��o
        transform.RotateAround(alvo.position, Vector3.up, rotacaoY);

        // Mant�m a posi��o inicial relativa da c�mera em rela��o ao personagem
        transform.position = alvo.position + offset;

        // Limita a rota��o vertical da c�mera
        Vector3 eulerRotation = transform.rotation.eulerAngles;

        // Ajusta a rota��o vertical dentro dos limites
        eulerRotation.x = Mathf.Clamp(eulerRotation.x, rotacaoMinima, rotacaoMaxima);

        // Aplica a rota��o ajustada � c�mera
        transform.rotation = Quaternion.Euler(eulerRotation);
    }
}


