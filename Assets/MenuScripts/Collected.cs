using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collected : MonoBehaviour
{
    public TMP_Text CollectablesText;
    // Start is called before the first frame update
    void Start()
    {
        CollectablesText.text = "Collected Pumpkins:" + PickupsCollected.Instance.Get() + " / " + 3;
    }

}
