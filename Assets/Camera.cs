using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform alvo; // Referência ao transform do personagem
    public float sensibilidadeMouse = 2f;
    public float rotacaoMinimaY = -80f; // Limite mínimo de rotação vertical
    public float rotacaoMaximaY = 80f;  // Limite máximo de rotação vertical

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

        // Rotaciona a câmera apenas em torno do eixo Y
        transform.RotateAround(alvo.position, Vector3.up, movimentoMouseX * sensibilidadeMouse);

        // Obtém a rotação vertical atual
        Vector3 eulerRotation = transform.rotation.eulerAngles;

        // Calcula a nova rotação vertical com base no movimento do mouse
        float rotacaoY = -Input.GetAxis("Mouse Y") * sensibilidadeMouse;
        eulerRotation.x = Mathf.Clamp(eulerRotation.x + rotacaoY, rotacaoMinimaY, rotacaoMaximaY);

        // Aplica a rotação ajustada à câmera
        transform.rotation = Quaternion.Euler(eulerRotation);

        // Mantém a posição relativa da câmera em relação ao personagem
        transform.position = alvo.position + offset;
    }
}


