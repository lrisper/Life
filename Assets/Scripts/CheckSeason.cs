using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Season")]
public class CheckSeason : ScriptableObject
{

    public Text Winter;
    public Text Spring;
    public Text Summer;
    public Text Fall;

    public int _month { get; private set; }
    public string _season { get; private set; }



    //if (_month == 1 || _month == 11 || _month == 12)
    //{
    //    _season = "Winter";
    //}

    public void Season()
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

    public Text GetWinter()
    {
        return Winter;
    }

    //public Text GetNov()
    //{
    //    return Nov;
    //}

    //public Text GetDec()
    //{
    //    return Dec;
    //}
}

