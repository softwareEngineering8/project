using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen1_Button : MonoBehaviour
{
    public string num;
    public string name;
    string affiliation;
    Screen1 scr1;
    [SerializeField] Text soldierNum_Txt;
    [SerializeField] Text soldierName_Txt;
    

    public void setButton(string _num, string _name, string _affiliation, Screen1 _scr1)
    {
        num = _num;
        name = _name;
        affiliation = _affiliation;
        scr1 = _scr1;

        soldierNum_Txt.text = num;
        soldierName_Txt.text = name;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void onclick()
    {
        scr1.soldierButtonClick(num);
    }
}
