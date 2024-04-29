using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPref : MonoBehaviour
{
    // Start is called before the first frame update
    public void EnableNode(string pref)
    {
        PlayerPrefs.SetInt(pref, 1); 
    }
}
