using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{


    public string ItemDescription;
    string RequirementString;
    GameManager gameManager;
    int RentalDaysRemaining;

    public int AddToHealth;
    public int AddToFood;
    public int AddToMoney;
    public int RentalDays;

    public Text ItemDescriptionText;
    public Text ItemCostText;

    public bool Purchased;
    public bool OneTimePurchase;

    public List<Item> Requirements;

    private void OnEnable()
    {
        GameManager.OnSendUpdateUI += UpdateItem;
        GameManager.OnSendSetupEvent += SetupItem;
    }

    private void OnDisable()
    {
        GameManager.OnSendUpdateUI -= UpdateItem;
        GameManager.OnSendSetupEvent -= SetupItem;
    }

    void SetupItem()
    {
        Purchased = false;
    }

    void UpdateItem()
    {
        if (RentalDays > 0 && Purchased)
        {
            RentalDaysRemaining -= 1;

            if (RentalDaysRemaining == 0)
            {
                Purchased = false;
            }
        }
    }

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ItemDescriptionText.text = ItemDescription;
        ItemCostText.text = (AddToMoney.ToString());
    }


    public bool CheckRequirements()
    {
        bool PassedRequirements = true;
        RequirementString = "Requirements: ";
        string Comma = "";
        foreach (Item currentItem in Requirements)
        {
            if (!currentItem.Purchased)
            {
                PassedRequirements = false;
                RequirementString += Comma + currentItem.ItemDescription;
                Comma = ", ";
            }
        }
        return PassedRequirements;
    }

    public void ProcessItem()
    {
        if (OneTimePurchase && Purchased)
        {
            gameManager.DisplayMsg("You already own this item. ");
            gameManager.ItemBox.SetActive(false);
            gameManager.ItemBox2.SetActive(false);
            return;
        }

        if (!CheckRequirements())
        {
            gameManager.DisplayMsg("You Dont meet all the requirements. " + RequirementString);
            gameManager.ItemBox.SetActive(false);
            gameManager.ItemBox2.SetActive(false);
            return;
        }

        if (gameManager.BuyItem(AddToMoney))
        {
            gameManager.AddToFood(AddToFood);
            gameManager.AddToHealth(AddToHealth);
            Purchased = true;
            if (RentalDays > 0)
            {
                RentalDaysRemaining = RentalDays;
            }
            gameManager.UpdateUI();
        }

    }
}
