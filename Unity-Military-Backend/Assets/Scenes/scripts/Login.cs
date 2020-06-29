using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [SerializeField] InputField idField;
    [SerializeField] InputField pwField;
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
        bool check = true;

        if (check)
        {
            screen.SetActive(true);
            parent.SetActive(false);
        }
        else
        {
            msgbox.gameObject.SetActive(true);
            msgbox.openMessage("아이디 또는 패스워드가 일치하지 않습니다.");
        }
    }
}
