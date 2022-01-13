using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class DotWeen : MonoBehaviour
{
    [SerializeField] GameObject Background;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject GameClear;

    void Start()
    {
        Background.transform.DOScale(0, 0).SetEase(Ease.OutBack);
        GameOver.transform.DOScale(0, 0).SetEase(Ease.OutBack);
        GameClear.transform.DOScale(0, 0).SetEase(Ease.OutBack);
    }
    // Update is called once per frame
    void Update()
    {
        if (Player.Instance.IsOver == true)
        {
            Gameover();
        }
        if (GameManager.Instance.IsClear == true)
        {
            Invoke("Gameclear", 3f);
        }
    }
    public void OnButtonClick()
    {
        GameManager.Instance.IsStop = true;
        Background.transform.DOScale(1, 1).SetEase(Ease.OutBack);
        Invoke("TimeStop", 1);
    }
    public void OnExitButtonClick()
    {
        GameManager.Instance.IsStop = false;
        Time.timeScale = 1;
        Background.transform.DOScale(0, 1).SetEase(Ease.InBack);
    }
    public void Gameover()
    {
        GameManager.Instance.IsStop = true;
        GameOver.transform.DOScale(1, 1).SetEase(Ease.OutBack);
        Invoke("TimeStop", 1);
    }
    public void Gameclear()
    {
        GameManager.Instance.IsStop = true;
        GameClear.transform.DOScale(1, 1).SetEase(Ease.OutBack);
        Invoke("TimeStop", 1);
    }
    void TimeStop()
    {
        Time.timeScale = 0;
    }
    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void ReStart()
    {
        SceneManager.LoadScene("Stage1");
    }
}
