using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interagir : MonoBehaviour
{
    CharacterController playerController;
    

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
    }
}
