using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyFIrst : MonoBehaviour
{
    public GameObject agreement;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            agreement.SetActive(true);
        }
    }
}
