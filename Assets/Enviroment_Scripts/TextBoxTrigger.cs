using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxTrigger : MonoBehaviour
{
    [SerializeField] private Animation Fade;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) //detects if the player has hit this invisible block and changes the scene to the winScreen as the player has won 
    {
        Fade["AnotherOne"].normalizedTime = 0f;
        Fade["AnotherOne"].speed = 1f;
        Fade.Play();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        Fade["AnotherOne"].normalizedTime = 1f;
        Fade["AnotherOne"].speed = -1f;
        Fade.Play();

    }

}
