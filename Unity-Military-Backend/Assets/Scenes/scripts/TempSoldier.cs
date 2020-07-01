using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSoldier
{
    public string name;
    public string soldierNum;
    public string affiliation;
    public string birth;
    public string phone;

    public TempSoldier(string _name, string _soldierNum, string _affiliation, string _birth, string _phone)
    {
        name = _name;
        soldierNum = _soldierNum;
        affiliation = _affiliation;
        birth = _birth;
        phone = _phone;
    }

    public void SetSoldier(string _name, string _soldierNum, string _affiliation, string _birth, string _phone)
    {
        name = _name;
        soldierNum = _soldierNum;
        affiliation = _affiliation;
        birth = _birth;
        phone = _phone;
    }
}