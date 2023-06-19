using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countTxt;
    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private GameObject winUI;
    private void OnEnable()
    {
        SwipeBall.OnBallHitWall += OnBallHitWall;
        SwipeBall.OnLoadLevel += OnLoadLevel;
        SwipeBall.OnLevelCompeleted += OnLevelCompleted;
    }

    private void OnDisable()
    {
        SwipeBall.OnBallHitWall -= OnBallHitWall;
        SwipeBall.OnLoadLevel -= OnLoadLevel;
        SwipeBall.OnLevelCompeleted -= OnLevelCompleted;
    }

    void OnBallHitWall(int count)
    {
        countTxt.text = count.ToString();
        LeanTween.cancel(countTxt.gameObject);
        LeanTween.scaleX(countTxt.gameObject, 8.0f, 0.5f).setEasePunch();
        LeanTween.scaleY(countTxt.gameObject, 8.0f, 0.5f).setEasePunch();
    }

    void OnLoadLevel(int count)
    {
        winUI.SetActive(false);
        countTxt.text = count.ToString();
        levelTxt.text ="Level " + LevelManager.Instance.CurLevelIndex;
    }

    void OnLevelCompleted()
    {
        winUI.SetActive(true);
    }
}
