using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Proyecto26;
public class ids
{
    public string s;
    public ids()
    {
        s = Screen1.slist;
    }
}
public class Screen1 : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] GameObject soldierButton;
    [SerializeField] GameObject addnewSoldierButton;
    [SerializeField] GameObject SoldierInfoScreen;
    [SerializeField] GameObject SoldierInfoScreen_Home;
    [SerializeField] GameObject SoldierInfoScreen_ScreenA;
    [SerializeField] GameObject SoldierInfoScreen_ScreenB;
    [SerializeField] GameObject SoldierInfoScreen_ScreenC;
    [SerializeField] GameObject SoldierInfoScreen_ScreenD;
    [SerializeField] InputField name;
    [SerializeField] InputField soldnum;
    [SerializeField] InputField birth;
    [SerializeField] InputField affiliation;
    [SerializeField] InputField phone;

    public static string nam, soldnu, birt, affiliatio, phon;
    public static Screen1 scr;
    public GameObject AddSoldierButton;

    Soldiers[] s;
    int num = 20;
    public static string slist;
    void Start()
    {
        scr = transform.GetComponent<Screen1>();
        RestClient.Get<ids>("https://fir-unity-6f472.firebaseio.com/ids.json").Then(response =>
        {
            ids n2 = new ids();
            n2 = response;
           
            createButtons(n2.s.Split(','));
        });

        RectTransform rt = (RectTransform)content.transform;
        rt.anchoredPosition = new Vector2(0, 0);
    }

   
    private void RetreiveSoldiers(string findid)
    {
        
        RestClient.Get<user>("https://fir-unity-6f472.firebaseio.com/soldiers/"+findid+".json").Then(response =>
        {
            user uu = new user();
            Debug.Log("---"+uu.nam);
        });
        
    }
   /* private void RetreiveSoldierids()
    {

        RestClient.Get<ids>("https://fir-unity-6f472.firebaseio.com/ids.json").Then(response =>
        {
            soldiers = response;
            updateids(soldiers);
        });

    }
    public void updateids(ids soldiers)
    {
        soldslist=soldiers.s;
        Debug.Log(soldslist);

    }*/
    void createButtons(string[] num)
    {
        GameObject obj;
        RectTransform rt;   

        for (int i=1; i<num.Length; i++)
        {
            
            obj = Instantiate(soldierButton,transform.position,transform.rotation);
            //RetreiveSoldiers(num[i]);
            //Debug.Log(num[i]);           
            
            // obj.transform.GetChild(1).GetComponent<Text>().text = up.nam;
            //obj.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = num[i];

            obj.transform.SetParent(content.transform);
            rt = (RectTransform)obj.transform;
            rt.anchoredPosition = new Vector2(-375f + 107f*(i%8),338.7f - 145.7f*(int)(i/8));
            
            Screen1_Button bb = obj.transform.GetChild(0).GetComponent<Screen1_Button>();            
            bb.setButton(num[i], "name_test", "affiliation", transform.GetComponent<Screen1>()); // if u change name here the button will get name
            
        }

        obj = Instantiate(addnewSoldierButton, transform.position, transform.rotation);

        obj.transform.SetParent(content.transform);
        rt = (RectTransform)obj.transform;
        rt.anchoredPosition = new Vector2(-375f + 107f * (num.Length % 8), 338.7f - 145.7f * (int)(num.Length / 8));

        Screen1_Add_new add_button = obj.transform.GetComponent<Screen1_Add_new>();
        add_button.setButton(transform.GetComponent<Screen1>());
        AddSoldierButton = obj;
    }

    void addButtons(string[] num)
    {
        GameObject obj;
        RectTransform rt;

        int len = num.Length;

        obj = Instantiate(soldierButton, transform.position, transform.rotation);
        obj.transform.SetParent(content.transform);
        rt = (RectTransform)obj.transform;
        rt.anchoredPosition = new Vector2(-375f + 107f * ((len-1) % 8), 338.7f - 145.7f * (int)((len-1) / 8));

        Screen1_Button bb = obj.transform.GetChild(0).GetComponent<Screen1_Button>();
        bb.setButton(num[len-1], "name", "affiliation", transform.GetComponent<Screen1>()); // if u change name here the button will get name

        obj = AddSoldierButton;
        rt = (RectTransform)obj.transform;
        rt.anchoredPosition = new Vector2(-375f + 107f * ((len) % 8), 338.7f - 145.7f * (int)((len) / 8));
    }

    public void soldierButtonClick(string num)
    {

        RestClient.Get<user>("https://fir-unity-6f472.firebaseio.com/soldiers/"+num+ ".json").Then(response =>
        {
            user up = response;
            
            up = response;
            Debug.Log(up.nam);
            SoldierInfoScreen_Home.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = up.nam;
            SoldierInfoScreen_Home.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = up.soldnu;
            SoldierInfoScreen_Home.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = up.birt;
            SoldierInfoScreen_Home.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = up.affiliatio;
            SoldierInfoScreen_Home.transform.GetChild(6).GetChild(0).GetComponent<Text>().text = up.phon;
        });

       

        SoldierInfoScreen.SetActive(true);
        SoldierInfoScreen_Home.SetActive(true);
        SoldierInfoScreen_ScreenA.SetActive(false);
        SoldierInfoScreen_ScreenB.SetActive(false);
        SoldierInfoScreen_ScreenC.SetActive(false);
        SoldierInfoScreen_ScreenD.SetActive(false);
       
    }

    public void soldierInfo_Home_BackButton()
    {
        SoldierInfoScreen.SetActive(false);
    }

    public void soldierInfo_Home_Button1()
    {
        SoldierInfoScreen_Home.SetActive(false);
        SoldierInfoScreen_ScreenA.SetActive(true);
    }

    public void soldierInfo_Home_Button2()
    {
        SoldierInfoScreen_Home.SetActive(false);
        SoldierInfoScreen_ScreenB.SetActive(true);
    }

    public void soldierInfo_Home_Button3()
    {
        
        nam = name.text;
        soldnu = soldnum.text;
        birt = birth.text;
        soldnu = soldnum.text;
        affiliatio = affiliation.text;
        phon = phone.text;

        

        user user = new user();
        
        

        RestClient.Put("https://fir-unity-6f472.firebaseio.com/soldiers/"+soldnu+".json", user);
        RestClient.Get<ids>("https://fir-unity-6f472.firebaseio.com/ids.json").Then(response =>
        {
            ids n2 = new ids();
            n2 = response;
            slist = n2.s;
            ids n = new ids();
            n.s = n2.s + "," + soldnu;
            RestClient.Put("https://fir-unity-6f472.firebaseio.com/ids.json", n);
            addButtons(n.s.Split(','));
        });

        SoldierInfoScreen_Home.SetActive(false);
        SoldierInfoScreen_ScreenC.SetActive(true);
    }

    public void soldierInfo_Add_Soldier()
    {
        SoldierInfoScreen.SetActive(true);
        SoldierInfoScreen_Home.SetActive(false);
        SoldierInfoScreen_ScreenD.SetActive(true);
    }

    public void soldierInfo_ScreenA_BackButton()
    {
        SoldierInfoScreen_ScreenA.SetActive(false);
        SoldierInfoScreen_Home.SetActive(true);        
    }

    public void soldierInfo_ScreenB_BackButton()
    {
        SoldierInfoScreen_ScreenB.SetActive(false);
        SoldierInfoScreen_Home.SetActive(true);
    }

    public void soldierInfo_ScreenC_BackButton()
    {
        SoldierInfoScreen_ScreenC.SetActive(false);
        SoldierInfoScreen_Home.SetActive(true);
    }

    public void soldierInfo_ScreenD_BackButton()
    {
        SoldierInfoScreen_ScreenD.SetActive(false);
        SoldierInfoScreen_Home.SetActive(true);
        SoldierInfoScreen.SetActive(false);
    }

}
