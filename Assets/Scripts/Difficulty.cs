using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    // 어려움을 설정하는 클래스 스크립트
public class Difficulty
{
   static float secondsToMasDifficulty = 180; // 가장어려운시간까지 도달하는 시간
   public static float GetDifficultyPercent(){  // 어려움정도를 정하는 함수
       return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMasDifficulty);   // 시간이 지나감에따라 값을 1로 설정 , 시간은 Scene과 함께 초기화
   }
}
