using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countTxt;
    
    private void OnEnable()
    {
        SwipeBall.OnBallHitWall += OnBallHitWall;
        SwipeBall.OnLoadLevel += OnLoadLevel;
    }

    private void OnDisable()
    {
        SwipeBall.OnBallHitWall -= OnBallHitWall;
        SwipeBall.OnLoadLevel += OnLoadLevel;
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
        countTxt.text = count.ToString();
    }
}
