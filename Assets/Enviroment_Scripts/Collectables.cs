using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{
    private int Collected = 0;
    public TMP_Text PumpkinText;

    //https://www.youtube.com/watch?v=_RIsfVOqTaE&ab_channel=Blackthornprod
    void Update()
    {
        PumpkinText.text = "Collectables: " + Collected + " / "+ 1;

    }
    public void CollectedPumpkin()
    {
        Collected = 1;
        
    }
}
