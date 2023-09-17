using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class splashbg : MonoBehaviour
{
    public Image bg;

    // Start is called before the first frame update
    IEnumerator Start()
    {

        //------------------------------------------
        bg.canvasRenderer.SetAlpha(0.0f);
        fadein();
        yield return new WaitForSeconds(2.5f);
        fadeout();
        yield return new WaitForSeconds(2.5f);
    }

    void fadein()
    {
        bg.CrossFadeAlpha(1.0f, 1.5f, false);
    }
    void fadeout()
    {
        bg.CrossFadeAlpha(0.0f, 2.5f, false);
    }
    // Update is called once per frame

}
