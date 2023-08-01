using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public int coins = 1000;
    public GameObject playerpanel;
    public GameObject shoppanel;

    void Awake()
    {
        coins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        moneyText.text = "Coins:" + PlayerPrefs.GetInt("NumberOfCoins", 0).ToString();
    }
    void Start()
    {
        coins = 1000;
    }
    private void OnTriggerEnter2D(Collider2D otherTag)
    {
        if (otherTag.tag == "Shop")
        {
            playerpanel.SetActive(true);
            //TapTC();
        }
    }
    void Update()
    {
        moneyText.text = "Coins:" + PlayerPrefs.GetInt("NumberOfCoins", 0).ToString();
    }
    public void TapTC()
    {
        shoppanel.SetActive(true);
        playerpanel.SetActive(false);
    }

    public void TapTC2()
    {
        SceneManager.LoadScene(1);
    }
}

