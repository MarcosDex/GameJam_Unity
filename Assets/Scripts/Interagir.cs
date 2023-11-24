using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interagir : MonoBehaviour
{
    CharacterController playerController;
    Land selectedLand = null;

    void Start()
    {
        playerController = transform.parent.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            onInteract(hit);
        }
    }

    void onInteract(RaycastHit hit)
    {
        Debug.Log(hit);
        Collider other = hit.collider;
        Debug.Log(other);

        if (other.tag == "Land")
        {
            Land land = other.GetComponent<Land>();
            Select(land);
            return;
           
        }

        if(selectedLand != null)
        {
            selectedLand.Select(false);
            selectedLand = null;
        }
    }

    void Select(Land land)
    {
        if(selectedLand != null)
        {
            selectedLand.Select(false);
        }
        selectedLand= land;
        land.Select(true);
    }

    public void Interact()
    {
        if(selectedLand != null)
        {
            selectedLand.Interact();
            return;
        }
        Debug.Log("Não esta em bloco interagivel");
    }
}
