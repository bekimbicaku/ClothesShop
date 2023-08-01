using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OutfitChanger : MonoBehaviour
{
    [Header("Sprite to Change")]
    public SpriteRenderer bodyPart;

    [Header("Sprite to Cycle Through")]
    public List<Sprite> options = new List<Sprite>();
    public ClothingItem[] items;

    public int currentOption = 0;
    public Image lockImage;
    public Image outfitImage;


    public TextMeshProUGUI priceText;
    // Start is called before the first frame update

    void Start()
    {
        foreach(ClothingItem item in items)
        {
            if (item.price == 0)
                item.isUnlocked = true;
            else
                item.isUnlocked = PlayerPrefs.GetInt(item.name, 0) == 0 ? false : true;
        }
        currentOption = PlayerPrefs.GetInt("SelectedOutfit", 0);
        outfitImage.sprite = options[currentOption];
        ClothingItem c = items[currentOption];
        priceText.text = "Price: " + c.price;

    }
    public void NextOption()
    {
        ClothingItem c = items[currentOption];
        currentOption++;
        if(currentOption >= options.Count)
        {
            currentOption = 0;
        }
        bodyPart.sprite = options[currentOption];
        outfitImage.sprite = options[currentOption];
        priceText.text = "Price: " + c.price;
        
        if (!c.isUnlocked)
            return;
        PlayerPrefs.SetInt("SelectedOutfit", currentOption);
    }

    // Update is called once per frame
    public void PreviousOption()
    {
        ClothingItem c = items[currentOption];
        currentOption--;
        if (currentOption <= options.Count)
        {
            currentOption = 0;
        }
        bodyPart.sprite = options[currentOption];
        outfitImage.sprite = options[currentOption];
        priceText.text = "Price: " + c.price;

        if (!c.isUnlocked)
            return;
        PlayerPrefs.SetInt("SelectedOutfit", currentOption);
    }
    public void Randomize()
    {
        currentOption = Random.Range(0, options.Count - 1);
        bodyPart.sprite = options[currentOption];

    }
    public void UnlockOutfit()
    {
        ClothingItem c = items[currentOption];
        c.price = 0;
        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("SelectedOutfit", currentOption);
        c.isUnlocked = true;
        PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) - c.price);
    }
    private void UpdateUI()
    {
        ClothingItem c = items[currentOption];
        if (c.isUnlocked)
        {
            lockImage.gameObject.SetActive(false);
            priceText.text = "Unlocked";
        }
        else
        {
            lockImage.gameObject.SetActive(true);
            priceText.text = "Price: " + c.price;
        }
    }
    public void Purchase()
    {
        UnlockOutfit();
        UpdateUI();
    }
}
