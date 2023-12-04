using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class SavingData : MonoBehaviour
{
    public string key_numberOfRound = "NumberOfRound";
    public int numberOfRound;
    public Text roundPlayed;
    // Start is called before the first frame update
    void Start()
    {
        numberOfRound = PlayerPrefs.GetInt(key_numberOfRound);
        if (roundPlayed != null )
        {
            roundPlayed.text = "Round Played: " + numberOfRound.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            LoadData();
        }
    }
    
    public void SaveData()
    {
        numberOfRound++;
        PlayerPrefs.SetInt(key_numberOfRound, numberOfRound);
        PlayerPrefs.Save();
        Debug.Log("Save: " + numberOfRound);
    }
    public void LoadData()
    {
        int num = PlayerPrefs.GetInt(key_numberOfRound);
        Debug.Log("Load num: "+ num);
    }
}
