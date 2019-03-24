using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//적의 행동을 결정하는 스크립트
public class EnemyFollow : MonoBehaviour
{
    Color[] colors = {Color.red, Color.green, Color.blue, Color.magenta, Color.yellow, Color.cyan, Color.white}; //색들을 저장함
    public Vector2 speedMinMax;     // 속도의 최소값과 최대값을 설정 x 값은 최소 y값은 최대
    public float speed;     //속도 저장하는 변수
    private Transform target;           // 따라가야하는 타겟의 위치
    private SpriteRenderer rd;          // SpriteRenderer 저장

    private Color targetColor;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<SpriteRenderer>();                  //rd에 SprtieRenderer 컴포넌트 받아옴
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();       // Player라는 테그를 찾고 타겟을 지정
        speed = Mathf.Lerp(speedMinMax.x,speedMinMax.y, Difficulty.GetDifficultyPercent());       // 스피드를 Lerp 함수를 이용하여 시간이지날수록 속도가 올라감
    }
    void Update(){
        CheckPlayerColor();
        follow();       
    }
    private void CheckPlayerColor(){
        targetColor = target.GetComponent<SpriteRenderer>().color;    // 플레이어의 색을 담아두느 변수
    }

    private void follow(){
        if(target != null){
            if(targetColor == Color.grey ){
                transform.position = Vector2.MoveTowards(transform.position,target.position, speed * Time.deltaTime);
            }
            else if(targetColor == Color.red && (rd.color == Color.green || rd.color == Color.blue || rd.color == Color.yellow || rd.color == Color.magenta || rd.color == Color.cyan || rd.color == Color.white) ){
                transform.position = Vector2.MoveTowards(transform.position,target.position, speed * Time.deltaTime);
            }
            else if(targetColor == Color.blue && (rd.color == Color.red || rd.color == Color.green ||rd.color == Color.yellow || rd.color == Color.magenta || rd.color == Color.cyan || rd.color == Color.white) ){
                transform.position = Vector2.MoveTowards(transform.position,target.position, speed * Time.deltaTime);
            }
            else if(targetColor == Color.green && (rd.color == Color.blue || rd.color == Color.red ||rd.color == Color.yellow || rd.color == Color.magenta || rd.color == Color.cyan ||rd.color == Color.white) ){
                transform.position = Vector2.MoveTowards(transform.position,target.position, speed * Time.deltaTime);
            }
            else if(targetColor == Color.yellow && (rd.color == Color.blue || rd.color == Color.magenta || rd.color == Color.cyan || rd.color == Color.white)){
                transform.position = Vector2.MoveTowards(transform.position,target.position, speed * Time.deltaTime);
            }
            else if(targetColor == Color.magenta && (rd.color == Color.green || rd.color == Color.cyan || rd.color == Color.yellow || rd.color == Color.white)){
                transform.position = Vector2.MoveTowards(transform.position,target.position, speed * Time.deltaTime);
            }
            else if(targetColor == Color.cyan && (rd.color == Color.red || rd.color == Color.magenta || rd.color == Color.yellow || rd.color == Color.white)){
                transform.position = Vector2.MoveTowards(transform.position,target.position, speed * Time.deltaTime);
            }
        } 
    }
    
}
