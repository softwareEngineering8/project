using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen1_Show_ScreenC : MonoBehaviour
{
    [SerializeField] InputField[] field; 

    void Start()
    {
        
    }

    void Update()
    {
        for(int i=4;i>-1;i--)
        {
            if (field[i].isFocused)
            {                
                if (Input.GetKeyUp(KeyCode.Tab))
                {
                    field[(i + 1) > 4 ? 0: (i + 1)].Select();
                }
                    
            }
        }
    }
}
