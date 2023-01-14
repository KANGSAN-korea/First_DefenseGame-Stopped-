using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject swapTap;

    private GameObject[] m_players;
    GameObject current_Player;
    [SerializeField]Data charManager;
    Data data;

    private void Start()
    {
        data = charManager;
       // this.m_players = data.s_players;
        foreach (var pl in data.s_players)
        {
            if (pl.activeInHierarchy)
                current_Player = pl;
        }
                 
    }
    private void Update()
    {
        //Debug.Log(current_Player);
    }
    public void OnClickOne()
    { 

            data.s_players[0].SetActive(true);
            current_Player.SetActive(false);
            Debug.Log(data.s_players[0]);
            if (!current_Player.activeInHierarchy)
            {
                current_Player = data.s_players[0];
            }
            swapTap.SetActive(false);

    }
    public void OnClickTwo()
        {
            data.s_players[1].SetActive(true);
            current_Player.SetActive(false);
            Debug.Log(data.s_players[1]);
            if (!current_Player.activeInHierarchy)
            {
                current_Player = data.s_players[1];
            }
            swapTap.SetActive(false);
    }
    public void OnClickThree()
        {
            data.s_players[2].SetActive(true);
            current_Player.SetActive(false);
            Debug.Log(data.s_players[2]);
            if (!current_Player.activeInHierarchy)
            {
                current_Player = data.s_players[2];
            swapTap.SetActive(false);
        }
    }
        public void OnClickFour()
        {
            data.s_players[3].SetActive(true);
            current_Player.SetActive(false);
            Debug.Log(data.s_players[3]);
            if (!current_Player.activeInHierarchy)
            {
                current_Player = data.s_players[3];
            swapTap.SetActive(false);

        }
        }
    }
//현재 플레이어를 어떻게 알 수 잇지?
// Set