using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Proyecto26;

public class SoldierDataManager : MonoBehaviour
{
    public List<TempVacation> vacaList;
    public TempSoldier soldier;
    public static SoldierDataManager sdm;
    public static string soldnumber;
    // Start is called before the first frame update
    void Start()
    {
        SoldierDataManager.sdm = this;

       

        soldier = new TempSoldier("name","17-721043388","50사단 123연대 5대대", "951027", "010-2890-6812");
        vacaList = new List<TempVacation>();
        DateTime baseDate, departDate, arriveDate;
/*
        for (int i = 0; i < 5; i++)//remain  Specialvacation
        {
            int vacakind = 1;// 0 : generalVacation  1: specialVacation
            baseDate = new DateTime(2020, 1, 1);
            arriveDate = baseDate.AddDays(UnityEngine.Random.Range(3, 7));
            int usedCheck = 0;// 0 : generalVacation  1: waiting for accept 2 : accept , Used vacation 
            string vacationName = "vacationName"+i.ToString();

            vacaList.Add(new TempVacation("soldiername" + i.ToString(), vacakind, baseDate, arriveDate, usedCheck, vacationName));
        }
        */
       /* for (int i=0; i<10;i++)//Used vacation
        {
            int vacakind = UnityEngine.Random.Range(0, 2);// 0 : generalVacation  1: specialVacation
            baseDate = new DateTime(2020, 1, 1);
            departDate = baseDate.AddDays(UnityEngine.Random.Range(0, 350));
            arriveDate = departDate.AddDays(UnityEngine.Random.Range(3, 7));
            int usedCheck = 2;// 0 : generalVacation  1: waiting for accept 2 : accept , Used vacation 
            string vacationName = "vacationName"+(i+5).ToString();

            vacaList.Add(new TempVacation("soldiername"+i.ToString(), vacakind, departDate, arriveDate, usedCheck, vacationName));
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setData()
    {

    }

}

