using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public delegate void SendUpdateUI();
    public static event SendUpdateUI OnSendUpdateUI;

    public delegate void SendSetupEvent();
    public static event SendSetupEvent OnSendSetupEvent;

    // think about using a delegate to call month and season
    int _health;
    int _food;
    int _day;
    int _money;

    int _lowFood = 10;

    int _maxHealth = 100;
    int _maxFood = 100;

    int _week = 7;
    int _month = 30;
    int _year = 365;

    int _numberOfDays;
    int _numberOfWeeks;
    int _numberOfMonths;
    int _numberOfYears;

    float _hideMsgTimer = 2f;

    string _season;

    List<string> monthsWith31Days = new List<string>();

    public Text HealthText;
    public Text FoodText;
    public Text DayText;
    public Text MoneyText;
    public Text MsgText;
    public Text SeasonText;


    public Slider HealthSlider;
    public Slider FoodSlider;

    public GameObject MsgBox;
    public GameObject DeathBox;
    public GameObject ItemBox;
    public GameObject ItemBox2;



    public void AddToHealth(int value)
    {
        _health += value;
    }

    public void AddToFood(int value)
    {
        _food += value;
    }

    public void DisplayMsg(string value)
    {
        MsgText.text = value;
        MsgBox.SetActive(true);
        Invoke("HideMsg", _hideMsgTimer);

    }

    public void HideMsg()
    {
        MsgBox.SetActive(false);
        ItemBox.SetActive(true);
        ItemBox2.SetActive(true);
    }

    public bool BuyItem(int value)
    {
        if (_money + value < 0)
        {
            DisplayMsg("Not enough money");
            ItemBox.SetActive(false);
            ItemBox2.SetActive(false);
            return false;
        }
        _money += value;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupGame();
        monthsWith31Days.Add("Jan");
        monthsWith31Days.Add("May");
        monthsWith31Days.Add("Jul");
        monthsWith31Days.Add("Oct");
        monthsWith31Days.Add("Dec");
    }

    public void UpdateUI()
    {
        _day += 1;

        if (OnSendUpdateUI != null)
        {
            OnSendUpdateUI();
        }

        CheckSeason();
        CheckMonth(_month.ToString());
        CheckForHunger();
        ClampFood();

        HealthText.text = "Health: " + _health;
        FoodText.text = "Food: " + _food;
        MoneyText.text = "Money: " + _money;
        SeasonText.text = "Season: " + _season;


        _numberOfDays += 1;

        if (_day < _week)
        {
            //_numberOfDays += 1;
            DayText.text = "Day: " + _day;
        }
        else if (_day >= _week)
        {
            _numberOfWeeks = 1;
            if (_day >= 14)
            {
                _numberOfWeeks = 2;
            }
            if (_day >= 21)
            {
                _numberOfWeeks = 3;
            }
            if (_day >= 28)
            {
                _numberOfWeeks = 4;
            }
            if (_day >= _month)
            {
                _numberOfWeeks = 5;
            }
            DayText.text = "Week: " + _numberOfWeeks + "Day" + _day;
        }

        if (_day == _month)
        {
            _numberOfMonths = 1;
            DayText.text = "Month: " + _numberOfMonths + "Day: " + _day;
        }
        else if (_day >= _month)
        {
            _numberOfMonths = 1;
            if (_day >= _month)
            {
                _numberOfMonths = 1;
            }
            if (_day >= _month * 2)
            {
                _numberOfMonths = 2;
            }
            if (_day >= _month * 3)
            {
                _numberOfMonths = 3;
            }
            if (_day >= _month * 4)
            {
                _numberOfMonths = 4;
            }
            if (_day >= _month * 5)
            {
                _numberOfMonths = 5;
            }
            if (_day >= _month * 6)
            {
                _numberOfMonths = 6;
            }
            if (_day >= _month * 7)
            {
                _numberOfMonths = 7;
            }
            if (_day >= _month * 8)
            {
                _numberOfMonths = 8;
            }
            if (_day >= _month * 9)
            {
                _numberOfMonths = 9;
            }
            if (_day >= _month * 10)
            {
                _numberOfMonths = 10;
            }
            if (_day >= _month * 11)
            {
                _numberOfMonths = 11;
            }
            if (_day >= _month * 12)
            {
                _numberOfMonths = 12;
            }

            DayText.text = "Month: " + _numberOfMonths + "Day: " + _day;
        }

        if (_day == _year)
        {
            _numberOfYears++;
            DayText.text = "Year: " + _numberOfYears + "Day" + _day;
        }
        else if (_day >= _year)
        {
            _numberOfYears = 1;
            DayText.text = "Year: " + _numberOfYears + "Day" + _day;
        }


        HealthSlider.value = _health;
        FoodSlider.value = _food;
    }

    public void CheckSeason()
    {
        if (_month == 1 || _month == 11 || _month == 12)
        {
            _season = "Winter";
            //SeasonText.text = CheckSeason();
        }
        if (_month == 2 || _month == 3 || _month == 4)
        {
            _season += "Spring";
        }
        if (_month == 5 || _month == 6 || _month == 7)
        {
            _season = "Summer";
        }
        if (_month == 8 || _month == 9 || _month == 10)
        {
            _season = "Fall";
        }
    }

    public void CheckMonth(string value)
    {

        if (_month == 1 || _month == 5 || _month == 7 || _month == 10 || _month == 12)
        {
            // 31 days in the month
            foreach (string month in monthsWith31Days)
            {
                if (month == monthsWith31Days[0])
                {
                    SeasonText.text = "Winter";
                    print(_month.ToString());
                }
                if (month == monthsWith31Days[1])
                {
                    SeasonText.text = "Spring";
                    print(_month.ToString());
                }
                if (month == monthsWith31Days[2])
                {
                    SeasonText.text = "Summer";
                    print(_month.ToString());
                }
                if (month == monthsWith31Days[3])
                {
                    SeasonText.text = "Fall";
                    print(_month.ToString());
                }
                if (month == monthsWith31Days[4])
                {
                    SeasonText.text = "Winter";
                    print(_month.ToString());
                }
                print(_month.ToString());
            }
            print(_month.ToString());
        }

        if (_month == 2 || _month == 6 || _month == 9)
        {
            // 28 days in the month
        }
        if (_month == 4 || _month == 8)
        {
            // 30 days in the month
        }
        if (_month == 3 || _month == 11)
        {
            // 29 days in the month
        }
    }

    public void ClampFood()
    {
        if (_food > _maxFood)
        {
            _food = _maxFood;
        }
        if (_food <= _lowFood)
        {
            DisplayMsg("Your food is low you should eat something");
            ItemBox.SetActive(false);
            ItemBox2.SetActive(false);
        }

        if (_food <= 0)
        {
            _food = 0;
            _health -= 2;
        }
    }

    public void CheckForHunger()
    {
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        if (_health <= 0)
        {
            _health = 0;

            YouDied();
        }
    }

    public void YouDied()
    {
        DeathBox.SetActive(true);
    }

    public void SetupGame()
    {
        //OnSendSetupEvent?.Invoke();

        if (OnSendSetupEvent != null)
        {
            OnSendSetupEvent();
        }


        HealthSlider.maxValue = _maxHealth;
        FoodSlider.maxValue = _maxFood;

        _health = _maxHealth;
        _food = _maxFood;

        _day = 0;
        _money = 0;
        _season = "";// finish addeding seasons 
        DeathBox.SetActive(false);
        MsgBox.SetActive(false);
        UpdateUI();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

