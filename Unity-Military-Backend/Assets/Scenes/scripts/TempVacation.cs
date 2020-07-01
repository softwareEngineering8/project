using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TempVacation
{
    public string soldierName;
    public int vacaKind;
    public DateTime departDate;
    public DateTime arriveDate;
    public int usedCheck; //0:unUsed, 1:Used
    public string vacaName;


    public TempVacation(string _soldierName, int _vacaKind, DateTime _departDate, DateTime _arriveDate, int _usedCheck, string _vacaName)
    {
        soldierName = _soldierName;
        vacaKind = _vacaKind;
        departDate = _departDate;
        arriveDate = _arriveDate;
        usedCheck = _usedCheck;
        vacaName = _vacaName;
    }

    public int getPeriod()
    {
        TimeSpan period = arriveDate.AddDays(1) - departDate;
        return period.Days;
    }
}
