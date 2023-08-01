using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;



public class CharacterCreationMenu : MonoBehaviour
{
    public GameObject character;
    public List<OutfitChanger> outfitChangers = new List<OutfitChanger>();
    public TextMeshProUGUI totalPriceText;
    public TextMeshProUGUI moneyText;
    public ClothingItem[] items;
    private OutfitChanger purchase;
    public Button submitButton;

    private int totalPrice = 0;
    public Button purchaseButton;
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "Coins:" + PlayerPrefs.GetInt("NumberOfCoins", 0).ToString();
        purchase = GetComponent<OutfitChanger>();
       // submitButton.interactable = false;

    }
    public void RandomizeCharacter()
    {
        foreach(OutfitChanger changer in outfitChangers)
        {
            changer.Randomize();
        }
    }
    void Update()
    {
        CalculateTotalPrice();
        if (PlayerPrefs.GetInt("NumberOfCoins", 0) >= totalPrice)
        {
            purchaseButton.interactable = true;
        }
        else
        {
            purchaseButton.interactable = false;
        }
    }
    // Update is called once per frame
    public void Submit()
    {
        PrefabUtility.SaveAsPrefabAsset(character, "Assets/Player.prefab");
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    public int CalculateTotalPrice()
    {
        totalPrice = 0;

        foreach (OutfitChanger outfit in outfitChangers)
        {
            ClothingItem c = items[outfit.currentOption];
            totalPrice += c.price;
        }

        totalPriceText.text = totalPrice.ToString();

        return totalPrice;
    }
    public void PurchaseOutfit()
    {
        PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) - totalPrice);
        moneyText.text = PlayerPrefs.GetInt("NumberOfCoins", 0).ToString();
        //purchase.Purchase();
        PrefabUtility.SaveAsPrefabAsset(character, "Assets/Player.prefab");
    }
}
