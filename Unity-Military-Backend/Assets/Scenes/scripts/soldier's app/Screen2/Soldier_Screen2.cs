using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Screen2 : MonoBehaviour
{
    [SerializeField] GameObject Screen2A;
    [SerializeField] GameObject Screen2B;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onclick_applyButton()
    {
        GameObject Screen2 = this.gameObject;

        Screen2.SetActive(false);
        Screen2A.SetActive(true);
    }

    public void onclick_cancelButton()
    {
        GameObject Screen2 = this.gameObject;

        Screen2.SetActive(false);
        Screen2B.SetActive(true);
    }
}
