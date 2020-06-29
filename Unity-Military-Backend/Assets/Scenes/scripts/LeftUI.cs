using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftUI : MonoBehaviour
{
    [SerializeField] Text text_affiliation;
    [SerializeField] Text text_name;
    [SerializeField] Button[] button;
    [SerializeField] GameObject[] screens;

    string affiliation = "50사단 123연대 5대대";
    string name = "정동현";    

    void Start()
    {
        screens[0].SetActive(true);
        screens[1].SetActive(false);
        screens[2].SetActive(false);
        screens[3].SetActive(false);
        screens[4].SetActive(false);
        button[0].interactable = false;
    }

    void Update()
    {
        
    }

    public void onClickButton1()
    {
        buttonSet(1);
    }

    public void onClickButton2()
    {
        buttonSet(2);
    }

    public void onClickButton3()
    {
        buttonSet(3);
    }

    public void onClickButton4()
    {
        buttonSet(4);
    }
    public void onClickButton5()
    {
        buttonSet(5);
    }

    private void buttonSet(int button_number)
    {
        for(int i=0;i<5;i++)
        {            
            screens[i].SetActive(false);
            button[i].interactable = true;
        }
        button[button_number-1].interactable = false;
               
        screens[button_number - 1].SetActive(true);        
    }

    public void set()
    {
        text_affiliation.text = affiliation;
        text_name.text = name;

    }
}
