using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public AudioClip[] gameStartClip;
    private AudioSource audioSource;

    GameObject obj;

    public bool isEndGame;
    public bool isStartFirstTime = true;
    public bool isRestart = false;
    //private bool isActiveStartPanel;
    int count;
    int x;
    public Text txtPoint;
    int gamePoint = 0;
    public GameObject panelEndGame;
    public GameObject panelStartGame;
    public Text txtEndPoint;

    public Button btnRestart;
    public Button btnStart;
    public Button btnExit;

    public Sprite btnRestartIdle;
    public Sprite btnRestartHover;
    public Sprite btnRestartClick;

    public Sprite btnStartIdle;
    public Sprite btnStartHover;
    public Sprite btnStartClick;

    // Start is called before the first frame update
    void Start()
    {
        //khi game bắt đầu, thời gian của game sẽ ngưng đọng lại
        //và mọi thứ sẽ trở về bình thường khi player bấm chuột
        Time.timeScale = 0; //thời gian ngưng đọng
        count = x;
        if (count >= 1)
        {
            panelStartGame.SetActive(false);
        }
        else
        {
            panelStartGame.SetActive(true);
        }
        isEndGame = false;
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = gameStartClip[Random.Range(0, gameStartClip.Length)];
        panelEndGame.SetActive(false);
        isStartFirstTime = true;
        isRestart = false;
        //isActiveStartPanel = false;
    }

    // Update is called once per frame
    void Update()
    {
            if (isEndGame)
            {
                if (Input.GetMouseButtonDown(0) && isStartFirstTime)
                {
                    //nếu endgame rồi mà player bấm chuột tiếp thì mình reset lại scene
                    //audioSource.Play();
                    //panelStartGame.SetActive(false);
                    loadScene();
                }
            }
            else
            {
                //trường hợp vẫn chưa endgame (hoặc mới load scene lại) thì time = 1
                if (Input.GetMouseButtonDown(0) && isRestart)
                {
                /*isActiveStartPanel = true;
                if (isActiveStartPanel)
                {
                    /*if (isRestart)
                    {
                        panelStartGame.SetActive(false);
                    }*/
                //panelStartGame.SetActive(false);
                    clickToStartGame();
                }
            }
    }

    public void getPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }

    //Restart Button UI
    public void RestartButtonIdle()
    {
        btnRestart.GetComponent<Image>().sprite = btnRestartIdle;
    }

    public void RestartButtonHover()
    {
        btnRestart.GetComponent<Image>().sprite = btnRestartHover;
    }

    public void RestartButtonClick()
    {
        btnRestart.GetComponent<Image>().sprite = btnRestartClick;
    }

    //Start Button UI
    public void StartButtonIdle()
    {
        btnStart.GetComponent<Image>().sprite = btnStartIdle;
    }

    public void StartButtonHover()
    {
        btnStart.GetComponent<Image>().sprite = btnStartHover;
    }

    public void StartButtonClick()
    {
        btnStart.GetComponent<Image>().sprite = btnStartClick;
    }

    //Game Menu
    public void loadScene()
    {
        SceneManager.LoadScene(0);
        //panelStartGame.SetActive(false);

    }

    public void clickToStartGame()
    {
        //isActiveStartPanel = false;
        //StartGame(isActiveStartPanel);
        Time.timeScale = 1;
        //panelStartGame.SetActive(false);
    }

    public void StartGame()
    {
        panelStartGame.SetActive(false);
        isRestart = true;
        count++;
        audioSource.Play();
    }
    public void RestartGame()
    {
        loadScene();
        audioSource.Stop();
    }

    public void exitGame()
    {
        Application.Quit();
    }
    public void EndGame()
    {
        // khi game kết thúc thì để ngăn không cho player chơi nữa thì cho time = 0 là được
        isEndGame = true;
        isStartFirstTime = false;
        isRestart = true;
        Time.timeScale = 0;
        //audioSource.Stop();
        panelEndGame.SetActive(true);
        //panelStartGame.SetActive(false);
        txtEndPoint.text = "Your point:\n" + gamePoint;
    }
}
