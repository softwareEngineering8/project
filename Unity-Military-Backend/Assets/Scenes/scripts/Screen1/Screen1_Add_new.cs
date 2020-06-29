using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen1_Add_new : MonoBehaviour
{
    Screen1 scr1;

    public void setButton(Screen1 _scr1)
    {
        scr1 = _scr1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onclick()
    {
        scr1.soldierInfo_Add_Soldier();
    }
}
