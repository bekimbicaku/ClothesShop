using UnityEngine;
[System.Serializable]

[CreateAssetMenu(fileName = "New Clothing Item", menuName = "Clothing Item")]
public class ClothingItem : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int price;
    public bool isUnlocked;
   // public GameObject clothingPrefab; // The sprite or 2D representation of the clothing item to be worn by the player character.
    //public bool isEquipped;
}
