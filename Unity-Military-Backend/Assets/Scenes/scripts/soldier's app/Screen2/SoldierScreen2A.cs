using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Proyecto26;

public class SoldierScreen2A : MonoBehaviour
{
    [SerializeField] GameObject Screen2A_table;
    [SerializeField] GameObject AddTableButton;
    List<GameObject> tableList;
    SoldierDataManager sdm = null;
    int num;
    public class vacapply
    {
        public string people, depart, arrive, vackind, vacapplykind;
        public vacapply()
        {
            people = Screen2.peoplist;
            depart = Screen2.deplist;
            arrive = Screen2.arvlist;
            vackind = Screen2.vacakind;
            vacapplykind = Screen2.vacapplykind;
        }
    }

    public static string peoplist, deplist, arvlist, vacakind, vacapplykind;

    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        tableList = new List<GameObject>();
        tableList.Add(transform.GetChild(1).gameObject);

        do
        {
            sdm = SoldierDataManager.sdm;
        } while (sdm == null);

        //refresh();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void refresh()
    {

    }

    public void onClickAddNewTable()
    {
        num++;
        GameObject obj;
        RectTransform rt;

        obj = Instantiate(Screen2A_table,transform);
        obj.transform.SetParent(this.transform);

        tableList.Add(obj);

        rt = (RectTransform)obj.transform;
        rt.anchoredPosition = new Vector2(-12.65f, 197 - 124*num);

        rt = (RectTransform)AddTableButton.transform;
        rt.anchoredPosition = new Vector2(-12.65f, 197 - 124 * (num+1));
    }

    public void pushApply()
    {
        List<TempVacation> list = new List<TempVacation>();
        String _soldierName;
        int _vacaKind;
        DateTime _departTime;
        DateTime _arriveTime;
        int _usedCheck = 0;
        String _vacaName;
        RestClient.Get<vacapply>("https://fir-unity-6f472.firebaseio.com/vacapply.json").Then(response =>
        {
            

            vacapply v = new vacapply();
            v = response;
            
            string sn = "", vk = "", dt = "", at = "";
            for (int i = 0; i < tableList.Count; i++)
            {
                _soldierName = sdm.soldier.name;

               
                SoldierScreen2_table s2table = tableList[i].GetComponent<SoldierScreen2_table>(); Debug.Log("555");
                _vacaKind = s2table.GetvacaKind(); Debug.Log("555");
                _departTime = s2table.GetDepartDate(); Debug.Log("555");
                _arriveTime = s2table.GetArriveDate(); Debug.Log("555");
                //_vacaName = s2table.GetvacaName();
                Debug.Log("555");
                Debug.Log("$$$$" + peoplist);
               if (v.people.Equals(""))
                {
                    v.people = _soldierName;
                    v.vackind = _vacaKind.ToString();
                    v.depart = _departTime.ToString("yyyy##MM##dd");
                    v.arrive = _arriveTime.ToString("yyyy##MM##dd");
                    v.vacapplykind = v.vacapplykind + "0";
                }
                else
                {
                    v.people = v.people + "," + _soldierName;
                    v.vackind = v.vackind + "," + _vacaKind.ToString();
                    v.depart = v.depart + "," + _departTime.ToString("yyyy##MM##dd");
                    v.arrive = v.arrive + "," + _arriveTime.ToString("yyyy##MM##dd");
                    v.vacapplykind = v.vacapplykind + "0";
                }
                Debug.Log("$$$$" + peoplist);

                RestClient.Put("https://fir-unity-6f472.firebaseio.com/vacapply.json", v);


                list.Add(new TempVacation(_soldierName, _vacaKind, _departTime, _arriveTime, _usedCheck, "vacname"));//add vacation

                print(list[i]);
            }

        });
        

    }
}
