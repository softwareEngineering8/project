using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Signup : MonoBehaviour
{
    [SerializeField] InputField idField;
    [SerializeField] InputField pwField;
    [SerializeField] Msgbox msgbox;
    [SerializeField] GameObject screen;
    [SerializeField] GameObject parent;

    public static string id;
    public static string pw;


    private void Update()
    {
        if (idField.isFocused)
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
        id = idField.text;
        pw = pwField.text;
        signup();
    }


    
    private void signup()
    {


        //firebase
        PostToDatabase();
       
       
      
    }

    private void PostToDatabase()
    {
        user user = new user();
        RestClient.Put("https://fir-unity-6f472.firebaseio.com/"+id+".json",user);
    }
}
