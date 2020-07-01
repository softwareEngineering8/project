using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierScreen1 : MonoBehaviour
{
    [SerializeField] Text name_Text;
    [SerializeField] Text soldierNum_Text;
    [SerializeField] Text affiliation_Text;
    [SerializeField] Text birth_Text;
    [SerializeField] Text phone_Text;
    SoldierDataManager sdm = null;
    public static string soldnumber;


    void Start()
    {
        do
        {
            sdm = SoldierDataManager.sdm;
        } while (sdm == null);


        RestClient.Get<user>("https://fir-unity-6f472.firebaseio.com/soldiers/" + soldnumber + ".json").Then(response =>
        {
            user up = response;

            up = response;
            sdm.soldier = new TempSoldier(up.nam, up.soldnu,up.affiliatio, up.birt,up.phon);

            Refresh();

        });
       
    }

   
    void Refresh()
    {
        name_Text.text = sdm.soldier.name;
        soldierNum_Text.text = sdm.soldier.soldierNum;
        affiliation_Text.text = sdm.soldier.affiliation;
        birth_Text.text = sdm.soldier.birth;
        phone_Text.text = sdm.soldier.phone;
    }
}
