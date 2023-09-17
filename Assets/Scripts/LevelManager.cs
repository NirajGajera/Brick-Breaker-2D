using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    private const float disDownLevelConstruction = 0.48f;

    public static LevelManager instance { get; set; }

    [Header("Set up level propreties")]
    public int currentLevel;
    public int numberOfBrickInLevel;
    public int maxLifeBrick;
    //[Header("Sprites")]
    //public Sprite darkMode;
    //public Sprite lightMode;
    private GameObject[] bricks;
    [Header("Sounds")]
    public AudioClip click;
    public AudioClip ball;
    public AudioClip levelComplete;
    public AudioClip levelFail;
    [Header("Objects of level")]
    public GameObject levelConstruction;
    //public GameObject gatherButton;
    
    //public Image soundBtn;
    //public Image modeButton;


    private Button _button;
    private Button _buttondecrese;
    ///public Text scoreText;
    private Image contentProgressBar;
    //[Header("Sprites")]
    //public Sprite soundON;
    //public Sprite soundOFF;

    [HideInInspector] public bool gatherBalls;
    [HideInInspector] public int nGatherBalls;
    [HideInInspector] public bool isDecreaseButtonPresed;
    [HideInInspector] public int score;
    [HideInInspector] public int numberOfPointsInLevel;
    [HideInInspector] public int destroyedBricks;

    //private bool isNowDarkMode; //Check if dark mode is activated or not
    private bool isLevelSaved;  // check if level was saved or not
    private AudioSource music;  //This is main Audio Source which will play all sounds
    private int soundStatus;

    private void Awake()
    {
       // adsmanager.instance.ShowBannerAds();
        instance = this;

        music = gameObject.AddComponent<AudioSource>();
        soundStatus = PlayerPrefs.GetInt("sound");

        Time.timeScale = 1.0f;


        _button = GetComponent<Button>();
        _buttondecrese = GetComponent<Button>();

    }
    private void Start()
    {
        
       // soundBtn = GameObject.Find("two_buttons").;
        //if (soundStatus == 0)
        //{
        //    soundBtn.sprite = soundON;
        //}
        //else
        //{
        //    soundBtn.sprite = soundOFF;
        //}   
        BrickCounter();
       // isNowDarkMode = true;

        //GameObject.Find("top_pannel").GetComponent<SpriteRenderer>().color = new Color(42f / 255, 182f / 255, 229f / 255, 1f);
        //GameObject.Find("bottom_pannel").GetComponent<SpriteRenderer>().color = new Color(42f / 255, 182f / 255, 229f / 255, 1f);
        //GameObject.Find("middle_pannel").GetComponent<SpriteRenderer>().color = new Color(0f / 255, 0f / 255, 0f / 255, 1f);

        //Balls.instance.ball.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        //Balls.instance.tnArrivedBallsBack.color = new Color(1f, 1f, 1f, 1f);

        //if (adsmanager.instance != null)
        //   adsmanager.instance.DestroyBannerAdmob();

        _button = GameObject.Find("doubleballs").GetComponent<Button>();
        _buttondecrese = GameObject.Find("decrease_bircks_life_brick").GetComponent<Button>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "colidegather")
        {
            GatherBallsButton();
        }

    }
    private void Update()
    {

        contentProgressBar = gamemanager.instance.contentProgressBar;
        //levelConstruction = GameObject.Find("LEVEL_CONSTRUNCTION1");
        ////GameObject head = gatherButton;   
            
        ////head.transform.Find("gather_ball_button");
        //twoButtons = GameObject.Find("two_buttons");
        //pauseMenu = GameObject.Find("pause_menu");
        //levelFailed = GameObject.Find("level_failed");
        //levelCompleted = GameObject.Find("level_complete");

        GameObject.Find("Stage").GetComponent<Text>().text = "STAGE : " + currentLevel;

       // scoreText.text = "" + score;
        contentProgressBar.fillAmount = (float)score / (float)numberOfPointsInLevel;

        if (soundStatus == 0)
            music.mute = false;
        else
            music.mute = true;
        
        //When level is completed
        if (numberOfBrickInLevel <= destroyedBricks) //Check if number of destroyed bricks is not equal with number of bricks in level
        {
            gamemanager.instance.levelCompleted.SetActive(true);
            

            if (isLevelSaved == false)
            {
                if (currentLevel > PlayerPrefs.GetInt("UnlookedLevels")) //Chekc if the level is not already saved
                {
                    PlayerPrefs.SetInt("UnlookedLevels", PlayerPrefs.GetInt("UnlookedLevels") + 1);
                    PlayerPrefs.Save();
                }

                PlayerPrefs.SetInt("crystalsNum", PlayerPrefs.GetInt("crystalsNum") + 50);
                PlayerPrefs.Save();
                LevelCompleteSound();

                isLevelSaved = true;

                if (adsmanager.instance != null)
                    adsmanager.instance.ShowInterstitialads2();//------------------------------------------------================================---inter-2----------------------------------------------

                
            }

            GameObject.Find("complete_text").GetComponent<Text>().text = "STAGE   " + currentLevel;
           

            Time.timeScale = 0.0f;
            if (PlayerPrefs.GetInt("crystalsNum") <= 0)
            {
                PlayerPrefs.SetInt("crystalsNum", 0);
            }
        }
        
        //-------------------------------------------------------------------

        //When we pressed Gather Button,to gather all the balls
        if (nGatherBalls >= Balls.instance.ballNumberThrown && gatherBalls)
        {
            gatherBalls = false; //It means that all balls was already gathered
            nGatherBalls = 0;  //Initialize the number of gathered balls

            //gatherButton.SetActive(false);
            gamemanager.instance.twoButtons.SetActive(true); //Set actve buttons which can increase number of balls and another which can decrease life of all balls

            Balls.instance.tnArrivedBallsBack.text = "x" + Balls.instance.numberBalls;
            Balls.instance.startThrowBalls = false;
            Balls.instance.nArrivedBallsBack = Balls.instance.numberBalls;

            //DownLevelConstruction();
            Balls.instance.levelConstructionDown = true;
        }
    //------------------------------------------------------------------------

    //Decrease all balls life with -5 when derease button was pressed
        if (isDecreaseButtonPresed)
        {
            GameObject[] bricks = GameObject.FindGameObjectsWithTag("brick");

            foreach (GameObject obj in bricks)
            {
               // obj.GetComponent<Brick>().brickCollission.sortingOrder = 5;
                obj.GetComponent<Brick>().brickLife -= 5;

                LevelManager.instance.score += 5;
            }

            isDecreaseButtonPresed = false;
        }
        

        //Check if you have enough crystals to duplicate number of balls or decrease life of all bricks
        if (PlayerPrefs.GetInt("crystalsNum") >= 100|| PlayerPrefs.GetInt("crystalsNum") > 0)
        {
            if(GameObject.Find("duplicate_number_of_balls_button") != null)
               GameObject.Find("duplicate_number_of_balls_button").GetComponent<Button>().interactable = true;
            if(GameObject.Find("decrease_bircks_life_brick") != null)
               GameObject.Find("decrease_bircks_life_brick").GetComponent<Button>().interactable = true;
        }
        else
        {
            if (GameObject.Find("duplicate_number_of_balls_button") != null)
            {
                GameObject.Find("duplicate_number_of_balls_button").GetComponent<Button>().interactable = false;
                GameObject.Find("decrease_bircks_life_brick").GetComponent<Button>().interactable = false;
            }
        }
    //----------------------------------------------------------------------------------------------------
    }
    public void DownLevelConstruction()
    {
        levelConstruction.transform.position = new Vector3(levelConstruction.transform.position.x, levelConstruction.transform.position.y - disDownLevelConstruction);
    }
    public void GatherBallsButton()
    {
        gatherBalls = true;
        nGatherBalls += Balls.instance.nArrivedBallsBack;
        gamemanager.instance.gatherButton.SetActive(false);

    }
    public void DecreaseButtonPressed()
    {       
        if (PlayerPrefs.GetInt("crystalsNum") >= 100 || PlayerPrefs.GetInt("crystalsNum") > 0)
        {
            PlayerPrefs.SetInt("crystalsNum", PlayerPrefs.GetInt("crystalsNum") - 100);
            PlayerPrefs.Save();
            Balls.instance.nArrivedBallsBack = Balls.instance.numberBalls;
            isDecreaseButtonPresed = true;
        }
        else
        {
            _buttondecrese.interactable = false;
        }
    }
    //public void shownterstial3()
    //{
    //    //-----------------------------------------------------------------------------player go to main menu----------------------------------------
    //    if (adsmanager.instance != null)
    //    {
    //        adsmanager.instance.ShowInterstitialads3();
    //    }
    //    else
    //    {
    //        SceneManager.LoadScene("menu");
    //    }
    //}
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
            _button.interactable = false;
        }

    }
    //public void ChangeLevelMode()
    //{
    //    GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");

    //    if (isNowDarkMode)
    //    {
    //        GameObject.Find("top_pannel").GetComponent<SpriteRenderer>().color = new Color(104f / 255f, 156f / 255f, 135f / 255f, 1f);
    //        GameObject.Find("bottom_pannel").GetComponent<SpriteRenderer>().color = new Color(104f / 255f, 156f / 255f, 135f / 255f, 1f);
    //        GameObject.Find("middle_pannel").GetComponent<SpriteRenderer>().color = new Color(236f / 255f, 231f / 255f, 231f / 255f, 1f);

    //        Balls.instance.ball.GetComponent<SpriteRenderer>().color = new Color(48f / 255f, 40f / 255f, 40f / 255f, 1f);
    //        Balls.instance.tnArrivedBallsBack.GetComponent<Text>().color = new Color(0, 0f, 0f, 1f);

    //        foreach (GameObject obj in balls)
    //            obj.GetComponent<SpriteRenderer>().color = new Color(48f / 255f, 40f / 255f, 40f / 255f, 1f);

    //        modeButton.sprite = lightMode;
    //        isNowDarkMode = false;
    //    }
    //    else
    //    {
    //        GameObject.Find("top_pannel").GetComponent<SpriteRenderer>().color = new Color(42f / 255, 182f / 255, 229f / 255, 1f);
    //        GameObject.Find("bottom_pannel").GetComponent<SpriteRenderer>().color = new Color(42f / 255, 182f / 255, 229f / 255, 1f);
    //        GameObject.Find("middle_pannel").GetComponent<SpriteRenderer>().color = new Color(0f / 255, 0f / 255, 0f / 255, 1f);

    //        Balls.instance.ball.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    //        Balls.instance.tnArrivedBallsBack.color = new Color(1f, 1f, 1f, 1f);

    //        foreach (GameObject obj in balls)
    //            obj.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

    //        modeButton.sprite = darkMode;
    //        isNowDarkMode = true;
    //    }
   // }
    public void Pause()
    {
        gamemanager.instance.pauseMenu.SetActive(true);
        levelConstruction.SetActive(false);

        Time.timeScale = 0f;
    }
    public void UnPause()
    {
        gamemanager.instance.pauseMenu.SetActive(false);
        levelConstruction.SetActive(true);

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
    public void showrewardedads()
    {
        //-----------------------------------------------------------------------------show reward ad to get a 2* balls----------------------------------------
        if (adsmanager.instance != null)
        {
            adsmanager.instance.ShowRewardedVideoAdAdmob1();
        }
        else
        {
            _button.interactable = false;
        }
    }
    //public void SHOWREWARDEDAD2()
    //{
    //    if (adsmanager.instance != null)
    //    {
    //        adsmanager.instance.ShowRewardedVideoAdAdmob2();

    //    }
    //}
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void NextLevel()
    {
        int nextLevel = currentLevel + 1;
        string name = string.Concat("level_",nextLevel.ToString());

        SceneManager.LoadScene(name);
    }
    public void Click()
    {
        music.clip = click;
        music.Play();
    }
    public void BallTouchedBrickSound()
    {
        music.clip = ball;
        music.Play();
    }
    public void LevelCompleteSound()
    {
        music.clip = levelComplete;
        music.Play();
    }
    public void LevelFailSound()
    {
        music.clip = levelFail;
        music.Play();
    }
    //public void SoundBtn()
    //{
    //    if (soundStatus == 0)
    //    {
    //        soundBtn.sprite = soundOFF;
    //        PlayerPrefs.SetInt("sound", 1);
    //        soundStatus = 1;
    //    }
    //    else
    //    {
    //        soundBtn.sprite = soundON;
    //        PlayerPrefs.SetInt("sound", 0);
    //        soundStatus = 0;
    //    }

    //    PlayerPrefs.Save();
    //}
    void BrickCounter()
    {
        bricks = GameObject.FindGameObjectsWithTag("brick");

        numberOfBrickInLevel = bricks.Length;
    }
}
