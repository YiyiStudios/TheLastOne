using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public bool state = false;


    public float elapsedtimeBoltA = 0;
    

    public void Use()
    {

        if (name.Equals("Key"))
            UseKey();
        if (name.Equals("Cake"))
            UseCake();
        if (name.Equals("Blue Potion"))
            UseBluePotion();
        if (name.Equals("Clock"))
            UseClock();
        if (name.Equals("Heart"))
            UseHeart();
        if (name.Equals("Green Potion"))
            UseGreenPotion();
        if (name.Equals("Watermelon"))
            UseWatermelon();
        if (name.Equals("BoltA"))
            UseBoltA();
    }

    public void UseKey()
    {
        Debug.Log("Using: " + name);
    }

    public void UseCake()
    {
        StaminaController.instance.reduction = StaminaController.instance.reduction - 10f;
        if (StaminaController.instance.reduction <= 1)
        {
            StaminaController.instance.reduction = 1;
        }
        Debug.Log("Using: " + name);
    }

    public void UseBluePotion()
    {

        Debug.Log("Using: " + name);

    }

    public void UseClock()
    {

        Debug.Log("Using: " + name);

    }

    public void UseHeart()
    {
        StaminaController.instance.reduction = 1;
    }

    public void UseGreenPotion()
    {

        Debug.Log("Using: " + name);

    }

    public void UseWatermelon()
    {
        StaminaController.instance.reduction = StaminaController.instance.reduction - 20f;
        if (StaminaController.instance.reduction <= 1)
        {
            StaminaController.instance.reduction = 1;
        }

        Debug.Log("Using: " + name);

    }

    public void UseBoltA()
    {
        PlayerController.instance.velocity = PlayerController.instance.velocity * 1.5f;
     

        Debug.Log("Using: " + name);
    }


}