using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }
        Destroy(this.gameObject);
    }

    [Header("Windows")]
    [SerializeField] private Window gamePanel;
    [SerializeField] private Window rewardPanel;
    [SerializeField] private Window loosePanel;
    [SerializeField] private Window taskPanel;

    //[Space]
    //[Header("Timer")]
    //[SerializeField] private StartTimer timer;

    [Space]
    [Header("Bonuses")]
    [SerializeField] private Text bonusesText;
    [SerializeField] private Text winBonusesText;
    public int CoinsScore;
    public int CountCoin;
    private int curCountCoin;

    public static Action<int> OnSelectCoin;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        Time.timeScale = 1;
        OnSelectCoin += UpdateBonusesUI;
        CheckBonuses();

    }

    private void UpdateBonusesUI(int bonus)
    {
        CoinsScore += bonus;
        curCountCoin++;
        bonusesText.text = curCountCoin.ToString() + "/" + CountCoin.ToString();
        winBonusesText.text = "+" + CoinsScore.ToString();
    }

    private void CheckBonuses()
    {
        CoinsScore = PlayerPrefs.GetInt($"{GlobalStrings.BONUSES_STRING}");
    }
    public void WinGame()
    {
        Time.timeScale = 0;
        rewardPanel.Open_Instantly();
    }
    public void LoadNextLevel()
    {

    }

    public void ShowTaskWindow()
    {
        taskPanel.Open_Instantly();
    }

    public void LooseGame()
    {
        Time.timeScale = 0;
        loosePanel.Open_Instantly();
    }

    private void OnDisable()
    {
        OnSelectCoin -= UpdateBonusesUI;

    }
}
