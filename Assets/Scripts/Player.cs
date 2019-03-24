using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//플레이어 스크립트
public class Player : MonoBehaviour
{
    private enum ColorState{
        Idle,First,Second,Third
    }
    ColorState state = ColorState.Idle;

    [SerializeField]
    private GameObject deathEffect;      // 죽었을때 이펙트
    [SerializeField]
    private float speed;                 // 속도
    public event System.Action OnPlayerDeath;   //이벤트 OnPlayerDeath
    public event System.Action OnScoreCount;    //이벤트 OnScoreCount
    private SpriteRenderer playerRenderer;

    public Joystick joystick;           //조이스틱
    [SerializeField]
    private ColorGauge colorGauge; 
    int itemCount; 
    void Start(){   
        itemCount = 0;  
        playerRenderer = GetComponent<SpriteRenderer>();
        playerRenderer.color = Color.grey;  
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        checkColor(playerRenderer.color); 
         
    }

    //플레이어를 움직임
    private void Move(){
        Vector2 moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);   

        if (moveVector != Vector2.zero){         
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);  
            transform.Translate(moveVector * speed * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerEnter2D(Collider2D col){          
        if(col.tag == "Enemy"){
            DestroyEnemy(col);
            colorGauge.leftTime += 1.5f;
        }
        else if(col.tag == "Item"){
            itemCount++;
            Color itemColor = col.GetComponent<SpriteRenderer>().color;
            changeColor(itemColor);
            AudioManager.instance.PlaySound2D("ItemSound");

            if(itemCount > 1)
            colorGauge.leftTime += 2.5f;
            
            col.gameObject.SetActive(false);
           
        }
    }

    private void DestroyEnemy(Collider2D col){
        Color enemyColor = col.GetComponent<SpriteRenderer>().color;
        if(enemyColor == playerRenderer.color){
            col.gameObject.SetActive(false);
            AudioManager.instance.PlaySound2D("EnemyDeath");
            OnScoreCount();
        }
        else if(playerRenderer.color == Color.yellow && (enemyColor == Color.green || enemyColor == Color.red)){
            AudioManager.instance.PlaySound2D("EnemyDeath");
            col.gameObject.SetActive(false);
            OnScoreCount();
            OnScoreCount();
        }
        else if(playerRenderer.color == Color.cyan && (enemyColor == Color.green || enemyColor == Color.blue)){
            AudioManager.instance.PlaySound2D("EnemyDeath");
            col.gameObject.SetActive(false);
            OnScoreCount();
            OnScoreCount();
        }
        else if(playerRenderer.color == Color.magenta && (enemyColor == Color.blue || enemyColor == Color.red)){
            AudioManager.instance.PlaySound2D("EnemyDeath");
            col.gameObject.SetActive(false);
            OnScoreCount();
            OnScoreCount();
        }
        else if(playerRenderer.color == Color.white){
            col.gameObject.SetActive(false);
            AudioManager.instance.PlaySound2D("EnemyDeath");
            OnScoreCount();
            OnScoreCount();
            OnScoreCount();
        }
        else if(OnPlayerDeath != null){
            OnPlayerDeath();
            AudioManager.instance.PlaySound2D("deathSound");
            Instantiate(deathEffect,transform.position,Quaternion.identity);
            gameObject.SetActive(false);
        }    
    }

    //색을 변화시키는 메소드
    private void changeColor(Color newColor){           
        if(playerRenderer.color == Color.grey){
            playerRenderer.color = newColor;
            state = ColorState.First;
        } else if((playerRenderer.color == Color.green && newColor == Color.red)||(playerRenderer.color == Color.red && newColor == Color.green)){
            playerRenderer.color = Color.yellow;
            state = ColorState.Second;
        }else if((playerRenderer.color == Color.green && newColor == Color.blue)||(playerRenderer.color == Color.blue && newColor == Color.green)){
            playerRenderer.color = Color.cyan;
            state = ColorState.Second;
        }else if((playerRenderer.color == Color.red && newColor == Color.blue)||(playerRenderer.color == Color.blue && newColor == Color.red)){
            playerRenderer.color  = Color.magenta;
            state = ColorState.Second;
        }else if((playerRenderer.color == Color.yellow && newColor == Color.blue)||(playerRenderer.color == Color.magenta && newColor == Color.green)||(playerRenderer.color == Color.cyan && newColor == Color.red)){
            playerRenderer.color  = Color.white;
            state = ColorState.Third;
        }
    }

    public void checkColor(Color newColor){
        colorGauge.changeColor(newColor);
        if(state == ColorState.First)
           colorGauge.DecreaseGuage(0.8f);

        else if(state == ColorState.Second){
           colorGauge.DecreaseGuage(2.1f);
        }
        else if(state == ColorState.Third)
           colorGauge.DecreaseGuage(3.1f);

        if(colorGauge.leftTime<0){
            ResetColor();
           
        } 
    }
    private void ResetColor(){
        playerRenderer.color = Color.grey;
        colorGauge.leftTime = 10f;
        state = ColorState.Idle;
        itemCount = 0;
    }
}
