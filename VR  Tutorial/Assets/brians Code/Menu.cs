using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  //  public Animator fadeAnimator;
 //   public AudioSource backgroundMusic;
    //public AudioSource AudioPlayer;



    public void QuitGame()
    {
        Application.Quit();
    }

 //   public void PlaySound()
//    {
       // AudioPlayer.Play();
        //  Player = gameObject.GetComponent<Animator>();
        //  Player.Play("Cam");
//    }

    public void StartGame()
    {

        SceneManager.LoadScene("SampleScene");
    }
}