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
    }

    private void OnDisable()
    {
        SwipeBall.OnBallHitWall -= OnBallHitWall;
    }

    void OnBallHitWall(int count)
    {
        countTxt.text = count.ToString();
    }
}
