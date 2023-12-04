using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text str_lives;
    public Text prince_talk;
    public int quizz;
    public int lives;

    private int score;
    public List<int> check;
    public int Score { get => score; }
    public AudioClip wrongAnswer;
    public AudioClip correctAnswer;
    public AudioClip burnAcid;
    public AudioClip lose;
    private AudioSource audioSource;
    public GameObject gameOverDialog;
    public GameObject gamePauseDialog;
    public GameObject winDialog;
    public GameObject dialog;
    public GameObject princess;
    public GameObject prince;
    private Animator animator;
    public Text rightAnswer;
    public GameObject MainMenu;
    public GameObject InsideDialog;
    public GameObject btnOK2;
    private SavingData saveData;

    private void Start()
    {
        Init();
        lives = int.Parse(str_lives.text);
        prince_talk.text = "";
        audioSource = this.GetComponent<AudioSource>();
        saveData = this.GetComponent<SavingData>();
    }
    public void Init()
    {
        str_lives.text = "10";
        quizz = UnityEngine.Random.Range(1, 101);
        GameObject princess = GameObject.Find("Princess");
        GameObject GamePlayUI = GameObject.Find("GamePlayUI");
        princess.transform.position = new Vector2(1920-250, 540);
        gamePauseDialog.SetActive(false);
        gameOverDialog.SetActive(false);
        winDialog.SetActive(false);
        AudioSource audioFire = GameObject.Find("Fire").GetComponent<AudioSource>();
        audioFire.Play();
        Time.timeScale = 1;
    }
    public string CheckAnswer(int number)
    {
        string msg = null;
        if (number == 0) return msg;
        if (number == quizz)
        {
            audioSource.clip = correctAnswer;
            audioSource.volume = 0.5f;
            audioSource.Play();
            msg = "Nooooooo!";
        }
        else if (number < quizz)
        {
            audioSource.clip = wrongAnswer;
            audioSource.volume = 0.5f;
            audioSource.Play();
            if (quizz - number > 10)
                msg = "Too low!";
            else
                msg = "Higher!";
            lives--;
            str_lives.text = lives.ToString();
        }
        else
        {
            audioSource.clip = wrongAnswer;
            audioSource.volume = 0.5f;
            audioSource.Play();
            if (number - quizz > 10)
                msg = "Too high!";
            else
                msg = "Lower!";
            lives--;
            str_lives.text = lives.ToString();
        }
        if (lives == 0)
        {
            audioSource.clip = burnAcid;
            audioSource.Play();
            audioSource.clip = lose;
            audioSource.Play();
        }
        return msg;
    }
    public void GamePause()
    {
        gamePauseDialog.SetActive(true);
        Text numberOfGuess = GameObject.FindGameObjectWithTag("NumberOfGuess").GetComponent<Text>();
        numberOfGuess.text = str_lives.text;
        AudioSource audioFire = GameObject.Find("Fire").GetComponent<AudioSource>();
        audioFire.Pause();
        Time.timeScale = 0;
    }
    public void Continue()
    {
        gamePauseDialog.SetActive(false);
        AudioSource audioFire = GameObject.Find("Fire").GetComponent<AudioSource>();
        audioFire.Play();
        Time.timeScale = 1;
    }
    public IEnumerator checkGameOver(string lives)
    {
        if (lives == "0")
        {
            animator = prince.GetComponent<Animator>();
            animator.SetTrigger("Dead");
            yield return new WaitForSeconds(2);
            gameOverDialog.SetActive(true);;
            rightAnswer.text = quizz.ToString();
            AudioSource audioFire = GameObject.Find("Fire").GetComponent<AudioSource>();
            audioFire.Pause();
            saveData.SaveData();
            Time.timeScale = 0;
        }
    }
    public IEnumerator WinState(bool orcDead)
    {
        if (orcDead)
        {
            yield return new WaitForSeconds(2);
            winDialog.SetActive(true);
            AudioSource audioFire = GameObject.Find("Fire").GetComponent<AudioSource>();
            audioFire.Pause();
            Time.timeScale = 0;
            Text numberOfGuess = GameObject.FindGameObjectWithTag("NumberOfGuess").GetComponent<Text>();
            numberOfGuess.text = str_lives.text;
            saveData.SaveData();
        }
    }
    public void PauseGameBackToHome()
    {
        dialog.SetActive(true);
    }
    public void BackToHome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    private void Update()
    {
        StartCoroutine(checkGameOver(str_lives.text));
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void checkDialogResult()
    {
        DialogResult dialogResult = dialog.GetComponent<DialogResult>();
        if (dialogResult.getOK() == true)
        {
            InsideDialog.SetActive(true);
            GameObject number = GameObject.FindGameObjectWithTag("NumberOfRightAnswer");
            Text num = number.GetComponent<Text>();
            num.text = quizz.ToString();
            GameObject btnOK = GameObject.Find("btnOK");
            btnOK.SetActive(false);
            GameObject btnCancel = GameObject.Find("btnCancel");
            btnCancel.SetActive(false);
            btnOK2.SetActive(true);
        }
        else
        {
            dialog.SetActive(false);
            gamePauseDialog.SetActive(true);
        }
    }
}
