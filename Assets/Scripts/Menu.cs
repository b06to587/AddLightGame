using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//메뉴를 담당하는 스크팁트
public class Menu : MonoBehaviour
{
    public GameObject mainMenuHolder;               //메인메뉴를 가지고있는 오브젝트
    public GameObject optionsMenuHolder;                //옵션메뉴를 가지고있는 오브젝트
    public Slider[] volumeSliders;                      //볼륨 슬라이더 배열 
    // Start is called before the first frame update
    void Start(){
        PlayerPrefs.SetInt("Tutorial_Start",PlayerPrefs.GetInt("Tutorial_Start",0));        // 최초의 튜토리얼을 시작할지 말지 를 결정 처음값음 0

        volumeSliders [0].value = AudioManager.instance.masterVolumePercent;            // 볼륨슬라이더 의 값 을 오디오매니저 인스턴스의 각 값을 가져와 설정
        volumeSliders [1].value = AudioManager.instance.musicVolumePercent;
        volumeSliders [2].value = AudioManager.instance.sfxVolumePercent;
    }
    public void Play(){                                     //플레이 버튼 함수
        if(PlayerPrefs.GetInt("Tutorial_Start")==0){            //튜토리얼을 진행한적이 없다면 즉 값이 0이라면
            PlayerPrefs.SetInt("Tutorial_Start",1);             //1로 바꿔줌
            PlayerPrefs.Save();                                 // 값을 저장
            SceneManager.LoadScene("Tutorial");                 // 튜토리얼을 실행
            
        }else{                  //값이 0이아니라면
        SceneManager.LoadScene("Game");                     //게임을 실행
        }       
      
    }
    public void Quit(){             //종료 함수
        Application.Quit();         //어플리케이션을 종료
    }
    public void OptionsMenu(){              //옵션메뉴를 눌렀을때
        mainMenuHolder.SetActive(false);       //기본메뉴는 inactive
        optionsMenuHolder.SetActive(true);      // 옵션메뉴 activeㅉ
    }
    public void MainMenu(){                 // 메인메뉴
        mainMenuHolder.SetActive(true);     // 기본메뉴 active
        optionsMenuHolder.SetActive(false); // 옵션메뉴 inactive
    }
    public void SetMasterVolume(float value){           //마스터볼륨 설정하는 함수
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
    }
    public void SetMusicVolume(float value){            // 음악볼륨을 설정하는 함수
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
    }
    public void SetSfxVolume(float value){                  // 이펙트 볼륨을 설정한느 함수
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Sfx);
    }
}
