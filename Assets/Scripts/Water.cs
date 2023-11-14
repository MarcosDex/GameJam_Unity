using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject Fonte;
    void Start()
    {
        SpawnRandomCube();
    }

    void SpawnRandomCube()
    {
        
        
            // Tamanho do terrain
            float terrainWidth = 50f;
            float terrainLength = 50f;
            float terrainHeight = 10f;

            // Gera uma posição aleatória no espaço dentro das dimensões do terrain
            Vector3 spawnPosition = new Vector3(
                Random.Range(-terrainWidth / 2f, terrainWidth / 2f),  // Coordenada X
                Random.Range(0f, terrainHeight),                      // Coordenada Y
                Random.Range(-terrainLength / 2f, terrainLength / 2f) // Coordenada Z
            );

            // Instancia o cubo na posição gerada
            Instantiate(Fonte, spawnPosition, Quaternion.identity);
        

    }
}
