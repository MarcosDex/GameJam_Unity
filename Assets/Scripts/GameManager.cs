using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int seeds;
    public Text SeedsTxt; 
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

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Chama a fun��o para gastar uma semente
            GastarSemente(1);
            UpdateSeedsTxt();
        }
    }
}
