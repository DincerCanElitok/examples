﻿using UnityEngine;
using System.Collections.Generic;
using TMPro;


public class Player_Progress : MonoBehaviour
{
    private GameObject credit_screen;
    private GameObject star_screen;
    public Material Primary_Mat; 
    public Material Secondary_Mat; 
    public int credit; //currency
    public int dungeonCredit; //x2 credit with ads
    public int star;
    public bool tutorial;
    public List<bool> skills; 
    public int skin; //player skin
    public int day_number=1;
    public string rewardday;
    public int playercan;
    public int reloadUpgradeNumber=1;
    public int healtUpgradeNumber=1;
    public int playerMaxcan;
    public float reloadtime;
    Player_haraket player_Haraket;
    public List<GameObject> ammolist;
    public List<bool> ammoIsOpen;
    public int selectedAmmo;
    P_saldiri p_Saldiri;
    void Awake()
    {
        p_Saldiri = GetComponent<P_saldiri>();
        player_Haraket = GetComponent<Player_haraket>();
    }
    void Start()
    {
        StarCheck();
        CreditCheck();
        SkinCheck();
        AmmoCheck();
    }
    public void CreditCheck()
    {
        credit_screen = GameObject.FindGameObjectWithTag("credit");
        if(credit_screen!=null)
        {
            credit_screen.GetComponent<TMP_Text>().text = credit.ToString();
        }
        
    }
    public void StarCheck()
    {
        star_screen = GameObject.FindGameObjectWithTag("star");
        if (star_screen != null)
        {
            star_screen.GetComponent<TMP_Text>().text = star.ToString();
        }
    }
    public void SkinCheck()
    {
        for(int i=0;i<gameObject.transform.childCount;i++)
        {
            if(gameObject.transform.GetChild(i).tag == "anagemi")
            {
                if (gameObject.transform.GetChild(i) == gameObject.transform.GetChild(skin))
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(true);
                }
                else
                {
                    gameObject.transform.GetChild(i).gameObject.SetActive(false);
                }
            }         
        }
        bool engine_first = false;
        bool atis_first = false;
        //setting alt player game objects to particular player classes
        Transform[] enginesAndAtis = gameObject.transform.GetChild(skin).GetComponentsInChildren<Transform>();
        foreach (Transform child in enginesAndAtis)
        {
            if(child.CompareTag("Engine"))
            {
                if(engine_first==false)
                {
                    player_Haraket.motor1 = child.gameObject;
                    player_Haraket.particle1 = player_Haraket.motor1.GetComponent<ParticleSystem>();
                    engine_first = true;
                }
                else
                {
                    player_Haraket.motor2 = child.gameObject;
                    player_Haraket.particle2 = player_Haraket.motor2.GetComponent<ParticleSystem>();
                    engine_first = false;
                }
                    
            }
            else if(child.tag == "Atis_Nok")
            {
                if(atis_first==false)
                {
                    p_Saldiri.atisnoktasi[0] = child.gameObject;
                    atis_first = true;
                }
                else
                {
                    p_Saldiri.atisnoktasi[1] = child.gameObject;
                    atis_first = false;
                }
            }
        }

    }
    public void AmmoCheck()
    {
        if(selectedAmmo == 0)
        {
            for (int i=0; i < ammolist.Count; i++)
            {
                if (ammolist[i].gameObject == p_Saldiri.mermi)
                    selectedAmmo = i;
            }
        }
        p_Saldiri.mermi = ammolist[selectedAmmo];
    }
}
