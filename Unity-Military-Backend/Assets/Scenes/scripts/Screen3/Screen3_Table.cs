using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Screen3_Table : MonoBehaviour
{
    [SerializeField] Text name_Text;
    [SerializeField] Image table_Image;
    [SerializeField] Text test_Text;

    public void set_Screen3_Table(string _name, int startDate, int period, DateTime d1, DateTime d2)
    {
        name_Text.text = _name;
        float x1 = -363.73f;
        float x2 = -363.73f;
        float maxX = -363.73f + 14 * 56.8014f;

        x1 = x1 + startDate * 56.8014f;
        x2 = Mathf.Min(maxX,x1 + period * 56.8014f);

        x1 = Mathf.Max(x1, -363.73f);

        RectTransform rt = (RectTransform)table_Image.transform;
        rt.anchoredPosition = new Vector2((x2+x1)/2f, 0);
        rt.sizeDelta = new Vector2(x2-x1,24.91f);

        test_Text.text = d1.Month + "/" + d1.Day + " ~ " + d2.Month + "/" + d2.Day;
    }


}
