using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//적과 아이템을 생성하는 스크립트
public class Spawner : MonoBehaviour
{
   [SerializeField]
   private GameObject player;        // 플레이어 게임오브젝트를 담는 변수
   public GameOver gameOver;        // 게임오버 스크립트를 가져옴

   //enemy
   [SerializeField]
   private GameObject EnemyPrefab;      // 적의 프리팹을 담는 게임 오브젝트
   private SpriteRenderer sr;          //적의 색을 담는 SpriteRenderer
   public Vector2 secondsBetweenSpawnsMinMax;    //적이 생성대는 최소, 최대시간을 담는 변수
   float nextSpawnTime;                   // 다음 소환 시간

   //item
   public GameObject Itemprefab;    // 아이템의 프리펩을 담는 게임 오브젝트
   private SpriteRenderer isr;      // 아이템의 색을담는 spriteRenderer
   public Vector2 secondsBetweenItemSpawnsMinMax;  // 아이템생서의 최소, 최대 시간을 담는 변수
   float nextItemSpawnTime;            //다음 아이템이 소환되는 시간
   
   Vector2 rightTop;                   //오른쪽 상단 포지션
   
   public int Enemycount;       //Enemy 소환수를 카운트
    
   Color[] colors = {Color.red,Color.green,Color.blue, Color.yellow, Color.magenta, Color.cyan, Color.white}; //색을 담아두는 어레이
    // Start is called before the first frame update
   void Start(){        
      rightTop = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);          // 카메라오른쪽 상단 위치를 지정
      sr = EnemyPrefab.GetComponent<SpriteRenderer>();                              // Enmey 프리팹의 sprtieRenderer 가져옴
      isr = Itemprefab.GetComponent<SpriteRenderer>();                              // Item 프리팹의 spriteRenderer 가져옴

      StartCoroutine(SpawnItemCoroutine());
      StartCoroutine(SpawnEnemyCoroutine());
   }

   IEnumerator SpawnEnemyCoroutine(){
     while(!gameOver.gameOver){
         float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent()); // 다음 적 생성까지의 시간 1->0 으로 점점빨라짐

         Vector2 spawnPosition = new Vector2(Random.Range(-rightTop.x,rightTop.x),Random.Range(-rightTop.y-(player.transform.position.y/2), rightTop.y+(player.transform.position.y/2)));    // 적의 생성위치를 랜덤으로 지정 그러나 플레이어의 현제 위치보다는 크게
            
         Instantiate(EnemyPrefab,spawnPosition,Quaternion.identity);              //적을 생성위치에 생성 
         Enemycount++;              
         GiveColoronEnemy(Enemycount);   

         yield return new WaitForSeconds(secondsBetweenSpawns);
      }
   }

   //아이템 생성한느 코루틴
   IEnumerator SpawnItemCoroutine(){
      while(!gameOver.gameOver){     
            float secondsBetweenItemSpawns = Mathf.Lerp(secondsBetweenItemSpawnsMinMax.y, secondsBetweenItemSpawnsMinMax.x, Difficulty.GetDifficultyPercent());

            Vector2 spawnPosition = new Vector2(Random.Range(-rightTop.x+1.5f, rightTop.x-1.5f),Random.Range(-rightTop.y+1.5f, rightTop.y-1.5f));     //플레이어의 위치도 상관없음 맵전체내에서 생성
            Instantiate(Itemprefab, spawnPosition, Quaternion.identity);         //아이템을 생성
            isr.color = colors[Random.Range(0,3)];    

            yield return new WaitForSeconds(secondsBetweenItemSpawns);                         //기본적인 색을 지정해줌
         }
      
   }
   private void GiveColoronEnemy(int count){
      if(count < 15)                    //카운트가 15보다 작을때는 
         sr.color = colors[Random.Range(0,3)];        // 빨강 , 파랑, 초록 기본색만 소환
      else if(count <30)                         //30보다 작을때는 
         sr.color = colors[Random.Range(0,6)];        // 하얀색을 제외한 모든 색을 소환
      else   
         sr.color = colors[Random.Range(0,7)];        //모든 랜덤 색 소환 
   }
}

