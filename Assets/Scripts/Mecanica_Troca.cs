using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanica_Troca : MonoBehaviour
{
    public GameObject objetoOriginal;
    public GameObject novoObjecto;
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            trocarObjeto();
        }
    }

    void trocarObjeto()
    {
        Vector3 posicao = objetoOriginal.transform.position;
        Quaternion rotacao = objetoOriginal.transform.rotation;

        // Destroi o objeto original
        Destroy(objetoOriginal);

        // Instancia o novo objeto na mesma posi��o e rota��o
        GameObject novoObjeto = Instantiate(novoObjecto, posicao, rotacao);

        // Atualiza a refer�ncia do objeto original para o novo objeto
        objetoOriginal = novoObjeto;
    }
}
