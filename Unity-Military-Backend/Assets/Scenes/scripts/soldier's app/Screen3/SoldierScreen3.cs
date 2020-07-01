using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SoldierScreen3 : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] Text remainVaca_Text;
    [SerializeField] GameObject SoldierScreen3_table;
    List<GameObject> SoldierScreen3Tables;
    SoldierDataManager sdm = null;
    int generalVaca = 28;
    int specialVaca = 0;
    int remainedSpVaca = 0;

    // Start is called before the first frame update
    void Start()
    {
        SoldierScreen3Tables = new List<GameObject>();

        do
        {
            sdm = SoldierDataManager.sdm;
        } while (sdm == null);        

        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Refresh()
    {
        int num = SoldierScreen3Tables.Count;
        for (int i=0;i<num;i++)
        {
            Destroy(SoldierScreen3Tables[0].gameObject);
            SoldierScreen3Tables.RemoveAt(0);
        }        

        generalVaca = 28;
        remainedSpVaca = 0;

        GameObject obj;
        RectTransform rt;
        for (int i=0;i<sdm.vacaList.Count;i++)
        {
            if (sdm.vacaList[i].vacaKind == 1) // [0] : generalVacation  [1]: specialVacation
            {
                
                obj = Instantiate(SoldierScreen3_table,transform);
                obj.transform.SetParent(content.transform);
                obj.transform.GetChild(0).GetComponent<Text>().text = "VacaName : " + sdm.vacaList[i].vacaName;
                obj.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = sdm.vacaList[i].getPeriod().ToString();
                obj.transform.GetChild(2).GetComponent<Text>().text = "UsedDate : -";
                SoldierScreen3Tables.Add(obj);

                if (sdm.vacaList[i].usedCheck > 0)// [0]: notUsed  [1]: waiting for Accept [2]: Used
                {
                    DateTime usedDate = sdm.vacaList[i].departDate;
                    string showUsedDate = usedDate.Year.ToString() +"/"+ usedDate.Month.ToString() +"/"+ usedDate.Day.ToString();
                    obj.transform.GetChild(2).GetComponent<Text>().text = "UsedDate : " + showUsedDate;

                    obj.GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f);
                    obj.transform.GetChild(0).GetComponent<Text>().color = new Color(1f, 1f, 1f);
                    obj.transform.GetChild(1).GetComponent<Text>().color = new Color(1f, 1f, 1f);
                    obj.transform.GetChild(2).GetComponent<Text>().color = new Color(1f, 1f, 1f);
                }
                else
                {
                    remainedSpVaca += sdm.vacaList[i].getPeriod();
                }

                rt = (RectTransform)obj.transform;
                rt.anchoredPosition = new Vector2(-8, -68f - 114.7f*(SoldierScreen3Tables.Count-1));
            }
            else
            {
                generalVaca -= sdm.vacaList[i].getPeriod();
            }
        }

        rt = (RectTransform)content.transform;
        rt.sizeDelta = new Vector2(0, 120f * (SoldierScreen3Tables.Count));


        remainVaca_Text.text = "Remain Vaca : " + (remainedSpVaca + generalVaca).ToString() 
            + " (General : " + generalVaca.ToString() + ", Special : " + remainedSpVaca.ToString() + ")";
    }
}
