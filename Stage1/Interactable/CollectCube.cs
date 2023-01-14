using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCube : Interactable
{
    public GameObject particle;

    protected override void Interact()
    {
        Debug.Log("Holding balls");
        Destroy(gameObject);
        Instantiate(particle, transform.position + transform.forward * 2, Quaternion.identity);
        particle.SetActive(true);
    }
}
