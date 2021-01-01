using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Management manager;
    [SerializeField] private Text count;
    [SerializeField] public bool SD;

    void Update()
    {
        if (SD == true) // slimes
        {
            count.text = "Slimes: " + manager.GetCount().ToString();
        }
        else // Deaths
        {
            count.text = "Deaths: "  + manager.GetDeath().ToString();
        }
        
    }
}
