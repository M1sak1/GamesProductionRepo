using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseCamera : MonoBehaviour
{
    [SerializeField] Camera MainCamera;

    //https://bergstrand-niklas.medium.com/how-to-add-lives-and-checkpoints-in-unity-eccf68e632a9
    private void OnTriggerEnter2D(Collider2D other) //detects if the player has hit this invisible block and changes the scene to the winScreen as the player has won 
    {
       MainCamera.GetComponent<CinemachineVirtualCamera>().Follow = null;
    }
   
}
