using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Screen2_vacation_Button : MonoBehaviour
{
    Screen2 scr2;
    string name;
    DateTime departDate;
    DateTime arriveDate;
    int vacakind;
    int vacaApplyKind;

    [SerializeField] Text text_name;
    [SerializeField] Text text_departDate;
    [SerializeField] Text text_arriveDate;
    [SerializeField] Text text_vacaKind;
    [SerializeField] Image img_vacaApplyKind;
    [SerializeField] Text text_Datelen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setButton(Screen2 _scr2, string _name, DateTime _departDate, DateTime _arriveDate, int _vacaKind, int _vacaApplyKind)
    {
        scr2 = _scr2;
        name = _name;
        departDate = _departDate;
        arriveDate = _arriveDate;
        vacakind = _vacaKind;
        vacaApplyKind = _vacaApplyKind;

        text_name.text = "ID : " + name;
        text_departDate.text = (departDate.Year + "/" + departDate.Month + "/" + departDate.Day);
        text_arriveDate.text = (arriveDate.Year + "/" + arriveDate.Month + "/" + arriveDate.Day);
        TimeSpan dateDiff= arriveDate - departDate;
        text_Datelen.text = "Period : " + dateDiff.Days + "days";
        if (vacakind == 0)        
            text_vacaKind.text = "Vacakind : GeneralVacation";
        else
            text_vacaKind.text = "Vacakind : SpeicalVacation";

        if (vacaApplyKind == 0)
        {
            img_vacaApplyKind.color = new Color(0.078f,0.568f,1f);
            img_vacaApplyKind.transform.GetChild(0).GetComponent<Text>().text = "New";
        }            
        else
        {
            img_vacaApplyKind.color = new Color(1f, 0.403f, 0.364f);
            img_vacaApplyKind.transform.GetChild(0).GetComponent<Text>().text = "Cancelled";
        }
            
    }


    public void onclick()
    {
        scr2.buttonCheck(transform.GetComponent<Button>());
    }
}
