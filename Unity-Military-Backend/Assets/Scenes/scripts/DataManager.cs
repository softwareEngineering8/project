using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Proyecto26;

public class DataManager : MonoBehaviour
{
    public static DataManager dm = null;
    public List<TempVacation> vacaList;
    public class accRejVacations
    {
        public string accepted, rejected;
        public accRejVacations()
        {
            accepted = DataManager.accvac;
            rejected = DataManager.rejvac;
        }
    }
    public static string accvac, rejvac;
    public accRejVacations ar22;


    // Start is called before the first frame update
    void Start()
    {
        dm = transform.GetComponent<DataManager>();

        vacaList = new List<TempVacation>();


        /*RestClient.Get<accRejVacations>("https://fir-unity-6f472.firebaseio.com/accRejVacations/.json").Then(response2 =>
        {
            accRejVacations ar2 = new accRejVacations();
            ar2 = response2;
            Debug.Log("--_--"+ar2.accepted);

           


        });*/
        /*
        string[] acomp = ar22.accepted.Split('&');


        for (int i = 1; i < acomp.Length; i++)
        {

            string[] acompsplit = acomp[i].Split(';');
            DateTime baseDate = new DateTime(2020, 1, 1);
            string formatString = "yyyy##MM##dd";



            DateTime deprt = new DateTime();
            DateTime arv = new DateTime();


            deprt = DateTime.ParseExact(acompsplit[1], formatString, null);
            arv = DateTime.ParseExact(acompsplit[2], formatString, null);

            Debug.Log("++" + acompsplit[0]);

            //DateTime randDepartDate = baseDate.AddDays(UnityEngine.Random.Range(0, 360));
            //DateTime randDepartDate = new DateTime(2020, month, day);

            /* int randPeriod = UnityEngine.Random.Range(3, 6);
             DateTime randArriveDate = randDepartDate.AddDays(randPeriod);
             int vacaKind = UnityEngine.Random.Range(0, 2);
             */
           // vacaList.Add(new TempVacation(acompsplit[0], UnityEngine.Random.Range(0, 2), deprt, arv));
        //}


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}