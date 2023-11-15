using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform alvo; // Refer�ncia ao transform do personagem
    public float sensibilidadeMouse = 2f;
    public float rotacaoMinimaY = -80f; // Limite m�nimo de rota��o vertical
    public float rotacaoMaximaY = 80f;  // Limite m�ximo de rota��o vertical

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

        // Rotaciona a c�mera apenas em torno do eixo Y
        transform.RotateAround(alvo.position, Vector3.up, movimentoMouseX * sensibilidadeMouse);

        // Obt�m a rota��o vertical atual
        Vector3 eulerRotation = transform.rotation.eulerAngles;

        // Calcula a nova rota��o vertical com base no movimento do mouse
        float rotacaoY = -Input.GetAxis("Mouse Y") * sensibilidadeMouse;
        eulerRotation.x = Mathf.Clamp(eulerRotation.x + rotacaoY, rotacaoMinimaY, rotacaoMaximaY);

        // Aplica a rota��o ajustada � c�mera
        transform.rotation = Quaternion.Euler(eulerRotation);

        // Mant�m a posi��o relativa da c�mera em rela��o ao personagem
        transform.position = alvo.position + offset;
    }
}


