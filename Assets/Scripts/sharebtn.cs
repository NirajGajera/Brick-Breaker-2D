using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sharebtn : MonoBehaviour
{
    NativeShare nativeShare;

    [SerializeField] private Button _shareBtn;


    public static Vector2 myPosition = new Vector2(0.5f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        nativeShare = new NativeShare();

        _shareBtn.onClick.AddListener(OnShareClick);


    }



    public void OnShareClick()
    {
        nativeShare.SetText("https://play.google.com/store/apps/details?id=com.nirgames.BrickAndBalls");
        nativeShare.Share();
    }



}
