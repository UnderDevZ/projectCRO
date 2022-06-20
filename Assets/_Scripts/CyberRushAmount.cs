using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CyberRushAmount : MonoBehaviour
{
    private Image RushBar;
    public float CoinAmount;
    public float MaxCoin = 50f;
    PlayerMovement player;

    private void Start()
    {
        RushBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        CoinAmount = PlayerMovement.CoinCount;
        RushBar.fillAmount = CoinAmount / MaxCoin; 
    }



}
