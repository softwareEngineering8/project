using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class U
{
    public string nam, soldnu, birt, affiliatio, phon;

    public U()
    {
        nam = Screen1.nam;
        soldnu = Screen1.soldnu;
        birt = Screen1.birt;
        affiliatio = Screen1.affiliatio;
        phon = Screen1.phon;

    }

}
[System.Serializable]
public class user
{
   //[SerializeField]
   //public U u;
    public string nam, soldnu, birt, affiliatio, phon;
    public user()
    {
        nam = Screen1.nam;
        soldnu = Screen1.soldnu;
        birt = Screen1.birt;
        affiliatio = Screen1.affiliatio;
        phon = Screen1.phon;

    }
}
