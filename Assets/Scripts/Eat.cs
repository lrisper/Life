using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Eat")]
public class Eat : ScriptableObject
{
    public string FoodName;
    [TextArea(10, 14)] public string FoodDescription;
    public Text FoodCostText;

    public int AddToHealth;
    public int AddToFood;
    public int AddToMoney;


}
