﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    PlayerMovement Player;

    private void Start()
    {
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerMovement>();

    }

    private void Update()
    {
        CurrentHealth = PlayerMovement.Health;
       
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
