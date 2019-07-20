using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatManager : MonoBehaviour
{
    [SerializeField] Eat eatText;
    public string FoodName;
    public string FoodDescription;
    public Text FoodCostText;

    Eat eat;

    // Start is called before the first frame update
    void Start()
    {
        eat = eatText;
    }

    // Update is called once per frame
    void Update()
    {
        //eat.AddToFood(FoodName);
    }
}
