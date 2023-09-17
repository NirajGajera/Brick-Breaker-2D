using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class start : MonoBehaviour
{
    [Header("Put your URLS")]
    public string facebookURL;
    public string instagramURL;
    public string reviewURL;
    //public string shareurl;
    private AudioSource sounds;
    public AudioClip click;

    private bool muted = false;
    public AudioSource MUsicc;
    private int unlookedLevels;
    private bool isSettings;
    public GameObject backSettings;
    public GameObject pannelSettings;
    public Text crystals;
    public Image soundBtn;
    public Image musicbtn;
    private int soundStatus;
    [Header("sound")]
    public Sprite soundON;
    public Sprite soundOFF;
    private AudioSource music;
    [Header("music")]
    public Image musicon;
    public Image musicof;
    // Start is called before the first frame update



    private void Awake()
    {
        if (PlayerPrefs.GetInt("crystalsNum") <= 0)
        {
            PlayerPrefs.SetInt("crystalsNum", 0);
        }
        //if (SceneManager.GetActiveScene().name != "menu")
        //    adsmanager.instance.DestroyBannerAdmob();
    }
    //    //if (PlayerPrefs.GetInt("crystalsNum") <= 0)
    //    //{
    //    //    PlayerPrefs.SetInt("crystalsNum", 0);
    //    //}

    //    //if (PlayerPrefs.GetInt("add100Crystals") == 0 || PlayerPrefs.GetInt("add100Crystals") < 0)
    //    //{
    //    //    crystals.text = "" + PlayerPrefs.GetInt("crystalsNum", 0);
    //    //    PlayerPrefs.SetInt("crystalsNum", 100);
    //    //    PlayerPrefs.SetInt("add100Crystals", 1);
    //    //    PlayerPrefs.Save();
    //    //}
    //}
    void Start()
    {
            if (PlayerPrefs.GetInt("add100Crystals") == 0 || PlayerPrefs.GetInt("add100Crystals") < 0)
            {
            PlayerPrefs.SetInt("crystalsNum", 100);
            PlayerPrefs.SetInt("add100Crystals", 1);
            PlayerPrefs.Save();
            }

        //adsmanager.instance.ShowBannerAds();
        soundStatus = PlayerPrefs.GetInt("sound"); //Get the sound status
        unlookedLevels = PlayerPrefs.GetInt("UnlookedLevels");
       
       // int aa= PlayerPrefs.GetInt("crystalsNum");

        crystals.text = "x" + PlayerPrefs.GetInt("crystalsNum");

        if (soundStatus == 0)
        {
            soundBtn.sprite = soundON;
        }
        else
        {
            soundBtn.sprite = soundOFF;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (PlayerPrefs.GetInt("crystalsNum") <= 0)
        {
            PlayerPrefs.SetInt("crystalsNum", 0);
        }
        //if (SceneManager.GetActiveScene().name != "menu")
        //    adsmanager.instance.DestroyBannerAdmob();
        //if (soundStatus == 0)
        //    music.mute = false;
        //else
        //    music.mute = true;
    }
    public void play()
    {
        SceneManager.LoadScene("menu");
    }
    public void levels()
    {
        SceneManager.LoadScene("menu");

    }
    public void OpenFacebook()
    {
        Application.OpenURL(facebookURL);
    }
    
    public void OpenInstagram()
    {
        Application.OpenURL(instagramURL);
    }
    public void ReviewBtn()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id="+Application.identifier);
    }
    public void exit()
    {
        Application.Quit();
    }
    public void options()
    {
       
            if (isSettings == false)
            {
                backSettings.SetActive(true);
                pannelSettings.SetActive(true);
                isSettings = true;
            }
            else
            {
                backSettings.SetActive(false);
                pannelSettings.SetActive(false);
                isSettings = false;
            }
    }
    public void SoundBtn()
    {
        if (soundStatus == 0)
        {
            soundBtn.sprite = soundOFF;
            PlayerPrefs.SetInt("sound", 1);
            soundStatus = 1;
        }
        else
        {
            soundBtn.sprite = soundON;
            PlayerPrefs.SetInt("sound", 0);
            soundStatus = 0;
        }

        PlayerPrefs.Save();
    }
    //public void musicbotton()
    //{
    //    if (MUsicc == false)
    //    {
    //        musicbtn.sprite = musicof;
    //       // PlayerPrefs.SetInt("sound", 1);
    //       // soundStatus = 1;
    //    }
    //    else
    //    {
    //        musicbtn.sprite = musicon;
    //        //PlayerPrefs.SetInt("sound", 0);
    //        //soundStatus = 0;
    //    }
    //}
    public void oncick()
    {
        if (muted == false)
        {

            musicon.enabled = false;
            musicof.enabled = true;
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            musicon.enabled = true;
            musicof.enabled = false;
            muted = false;
            AudioListener.pause = false;
        }

        save();
    }
    //private void updatebutton()
    //{
    //    if (muted == false)
    //    {
    //        musicon.enabled = false;
    //        musicon.enabled = true;
    //    }
    //    else
    //    {
    //        musicon.enabled = true;
    //        musicon.enabled = false;
    //    }
    //}


    private void load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
    //public void Click()
    //{
        
    //    FindObjectOfType<LevelManager>().Click();
    //}
}

