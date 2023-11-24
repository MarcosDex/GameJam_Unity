using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int seeds;
    public Text SeedsTxt;
    public GameObject objetoOriginal;
    public GameObject novoObjecto;
    public GameObject objetoOriginal2;
    public GameObject novoObjecto2;
    void Start()
    {
        UpdateSeedsTxt();
    }

    public void AddSeed (int amount)
    {
        seeds += amount;
        UpdateSeedsTxt();
    }

    public void GastarSemente(int amount)
    {
        
        if (seeds >= amount)
        {
            seeds -= amount;
            UpdateSeedsTxt();
        }
        else
        {
            Debug.Log("N�o existem sementes no inventario!");
        }
    }
    private void UpdateSeedsTxt()
    {
        SeedsTxt.text = "Sementes: " + seeds.ToString();
    }

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        // Verifica se o jogador tem mais de uma semente antes de gastar
    //        if (seeds >= 1)
    //        {
    //            GastarSemente(1);
    //            // Adicione aqui o c�digo para criar o novo objeto
    //            CriarNovoObjeto_1();
    //            CriarNovoObjeto_2();
    //        }
    //        else
    //        {
    //            Debug.Log("Voc� precisa ter mais de uma semente para plantar!");
    //        }
    //    }
    //}
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast para verificar se o objeto original est� na linha de vis�o
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == objetoOriginal)
                {
                    // Verifica se o jogador tem mais de uma semente antes de gastar
                    if (seeds >= 1)
                    {
                        GastarSemente(1);
                        // Adicione aqui o c�digo para criar o novo objeto
                        CriarNovoObjeto_1();
                        CriarNovoObjeto_2();
                    }
                    else
                    {
                        Debug.Log("Voc� precisa ter mais de uma semente para plantar!");
                    }
                }
                else
                {
                    Debug.Log("Voc� n�o est� olhando para o objeto original!");
                }
            }
        }
    }

    void CriarNovoObjeto_1()
    {
        // Obtenha a posi��o, a rota��o e a escala do objeto original
        Vector3 posicao = objetoOriginal.transform.position;
        Quaternion rotacao = objetoOriginal.transform.localRotation;
        Vector3 escala = objetoOriginal.transform.localScale;

        // Destrua o objeto original
        Destroy(objetoOriginal);

        // Ajuste a rota��o desejada
        Quaternion rotacaoDesejada = Quaternion.Euler(0f, -5.852f, 0f);

        // Instancie o novo objeto na mesma posi��o, rota��o e escala
        GameObject novoObjeto = Instantiate(novoObjecto, posicao, rotacaoDesejada);
        novoObjeto.transform.localScale = escala;

        // Atualize a refer�ncia do objeto original para o novo objeto
        objetoOriginal = novoObjeto;

        // Depura��o (opcional)
        Debug.Log("Rota��o do novo objeto: " + rotacaoDesejada.eulerAngles);
        Debug.Log("Escala do novo objeto: " + novoObjeto.transform.localScale);
    }

    void CriarNovoObjeto_2()
    {
        // Obtenha a posi��o, a rota��o e a escala do objeto original
        Vector3 posicao = objetoOriginal2.transform.position;
        Quaternion rotacao = objetoOriginal2.transform.localRotation;
        Vector3 escala = objetoOriginal2.transform.localScale;

        // Destrua o objeto original
        Destroy(objetoOriginal2);

        // Ajuste a rota��o desejada
        Quaternion rotacaoDesejada = Quaternion.Euler(0f, -5.852f, 0f);

        // Instancie o novo objeto na mesma posi��o, rota��o e escala
        GameObject novoObjeto = Instantiate(novoObjecto2, posicao, rotacaoDesejada);
        novoObjeto.transform.localScale = escala;

        // Atualize a refer�ncia do objeto original para o novo objeto
        objetoOriginal2 = novoObjeto;

        // Depura��o (opcional)
        Debug.Log("Rota��o do novo objeto: " + rotacaoDesejada.eulerAngles);
        Debug.Log("Escala do novo objeto: " + novoObjeto.transform.localScale);
    }
}
