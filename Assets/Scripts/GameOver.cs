using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
//게임 오버를 보여주는 스크립트
public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;       // 게임오버 스크린을 담아두는 게임오브젝트 변수
    public TextMeshProUGUI highScore;        // TextmeshproUGUI를 사용한 하이스코어 Text
    public TextMeshProUGUI currentScore;    // TextmeshproUGUI를 사용한 현재점수 Text
    

    public Score score;         //스코어 스크립트를 담아옴
    public bool gameOver;       // 게임오버를 체크하는 bool 변수
    
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Player> ().OnPlayerDeath += OnGameOver;    // event 시스템 player 에서 OnPlayerDeath call 시에 OnGameOver 실행
    }
    void OnGameOver(){
        gameOverScreen.SetActive(true);                                                               //게임오버 스크린을 보여줌
        highScore.text = "High Score : " + PlayerPrefs.GetInt("HighScore",score.scores).ToString();  //하이스코어를 가져옴
        currentScore.text  = "Score : " + score.scores.ToString();                                   // 지금 스코어를 보여줌
        gameOver = true;                                                                             // 게임오버
    }
    public void RestartGame(){                  //게임을 재시작하는 함수
         SceneManager.LoadScene(1);
    }

    public void gotoMenu(){                 //메뉴스크린으로 돌아가는 함수
        SceneManager.LoadScene(0);
    }
}
