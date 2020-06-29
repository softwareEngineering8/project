using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen1_Button : MonoBehaviour
{
    string num;
    string name;
    string affiliation;
    Screen1 scr1;

    public void setButton(string _num, string _name, string _affiliation, Screen1 _scr1)
    {
        num = _num;
        name = _name;
        affiliation = _affiliation;
        scr1 = _scr1;
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
