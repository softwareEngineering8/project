using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using System;

public class Screen2 : MonoBehaviour
{
    [SerializeField] Text checked_num_Text;
    [SerializeField] Text num_Text;
    [SerializeField] GameObject vacation_applyButton;
    [SerializeField] GameObject content;

    public class vacapply
    {
        public string people,depart,arrive,vackind,vacapplykind;
        public vacapply()
        {
            people = Screen2.peoplist;
            depart = Screen2.deplist;
            arrive= Screen2.arvlist;
            vackind = Screen2.vacakind;
            vacapplykind = Screen2.vacapplykind;
        }
    }

    public static string peoplist, deplist, arvlist, vacakind, vacapplykind;

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


  List<bool> vacation_buttons_Select;
    List<Button> vacation_buttons;
    int num = 10;
    int checkedNum = 0;

    // Start is called before the first frame update
    void Start()
    {

        vacation_buttons = new List<Button>();
        vacation_buttons_Select = new List<bool>();

        RestClient.Get<vacapply>("https://fir-unity-6f472.firebaseio.com/vacapply.json").Then(response =>
        {
           
            vacapply v = new vacapply();
            v = response;
            string[] peopleAr = v.people.Split(',');
            string[] departAr = v.depart.Split(',');
            string[] arriveAr = v.arrive.Split(',');
            string[] vackindAr = v.vackind.Split(',');
            string[] vacapplykindAr = v.vacapplykind.Split(',');

            string formatString = "yyyy##MM##dd";
            //date convert

            DateTime[] deprt = new DateTime[departAr.Length],arv= new DateTime[departAr.Length];
            for (int i = 0; i < departAr.Length; i++) {
                if (departAr[i] != "" || arriveAr[i] != "")
                {
                    deprt[i] = DateTime.ParseExact(departAr[i], formatString, null);
                    arv[i] = DateTime.ParseExact(arriveAr[i], formatString, null);
                }

            }
            Debug.Log(deprt[0]);
            //buttonCreate2(10);

            buttonCreate(peopleAr,deprt,arv,vackindAr,vacapplykindAr);

        });

        checked_num_Text.text = checkedNum.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void deleteSelectedButton()
    {
        int num = vacation_buttons.Count;
        for (int i = 0; i < num; i++)
        {
            if (vacation_buttons_Select[i])
            {
                destoryButton(i);
                i--;
                num--;
            }
        }
        checkedNum = 0;
        checked_num_Text.text = checkedNum.ToString();
        relocate();
    }

    void destoryButton(int button_count)
    {
        Destroy(vacation_buttons[button_count].gameObject);
        vacation_buttons.RemoveAt(button_count);
        vacation_buttons_Select.RemoveAt(button_count);

    }

    void relocate()
    {
        GameObject obj;
        RectTransform rt;

        for (int i = 0; i < vacation_buttons.Count; i++)
        {
            obj = vacation_buttons[i].gameObject;
            rt = (RectTransform)obj.transform;
            rt.anchoredPosition = new Vector2(-0.8f, 336.76f - 76.26f * i);
        }
    }
    void buttonCreate(string[] soldlist,DateTime[] dep,DateTime[] arr, string[] vkind, string[] vapplykind)
    {
        GameObject obj;
        RectTransform rt;

        for (int i = 0; i < soldlist.Length; i++)
        {
            Debug.Log(soldlist[i]);

            obj = Instantiate(vacation_applyButton, transform.position, transform.rotation);
           // obj.tag = "fkalskd";

            obj.transform.SetParent(content.transform);
            rt = (RectTransform)obj.transform;
            rt.anchoredPosition = new Vector2(-0.8f, 336.76f - 76.26f * i);

            Screen2_vacation_Button bb = obj.transform.GetComponent<Screen2_vacation_Button>();
            bb.setButton(transform.GetComponent<Screen2>(),soldlist[i], dep[i], arr[i],int.Parse(vkind[i]), int.Parse(vkind[i]));

            vacation_buttons.Add(obj.transform.GetComponent<Button>());
            vacation_buttons_Select.Add(false);
        }
    }

    public void buttonCheck(Button checkedButton)
    {

        
        for (int i=0;i<vacation_buttons.Count;i++)
        {
            if (vacation_buttons[i] == checkedButton)            
                if (vacation_buttons_Select[i])
                {
                    vacation_buttons_Select[i] = false;
                    checkedButton.transform.GetComponent<Image>().color = new Color(1f, 1f, 1f);
                    checkedNum -= 1;
                }
                else
                {
                    vacation_buttons_Select[i] = true;
                    checkedButton.transform.GetComponent<Image>().color = new Color(1f, 0.976f, 0.359f);
                    checkedNum += 1;
                }            
        }
        Debug.Log(vacation_buttons_Select[0]);
        checked_num_Text.text = checkedNum.ToString();
    }

    public void acceptClick()
    {
        Debug.Log("-"+vacation_buttons_Select[0]);

        RestClient.Get<vacapply>("https://fir-unity-6f472.firebaseio.com/vacapply.json").Then(response =>
        {

            vacapply v2 = new vacapply();
            v2 = response;
            string[] peopleAr = v2.people.Split(',');
            string[] departAr = v2.depart.Split(',');
            string[] arriveAr = v2.arrive.Split(',');
            string[] vackindAr = v2.vackind.Split(',');
            string[] vacapplykindAr = v2.vacapplykind.Split(',');

            string peoplestr = "",depstr="",arrstr="",vk="",vak="";
            string Rpeoplestr = "", Rdepstr = "", Rarrstr = "";
            string acceptedstr = "";
            for (int i=0;i < peopleAr.Length; i++)
            {
                if (vacation_buttons_Select[i])
                {
                   acceptedstr =acceptedstr+ "&" + peopleAr[i] + ";" + departAr[i] + ";" + arriveAr[i];
                    //Debug.Log(vacation_buttons[i]);
                    deleteSelectedButton();
                   // Destroy(vacation_buttons[i]);
                }
                //if you run the below code then it will delete from the server just try to figure out how to delete from UI
                /*if(!vacation_buttons_Select[i])
                {
                    peoplestr = peoplestr  + peopleAr[i] + ",";
                    depstr = depstr  +departAr[i] + ",";
                    arrstr = arrstr + arriveAr[i] + ",";
                    vk = vk + vackindAr[i] + ",";
                    vak = vak + vacapplykindAr[i] + ",";
                }*/
               
            }
            /**/
            Debug.Log("-0-"+peoplestr);

            RestClient.Get<accRejVacations>("https://fir-unity-6f472.firebaseio.com/accRejVacations/.json").Then(response2 =>
            {
                accRejVacations ar2 = new accRejVacations();
                ar2 = response2;
                
                Debug.Log(acceptedstr);
                accvac = ar2.accepted+acceptedstr;
                Debug.Log(accvac);
                accRejVacations ar = new accRejVacations();
                RestClient.Put("https://fir-unity-6f472.firebaseio.com/accRejVacations/.json", ar);

                /*vacapply v3 = new vacapply();
                v3.people = peoplestr;
                v3.depart = depstr;
                v3.arrive = arrstr;
                v3.vacapplykind = vak;
                v3.vackind = vk;

                RestClient.Put("https://fir-unity-6f472.firebaseio.com/vacapply.json", v3);*/
                
            });



        });

      
    }
}
