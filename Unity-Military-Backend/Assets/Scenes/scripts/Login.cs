﻿using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [SerializeField] public InputField idField;
  [SerializeField] public InputField pwField;
    [SerializeField] Msgbox msgbox;
    [SerializeField] GameObject screen;
    [SerializeField] GameObject parent;

    private void Update()
    {
        if(idField.isFocused)
        {
            if (Input.GetKeyUp(KeyCode.Tab))
                pwField.Select();
        }
        if (pwField.isFocused)
        {
            if (Input.GetKeyUp(KeyCode.Tab))
                idField.Select();
        }
    }

    public void onClick()
    {
        login();
    }

    private void login()
    {
        SoldierDataManager sdm = null;

        RestClient.Get<user>("https://fir-unity-6f472.firebaseio.com/soldiers/" + idField.text + ".json").Then(response =>
        {
            user up = response;

            up = response;
            Debug.Log(up.nam);
            if (up.birt.Equals(pwField.text))
            {
                screen.SetActive(true);
                parent.SetActive(false);
                SoldierScreen1.soldnumber = idField.text;
            }
            else
            {
                msgbox.gameObject.SetActive(true);
                msgbox.openMessage("아이디 또는 패스워드가 일치하지 않습니다.");
            }

        });
        
        
    }
}
