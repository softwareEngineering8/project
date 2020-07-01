using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class SoldierScreen4_table : MonoBehaviour
{
    [SerializeField] Text DepartDate_Text;
    [SerializeField] Text ArriveDate_Text;
    [SerializeField] Text Period_Text;
    [SerializeField] Text VacaKind_Text;
    [SerializeField] Text VacaName_Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSoldierScreen4_table(TempVacation vaca)
    {
        string date_String = vaca.departDate.Year.ToString() + "/" + vaca.departDate.Month.ToString() + "/" + vaca.departDate.Day.ToString();
        DepartDate_Text.text = "DepartDate : " + date_String;

        date_String = vaca.arriveDate.Year.ToString() + "/" + vaca.arriveDate.Month.ToString() + "/" + vaca.arriveDate.Day.ToString();
        ArriveDate_Text.text = "ArriveDate : " + date_String;

        Period_Text.text = "Period : " + vaca.getPeriod().ToString();

        if (vaca.vacaKind == 0)
            VacaKind_Text.text = "VacaKind : General";
        else
            VacaKind_Text.text = "VacaKind : Special";

        if (vaca.vacaKind == 0)//[0]:General [1]:Special
            VacaName_Text.text = "VacaName : -";
        else
            VacaName_Text.text = "VacaKind : " + vaca.vacaName;
    }
}
