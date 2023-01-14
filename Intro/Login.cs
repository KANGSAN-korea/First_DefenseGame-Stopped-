using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public GameObject ide;
    public GameObject pwe;
    Text id;
    Text pw;

    private void Start()
    {
        id = ide.GetComponent<Text>();
        pw = pwe.GetComponent<Text>();
    }
    public void Onclick()
    {
        if(id.text == "kangsan" && pw.text == "1234")
        {
            SceneManager.LoadScene("Stage1");
        }
    }
}
