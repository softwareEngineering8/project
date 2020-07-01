using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SoldierScreen2_table : MonoBehaviour
{
    public Dropdown vacakind;
    public GameObject[] SpecialVacationCheck;
    public GameObject[] PeriodCheck;
    public Text[] DepartDate;
    [SerializeField] Text ArriveDate;
    SoldierDataManager sdm = null;

    List<TempVacation> remainSpVaca;

    // Start is called before the first frame update
    void Start()
    {
        remainSpVaca = new List<TempVacation>();

        do
        {
            sdm = SoldierDataManager.sdm;
        } while (sdm == null);

        setSpecialVacationDropDown();
    }

    // Update is called once per frame
    void Update()
    {
        if (vacakind.value == 0)
        {
            SpecialVacationCheck[0].SetActive(true);
            SpecialVacationCheck[1].SetActive(false);

            PeriodCheck[0].SetActive(true);
            PeriodCheck[1].SetActive(false);
        }
        else
        {
            SpecialVacationCheck[1].SetActive(true);
            SpecialVacationCheck[0].SetActive(false);

            PeriodCheck[1].SetActive(true);
            PeriodCheck[0].SetActive(false);

            Dropdown m_DropDown = SpecialVacationCheck[1].GetComponent<Dropdown>();
            PeriodCheck[1].transform.GetChild(0).GetComponent<Text>().text = remainSpVaca[m_DropDown.value].getPeriod().ToString();
        }

        
        if (int.Parse(DepartDate[0].text)>0 && int.Parse(DepartDate[1].text) > 0 && int.Parse(DepartDate[2].text) > 0 && GetPeriod()>0)
        {
            DateTime _departDate = new DateTime(int.Parse(DepartDate[0].text), int.Parse(DepartDate[1].text), int.Parse(DepartDate[2].text));
            DateTime _arriveDate = _departDate.AddDays(GetPeriod() - 1);
            ArriveDate.text = _arriveDate.Year.ToString() + "/" + _arriveDate.Month.ToString() + "/" + _arriveDate.Day.ToString();
        }
        
        
    }
    void setSpecialVacationDropDown()
    {
        Dropdown m_DropDown = SpecialVacationCheck[1].GetComponent<Dropdown>();
        List<Dropdown.OptionData> m_Messages = new List<Dropdown.OptionData>();
        Dropdown.OptionData m_NewData;
        m_DropDown.ClearOptions();
        for (int i=0; i<sdm.vacaList.Count;i++)
        {
            if (sdm.vacaList[i].vacaKind == 1 && sdm.vacaList[i].usedCheck == 0)
            {
                remainSpVaca.Add(sdm.vacaList[i]);

                m_NewData = new Dropdown.OptionData();
                m_NewData.text = sdm.vacaList[i].vacaName + " [" + sdm.vacaList[i].getPeriod().ToString() + "]days";
                m_DropDown.options.Add(m_NewData);
            }

        }


    }

    public DateTime GetDepartDate()
    {
        DateTime dd = new DateTime(int.Parse(DepartDate[0].text), int.Parse(DepartDate[1].text), int.Parse(DepartDate[2].text));
        return dd;
    }

    public DateTime GetArriveDate()
    {
        DateTime dd = new DateTime(int.Parse(DepartDate[0].text), int.Parse(DepartDate[1].text), int.Parse(DepartDate[2].text));
        DateTime d2 = dd.AddDays(GetPeriod() - 1);
        return d2;
    }

    public string GetvacaName()
    {
        string name;
        Dropdown m_DropDown = SpecialVacationCheck[1].GetComponent<Dropdown>();

        name = remainSpVaca[m_DropDown.value].vacaName;

        return name;
    }

    public int GetvacaKind()
    {
        return vacakind.value;
    }

    public int GetPeriod()
    {
        if (vacakind.value == 0)
        {            
            InputField tt = PeriodCheck[0].GetComponent<InputField>();
            return int.Parse(tt.text);            
        }
        else
        {            
            
            Text tt = PeriodCheck[1].transform.GetChild(0).GetComponent<Text>();
            return int.Parse(tt.text);            
            
        }
        return 0;
    }

    
}
