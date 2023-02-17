using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScreenLoad : MonoBehaviour
{
    // Start is called before the first frame update

    // public float threshold = -50f;
    // Update is called once per frame
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
