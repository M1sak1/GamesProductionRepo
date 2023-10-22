using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CollectPumpkin : MonoBehaviour
{
    [SerializeField] private ParticleSystem CollectEffect;
    [SerializeField] private GameObject UIUpdate;
    // Start is called before the first frame update

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
        CollectEffect.Play();
        UIUpdate.gameObject.GetComponent<Collectables>().CollectedPumpkin();
        gameObject.GetComponent<Light2D>().intensity *= 1.5f;
        PickupsCollected.Instance.Set(1);
	}
}

