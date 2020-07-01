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
    

    public TempVacation(string _soldierName, int _vacaKind, DateTime _departDate, DateTime _arriveDate)
    {
        soldierName = _soldierName;
        vacaKind = _vacaKind;
        departDate = _departDate;
        arriveDate = _arriveDate;
    }

    public int getPeriod()
    {
        TimeSpan period = arriveDate.AddDays(1) - departDate;
        return period.Days;
    }
}
