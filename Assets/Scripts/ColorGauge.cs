using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 변한 색깔의 남은 시간을 보여주는 스크립트
public class ColorGauge : MonoBehaviour
{
    public Image colorBar;     // 이미지
    public float maxGauge = 10f;
    public float leftTime;
    // Start is called before the first frame update
    void Start()
    {
        colorBar = GetComponent<Image>();
        leftTime = maxGauge;                 // 남은 양은 맥스 게이지 양  
    }
    void Update(){
        colorBar.fillAmount = leftTime/maxGauge;      
    }

    public void DecreaseGuage(float decreaseAmount){
        leftTime -= decreaseAmount * Time.deltaTime;
    }
    public void changeColor(Color getColor){
        colorBar.color = getColor;
    }
}
