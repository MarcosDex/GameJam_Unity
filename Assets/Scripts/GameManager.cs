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
            Debug.Log("Não existem sementes no inventario!");
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
    //            // Adicione aqui o código para criar o novo objeto
    //            CriarNovoObjeto_1();
    //            CriarNovoObjeto_2();
    //        }
    //        else
    //        {
    //            Debug.Log("Você precisa ter mais de uma semente para plantar!");
    //        }
    //    }
    //}
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast para verificar se o objeto original está na linha de visão
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
                        // Adicione aqui o código para criar o novo objeto
                        CriarNovoObjeto_1();
                        CriarNovoObjeto_2();
                    }
                    else
                    {
                        Debug.Log("Você precisa ter mais de uma semente para plantar!");
                    }
                }
                else
                {
                    Debug.Log("Você não está olhando para o objeto original!");
                }
            }
        }
    }

    void CriarNovoObjeto_1()
    {
        // Obtenha a posição, a rotação e a escala do objeto original
        Vector3 posicao = objetoOriginal.transform.position;
        Quaternion rotacao = objetoOriginal.transform.localRotation;
        Vector3 escala = objetoOriginal.transform.localScale;

        // Destrua o objeto original
        Destroy(objetoOriginal);

        // Ajuste a rotação desejada
        Quaternion rotacaoDesejada = Quaternion.Euler(0f, -5.852f, 0f);

        // Instancie o novo objeto na mesma posição, rotação e escala
        GameObject novoObjeto = Instantiate(novoObjecto, posicao, rotacaoDesejada);
        novoObjeto.transform.localScale = escala;

        // Atualize a referência do objeto original para o novo objeto
        objetoOriginal = novoObjeto;

        // Depuração (opcional)
        Debug.Log("Rotação do novo objeto: " + rotacaoDesejada.eulerAngles);
        Debug.Log("Escala do novo objeto: " + novoObjeto.transform.localScale);
    }

    void CriarNovoObjeto_2()
    {
        // Obtenha a posição, a rotação e a escala do objeto original
        Vector3 posicao = objetoOriginal2.transform.position;
        Quaternion rotacao = objetoOriginal2.transform.localRotation;
        Vector3 escala = objetoOriginal2.transform.localScale;

        // Destrua o objeto original
        Destroy(objetoOriginal2);

        // Ajuste a rotação desejada
        Quaternion rotacaoDesejada = Quaternion.Euler(0f, -5.852f, 0f);

        // Instancie o novo objeto na mesma posição, rotação e escala
        GameObject novoObjeto = Instantiate(novoObjecto2, posicao, rotacaoDesejada);
        novoObjeto.transform.localScale = escala;

        // Atualize a referência do objeto original para o novo objeto
        objetoOriginal2 = novoObjeto;

        // Depuração (opcional)
        Debug.Log("Rotação do novo objeto: " + rotacaoDesejada.eulerAngles);
        Debug.Log("Escala do novo objeto: " + novoObjeto.transform.localScale);
    }
}
