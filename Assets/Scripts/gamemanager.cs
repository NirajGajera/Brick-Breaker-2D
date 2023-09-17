using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance { get; set; }
    private const float disDownLevelConstruction = 0.45f;
    [HideInInspector] public bool isDecreaseButtonPresed;
    [HideInInspector] public bool gatherBalls;
    [HideInInspector] public int nGatherBalls;
    private GameObject levelConstruction1;
    public AudioClip click;
    public Button doublebalss;
    private int soundStatus;
    private AudioSource music;
    public GameObject gatherButton;
    public Image soundBtn;
    public GameObject twoButtons;
    public GameObject pauseMenu;
    private Button _buttondecrese;
    private Button _button;
    public Text crystals;
    public Text stage;
    [Header("Sprites")]
    public Sprite soundON;
    public Sprite soundOFF;
    [Header("levelmanager")]
    public Image contentProgressBar;

    public GameObject levelFailed;
    public GameObject levelCompleted;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("crystalsNum") <= 0)
        {
            PlayerPrefs.SetInt("crystalsNum", 0);
        }
        // adsmanager.instance.ShowBannerAds();
        // instance = this;
        instance = this;
        music = gameObject.AddComponent<AudioSource>();
        soundStatus = PlayerPrefs.GetInt("sound");

        Time.timeScale = 1.0f;

        if (soundStatus == 0)
        {
            soundBtn.sprite = soundON;
        }
        else
        {
            soundBtn.sprite = soundOFF;
        }
        _buttondecrese = GetComponent<Button>();
    }
    void Start()
     {
        levelConstruction1 = LevelManager.instance.levelConstruction;
        _button= GameObject.Find("doubleballs").GetComponent<Button>();
        _buttondecrese = GameObject.Find("decrease_bircks_life_brick").GetComponent<Button>();
        if (soundStatus == 0)
        {
            soundBtn.sprite = soundON;
        }
        else
        {
            soundBtn.sprite = soundOFF;
        }
    }

    private void Update()
    {

        crystals.text = "x" + PlayerPrefs.GetInt("crystalsNum");
        stage.text = "STAGE " + LevelManager.instance.currentLevel;
        if (soundStatus == 0)
            music.mute = false;
        else
            music.mute = true;
                
        if (nGatherBalls >= Balls.instance.ballNumberThrown && gatherBalls)
        {
            gatherButton.SetActive(false);

            gatherBalls = false; //It means that all balls was already gathered
            nGatherBalls = 0;  //Initialize the number of gathered balls

            twoButtons.SetActive(true); //Set actve buttons which can increase number of balls and another which can decrease life of all balls

            Balls.instance.tnArrivedBallsBack.text = "x" + Balls.instance.numberBalls;
            Balls.instance.startThrowBalls = false;
            Balls.instance.nArrivedBallsBack = Balls.instance.numberBalls;

            DownLevelConstruction();
            Balls.instance.levelConstructionDown = true;
            if (PlayerPrefs.GetInt("crystalsNum") <= 0)
            {
                PlayerPrefs.SetInt("crystalsNum", 0);
            }
        }
    }
     private void DownLevelConstruction()
     {
        levelConstruction1.transform.position = new Vector3(levelConstruction1.transform.position.x, levelConstruction1.transform.position.y - disDownLevelConstruction);
     }
    
    public void GatherBallsButton()
    {
        LevelManager.instance.GatherBallsButton();
        //gatherBalls = true;
        //nGatherBalls += Balls.instance.nArrivedBallsBack;
    }
    public void DecreaseButtonPressed()
    {


        if (PlayerPrefs.GetInt("crystalsNum") >= 100 )
        {
            PlayerPrefs.SetInt("crystalsNum", PlayerPrefs.GetInt("crystalsNum") - 100);
            PlayerPrefs.Save();
            LevelManager.instance.DecreaseButtonPressed();
            //Balls.instance.nArrivedBallsBack = Balls.instance.numberBalls;
            //isDecreaseButtonPresed = true;
        }
        else
        {
            _buttondecrese.interactable = false;
        }

    }
    //public void shownterstial3()
    //{
    //    //-----------------------------------------------------------------------------player go to main menu----------------------------------------
        
    //}
    public void showrewardedads()
    {
        //-----------------------------------------------------------------------------show reward ad to get a 2* balls----------------------------------------
        if (adsmanager.instance != null)
        {
           //x _button.interactable = true;
            adsmanager.instance.ShowRewardedVideoAdAdmob1();

        }
        else
        {
            _button.interactable = false;
        }
    }

    public void IncreaseNumberOfBalls()
    {
      

        if (PlayerPrefs.GetInt("crystalsNum") >= 100 || PlayerPrefs.GetInt("crystalsNum") > 0)
        {
            PlayerPrefs.SetInt("crystalsNum", PlayerPrefs.GetInt("crystalsNum") - 100);
            PlayerPrefs.Save();
            Balls.instance.numberBalls *= 2;
            Balls.instance.tnArrivedBallsBack.text = "x" + Balls.instance.numberBalls;
            Balls.instance.nArrivedBallsBack = Balls.instance.numberBalls;
        }
        else
        {
            doublebalss.interactable = false;
        }
    }
    public void Pause()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        levelConstruction1.SetActive(false);
        if (adsmanager.instance != null)
            adsmanager.instance.ShowInterstitialads3();
    }
    public void UnPause()
    {
        pauseMenu.SetActive(false);
        levelConstruction1.SetActive(true);

        Time.timeScale = 1f;

    }
    public void Retry()
    {
        // Click();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MAINMENU()
    {
        // Click();
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }
    public void home()
    {
        // Click();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void NextLevel()
    {
        int nextLevel = LevelManager.instance.currentLevel + 1;
        string name = string.Concat("level_", nextLevel.ToString());
        
        SceneManager.LoadScene(name);
    }
    public void Click()
    {
        music.clip = click;
        music.Play();
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
        //AudioListener.pause = true;
        PlayerPrefs.Save();
    }
}
