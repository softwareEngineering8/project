using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Proyecto26;

public class Screen3 : MonoBehaviour
{
    int week;
    DateTime baseDate = new DateTime(2019, 12, 31);
    DateTime startDate;
    DateTime endDate;
    List<GameObject> tableList;
    [SerializeField] Text[] date_Texts;
    [SerializeField] Text inputWeek;
    [SerializeField] Text weekText;
    [SerializeField] GameObject tableObject;
    [SerializeField] GameObject tablePanel;
    [SerializeField] GameObject tableResult;
    public List<TempVacation> vacaList;


   // public DataManager dm = new DataManager();
    public class accRejVacations
    {
        public string accepted, rejected;
        public accRejVacations()
        {
            accepted = Screen3.accvac;
            rejected = Screen3.rejvac;
        }
    }
    public static string accvac, rejvac;

    int[] daycount = new int[14];

    // Start is called before the first frame update
    void Start()
    {
        tableList = new List<GameObject>();
        vacaList = new List<TempVacation>();
        RestClient.Get<accRejVacations>("https://fir-unity-6f472.firebaseio.com/accRejVacations/.json").Then(response2 =>
        {

            accRejVacations ar2 = new accRejVacations();
            ar2 = response2;
           
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

                startDate = deprt;
                endDate = arv;

                Debug.Log("++" + acompsplit[0]);

                //DateTime randDepartDate = baseDate.AddDays(UnityEngine.Random.Range(0, 360));
                //DateTime randDepartDate = new DateTime(2020, month, day);

                /* int randPeriod = UnityEngine.Random.Range(3, 6);
                 DateTime randArriveDate = randDepartDate.AddDays(randPeriod);
                 int vacaKind = UnityEngine.Random.Range(0, 2);
                 */
                vacaList.Add(new TempVacation(acompsplit[0], UnityEngine.Random.Range(0, 2), deprt, arv));
            }
          


            //yield on a new YieldInstruction that waits for 5 seconds.

            DateSet(24);
        });      /*do
        {
            dm = DataManager.dm;
            //yield return new WaitForSeconds(5);
        } while (DataManager.dm == null);//get Data*/

    }


   
    void RefreshTable()
    {
        while(tableList.Count>0)
        {            
            Destroy(tableList[0]);
            tableList.RemoveAt(0);
        }

        int checkednum = 0;
        int num = vacaList.Count;
        Debug.Log(vacaList[0].soldierName);
        GameObject obj;
        RectTransform rt;

        for (int j = 0; j < 14; j++)        
            daycount[j] = 0;

            for (int i = 0; i < num; i++)
        {
            //int comp1 = DateTime.Compare(startDate, vacaList[i].arriveDate);
            //int comp2 = DateTime.Compare(vacaList[i].departDate, endDate);
            //if (comp1<0 && comp2<0)
            {
                obj = Instantiate(tableObject, transform.position, transform.rotation);
                
                obj.transform.SetParent(tablePanel.transform);

                TimeSpan ts = vacaList[i].departDate - startDate;
                int startDate_int = ts.Days;
                int period = vacaList[i].getPeriod();

                Screen3_Table tt = obj.GetComponent<Screen3_Table>();
                Debug.Log("==="+ vacaList[i].soldierName);
                tt.set_Screen3_Table(vacaList[i].soldierName, startDate_int, period, vacaList[i].departDate, vacaList[i].arriveDate);
                tableList.Add(obj);
                checkednum++;

                for (int j=Mathf.Max(0, startDate_int); j< Mathf.Min(14,startDate_int+period);j++)                
                    daycount[j]++;                
            }
            
        }

        obj = Instantiate(tableResult, transform.position, transform.rotation);
        tableList.Add(obj);
        obj.transform.SetParent(tablePanel.transform);
        for (int i = 0; i < 14; i++)
            obj.transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<Text>().text = daycount[i].ToString();

        print(checkednum);
        rt = (RectTransform)tablePanel.transform.parent;
        rt.sizeDelta = new Vector2(0, 23.1072f * (checkednum+1));

    }

    void DateSet(int _week)
    {
        week = _week;
        weekText.text = week.ToString() +"~"+ (week + 1).ToString() +"th week vacation calender";

        startDate = baseDate.AddDays((week - 1) * 7);
        endDate = startDate.AddDays(14);
        for(int i=0;i<14;i++)
        {
            DateTime tempDate = startDate.AddDays(i);
            date_Texts[i].text = tempDate.Month + "/" + tempDate.Day;
        }

        RefreshTable();
    }

    public void clickSearchButton()
    {
        if (0 < int.Parse(inputWeek.text) && int.Parse(inputWeek.text) < 53)
            DateSet(int.Parse(inputWeek.text));
    }
}
