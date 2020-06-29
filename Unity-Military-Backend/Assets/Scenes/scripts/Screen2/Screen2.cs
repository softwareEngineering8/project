using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen2 : MonoBehaviour
{
    [SerializeField] Text checked_num_Text;
    [SerializeField] Text num_Text;
    [SerializeField] GameObject vacation_applyButton;
    [SerializeField] GameObject content;

    List<bool> vacation_buttons_Select;
    List<Button> vacation_buttons;
    int num = 10;
    int checkedNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        vacation_buttons = new List<Button>();
        vacation_buttons_Select = new List<bool>();
        buttonCreate(num);
        checked_num_Text.text = checkedNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void buttonCreate(int num)
    {
        GameObject obj;
        RectTransform rt;

        for (int i = 0; i < num; i++)
        {
            obj = Instantiate(vacation_applyButton, transform.position, transform.rotation);

            obj.transform.SetParent(content.transform);
            rt = (RectTransform)obj.transform;
            rt.anchoredPosition = new Vector2(-0.8f, 336.76f - 76.26f * i);

            Screen2_vacation_Button bb = obj.transform.GetComponent<Screen2_vacation_Button>();
            bb.setButton(transform.GetComponent<Screen2>(),"이도희"+i, new System.DateTime(2020, 6, 20).AddDays(i*5), new System.DateTime(2020, 6, 25).AddDays(i*5),Random.Range(0,2), Random.Range(0, 2));

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
        checked_num_Text.text = checkedNum.ToString();
    }
}
