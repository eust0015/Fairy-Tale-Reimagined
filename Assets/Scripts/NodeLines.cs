using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeLines : MonoBehaviour
{
    [SerializeField] string nodeColour;
    [SerializeField] GameObject[] lines;
    [SerializeField] GameObject child;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(nodeColour == "white")
        {
            if (PlayerPrefs.GetInt("wht1") == 1 && PlayerPrefs.GetFloat("wht2") == 1)
            {
                child.SetActive(true);
            }
            else
            {
                child.SetActive(false);
            }
        }
        else
        {
            var y = PlayerPrefs.GetInt(nodeColour);
            if (y == 1)
            {
                child.SetActive(true);
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i].SetActive(true);
                }
            }
            else
            {
                child.SetActive(false);
            }
        }
    }
}
