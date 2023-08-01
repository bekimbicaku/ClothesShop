using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 3, 0 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) + 5);
            Destroy(gameObject); // This destroys things;
        }
    }
}
