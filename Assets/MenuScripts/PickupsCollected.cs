using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsCollected : MonoBehaviour
{
    public static PickupsCollected Instance;
    // Start is called before the first frame update
    private int Collected;
    private void Awake()
    {
        Instance = this;
        Collected = 0;
        DontDestroyOnLoad(gameObject);
    }

    public int Get()
    {
        return Collected;
    }

    public void Set(int number)
    {
        Collected += number;
    }
}
