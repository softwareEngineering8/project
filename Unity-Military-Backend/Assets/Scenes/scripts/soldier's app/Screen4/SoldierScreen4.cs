using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Proyecto26;

public class SoldierScreen4 : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] GameObject SoldierScreen4_table;
    [SerializeField] Text allUsedVaca_Text;
    List<GameObject> SoldierScreen4Tables;
    SoldierDataManager sdm = null;
    public class accRejVacations
    {
        public string accepted, rejected;
        public accRejVacations()
        {
            accepted = Screen2.accvac;
            rejected = Screen2.rejvac;
        }
    }
    public static string accvac, rejvac;

    void Start()
    {
        SoldierScreen4Tables = new List<GameObject>();
        
        do
        {
            sdm = SoldierDataManager.sdm;
        } while (sdm == null);

        RestClient.Get<accRejVacations>("https://fir-unity-6f472.firebaseio.com/accRejVacations/.json").Then(response =>
        {
        accRejVacations ar2 = new accRejVacations();
        ar2 = response;

        string[] acomp = ar2.accepted.Split('&');


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


                sdm.vacaList.Add(new TempVacation(acompsplit[0], UnityEngine.Random.Range(0, 2), deprt, arv, 2, "General"));
            }
            Refresh();

        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Refresh()
    {
        int num = SoldierScreen4Tables.Count;
        for (int i = 0; i < num; i++)
        {
            Destroy(SoldierScreen4Tables[0].gameObject);
            SoldierScreen4Tables.RemoveAt(0);
        }
        
        int allvaca = 0;

        GameObject obj;
        RectTransform rt;
        Debug.Log("****"+sdm.vacaList[1].soldierName);
        for (int i = 0; i < sdm.vacaList.Count; i++)
        {
            if (sdm.vacaList[i].usedCheck == 2 &&sdm.soldier.name.Equals(sdm.vacaList[i].soldierName)) // [0]: notUsed  [1]: waiting for Accept [2]: Used
            {
                obj = Instantiate(SoldierScreen4_table, transform);                
                obj.transform.SetParent(content.transform);

                obj.GetComponent<SoldierScreen4_table>().setSoldierScreen4_table(sdm.vacaList[i]);
                SoldierScreen4Tables.Add(obj);

                rt = (RectTransform)obj.transform;
                rt.anchoredPosition = new Vector2(-8, -68f - 114.7f * (SoldierScreen4Tables.Count - 1));

                allvaca += sdm.vacaList[i].getPeriod();
            }
        }

        rt = (RectTransform)content.transform;
        rt.sizeDelta = new Vector2(0, 120f * (SoldierScreen4Tables.Count));

        allUsedVaca_Text.text = "You have used " + allvaca.ToString() + "days of vacation";
    }
}
