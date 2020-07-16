﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    private Button shootBtn;
    [SerializeField]
    private GameObject needle;
    private GameObject[] gameNeedles;
    [SerializeField]
    private int howManyNeedles;
    private float needleDistance = 0.5f;
    private int needleIndex;


    // Awake is called when the script instance is being looaded
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        GetButton();
    }

    // Update is called once per frame
    void Start()
    {
        CreateNeedles();
    }

    void GetButton()
    {
        shootBtn = GameObject.Find("Shoot Button").GetComponent<Button>();
        shootBtn.onClick.AddListener(() => ShootTheNeedle());
    }

    public void ShootTheNeedle()
    {
        gameNeedles[needleIndex].GetComponent<NeedleMovementScript>().FireTheNeedle();
        needleIndex++;
        if(needleIndex == gameNeedles.Length)
        {
            shootBtn.onClick.RemoveAllListeners();
        }

    }

    void CreateNeedles()
    {
        gameNeedles = new GameObject[howManyNeedles];
        Vector3 temp = transform.position;
        for (int i = 0; i < gameNeedles.Length; i++)
        {
            gameNeedles[i] = Instantiate(needle, temp, Quaternion.identity) as GameObject;
            temp.y -= needleDistance;
        }
    }

    public void InstantiateNeedle()
    {
        Instantiate(needle, transform.position, Quaternion.identity);
    }
}
