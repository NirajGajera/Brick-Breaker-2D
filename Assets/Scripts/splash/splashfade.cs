using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class splashfade : MonoBehaviour
{
    public Image splash;

    public string loadlevel;
    IEnumerator Start()
    {
       
        //------------------------------------------
        splash.canvasRenderer.SetAlpha(0.0f);
        fadein();
        yield return new WaitForSeconds(2.5f);
        fadeout();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(loadlevel);
    }

    void fadein()
    {
        splash.CrossFadeAlpha(1.0f, 1.5f, false);
    }
    void fadeout()
    {
        splash.CrossFadeAlpha(0.0f, 2.5f, false);
    }
   
}
