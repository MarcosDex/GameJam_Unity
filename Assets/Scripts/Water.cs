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

    async void SpawnRandomCube()
    {
        
        
            // Tamanho do terrain
            float terrainWidth = 49f;
            float MaxX = 49f; // colocando o maxio do eixo x para ser gerado o maior limite do mapa 
            float MinX = 1.0f; // colocando o minimo do eixo x para ser gerado o menor limite do mapa 
            float terrainLength = 50f;
            float terrainHeight = -0.4f;


            // Gera uma posição aleatória no espaço dentro das dimensões do terrain
            Vector3 spawnPosition = new Vector3(
                Random.Range(MaxX, MinX),  // Coordenada X
                Random.Range(0f, terrainHeight),                      // Coordenada Y
                Random.Range(terrainLength / 2f, terrainLength / 2f) // Coordenada Z
            );

            // Instancia o cubo na posição gerada
            Instantiate(Fonte, spawnPosition, Quaternion.identity);
        

    }
}
