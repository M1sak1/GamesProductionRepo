using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CollectPumpkin : MonoBehaviour
{
    [SerializeField] private ParticleSystem CollectEffect;
    [SerializeField] private GameObject UIUpdate;
    // Start is called before the first frame update

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)
    {
        CollectEffect.Stop();
        if (CollectEffect.isStopped)
        {
            CollectEffect.Play();
        }

        Destroy(gameObject);
        UIUpdate.gameObject.GetComponent<Collectables>().CollectedPumpkin();

        //trigger UI update
    }
}
