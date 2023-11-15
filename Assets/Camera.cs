using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform alvo; // Referência ao transform do personagem
    public float sensibilidadeMouse = 2f;
    public float rotacaoMinima = -80f; // Limite mínimo de rotação
    public float rotacaoMaxima = 80f;  // Limite máximo de rotação

    private Vector3 offset; // Armazena a posição inicial relativa à câmera

    void Start()
    {
        if (alvo == null)
        {
            Debug.LogError("Por favor, atribua o objeto do personagem à variável 'alvo' no Inspector.");
            return;
        }

        // Calcula e armazena a posição inicial relativa à câmera
        offset = transform.position - alvo.position;
    }

    void Update()
    {
        if (alvo == null)
        {
            Debug.LogError("Por favor, atribua o objeto do personagem à variável 'alvo' no Inspector.");
            return;
        }

        // Obtém o movimento do mouse no eixo horizontal
        float movimentoMouseX = Input.GetAxis("Mouse X");

        // Calcula a rotação com base no movimento do mouse
        float rotacaoY = movimentoMouseX * sensibilidadeMouse;

        // Rotaciona a câmera em torno do eixo vertical (up) mantendo a posição
        transform.RotateAround(alvo.position, Vector3.up, rotacaoY);

        // Mantém a posição inicial relativa da câmera em relação ao personagem
        transform.position = alvo.position + offset;

        // Limita a rotação vertical da câmera
        Vector3 eulerRotation = transform.rotation.eulerAngles;

        // Ajusta a rotação vertical dentro dos limites
        eulerRotation.x = Mathf.Clamp(eulerRotation.x, rotacaoMinima, rotacaoMaxima);

        // Aplica a rotação ajustada à câmera
        transform.rotation = Quaternion.Euler(eulerRotation);
    }
}


