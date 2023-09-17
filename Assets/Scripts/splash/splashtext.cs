using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class splashtext : MonoBehaviour
{
    public Text name;

    IEnumerator Start()
    {

        //------------------------------------------
        name.canvasRenderer.SetAlpha(0.0f);
        fadein();
        yield return new WaitForSeconds(2.5f);
        fadeout();
        yield return new WaitForSeconds(2.5f);
    }

    void fadein()
    {
        name.CrossFadeAlpha(1.0f, 1.5f, false);
    }
    void fadeout()
    {
        name.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
