using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInPosition : MonoBehaviour
{
    public GameObject tower;
    public float timer = 2;
    public float current_Time;
    bool isSet = false;

    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (gameObject.activeSelf==true && rb.velocity == Vector3.zero && !isSet)
        {
            transform.localScale *= 2;
            isSet = true;
        }

    }
}
