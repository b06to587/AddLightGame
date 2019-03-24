using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//게임의 시간을 멈추는 pause 기능을하는 스크립트
public class PauseGame : MonoBehaviour
{
    public GameObject pauseScreen;      //pause 스크린을 담고있음
    bool GamePaused =  false;               //퍼즈상태가아님
    public void Resume(){               //다시시작
        pauseScreen.SetActive(false);       //퍼즈스크린 inactive
        Time.timeScale = 1f;                    //타임스케일을 1로만듬
        GamePaused = false;                     // 게임멈충상태가 false
    }
    public void Pause(){            //멈춤
        pauseScreen.SetActive(true);        // 퍼즈스크린 active
        Time.timeScale = 0f;                // 타임스케일을 0으로 만듬
        GamePaused = true;                  //   게임멈춤 상태
    }
}