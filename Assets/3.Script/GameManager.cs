using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public static bool isGameOver = false;
    [Header("script")]
    public PlayerData playerData;

    [Header("Button")]
    public Button reStratBtn;
    public Button ExitBtn;

    [Header("GameOverUI")]
    public GameObject gameOverUI;
    public GameObject player;

    private void Awake()
    {
        if(Instance != null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    private void Start()
    {
        
        playerData = FindObjectOfType<PlayerData>();

        if (reStratBtn != null)
        {
            reStratBtn.onClick.AddListener(RestartGame);
        }

        if (ExitBtn != null)
        {
            ExitBtn.onClick.AddListener(Exit);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Exit()
    {
        Application.Quit();
    }

    private void Update()
    {
        Player_Dead();        
    }

    public void Player_Dead()
    {        
        int playerHP = playerData.Player_HP;
        if (playerHP <= 0)
        {
            isGameOver = true;
            gameOverUI.SetActive(true);
            player.SetActive(false);
        }
    }
}
