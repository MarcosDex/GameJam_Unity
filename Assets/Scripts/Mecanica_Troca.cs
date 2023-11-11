using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanica_Troca : MonoBehaviour
{
    
    // Referência ao script GameManager
    public GameManager GameManager;

    void Start()
    {
        // Exemplo de como obter o valor de seeds
        int valorSeeds = GameManager.seeds;
        Debug.Log("Valor de seeds em OutroScript: " + valorSeeds);
    }

}
