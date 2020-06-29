using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Msgbox : MonoBehaviour
{
    [SerializeField] Text tt;

    Image img;
    float alpha;
    
    void Start()
    {
        alpha = 0f;
        img = gameObject.GetComponent<Image>();
        img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
    }

    void Update()
    {
        if (alpha < 1)
        {
            alpha += 0.2f;
            img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
        }     
    }


    public void openMessage(string txt)
    {
        alpha = 0;
        img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
        tt.text = txt;
    }

    public void closeMessage()
    {
        gameObject.SetActive(false);
    }
}
