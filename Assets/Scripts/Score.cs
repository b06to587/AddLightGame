using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//스코어 저장하고 보여주는 스크립트
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;       // TextMeshProUGUI를 사용한 스코어 텍스트
    public int scores = 0;              // 처음스코어는 0

    void Start()
    {
        FindObjectOfType<Player> ().OnScoreCount += AddScore;   //일정행동을 할때마다 스코어함수를 실행  :: 이벤트
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = scores.ToString();             // 스코어 텍스트 설정
        if(scores > PlayerPrefs.GetInt("HighScore", 0)){        //새로운 스코어가 하이스코어보다 크다면
            PlayerPrefs.SetInt("HighScore", scores);            //새로운 하이스코어로 저장
        }
    }
    public void AddScore(){             // 점수를 1점씩 더함
        scores += 1;   
    }

}
