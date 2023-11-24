using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    public enum LandStatus
    {
        start, molhado
    }

    public LandStatus landStatus;
    public Material start, molhado;
    new Renderer renderer;
    void Start()
    {
         renderer= gameObject.GetComponent<Renderer>();
        TrocaTerreno(LandStatus.start);
    }

    public void TrocaTerreno(LandStatus statusToSwitch)
    {
        landStatus = statusToSwitch;
        Material materialToSwitch = start; 
        switch(statusToSwitch)
        {
            case LandStatus.start:
                materialToSwitch = start;
                break; 
            case LandStatus.molhado:
                materialToSwitch = molhado;
                break;
        }


        renderer.material = materialToSwitch;
    }

}
