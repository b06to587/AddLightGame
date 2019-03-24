using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//튜토리얼에서 게임으로 넘아가는 스크립트
public class TutorialManager : MonoBehaviour
{   
    public void gameStart(){
        SceneManager.LoadScene("Game"); // 게임실행
    }
}
