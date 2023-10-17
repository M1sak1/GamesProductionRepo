using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{
    private int Collected = 0;
    public TMP_Text PumpkinText;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        PumpkinText.text = "Collectables: " + Collected + " / "+ 1;

    }
    public void CollectedPumpkin()
    {
        Collected = 1;
    }
}
