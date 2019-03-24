using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//유니티 에코 이펙트를 만드는 스크립트
public class EcoEffect : MonoBehaviour
{
    private float timeBtwSpawns;     // 소환대는 시간 간격
    public float startTimeBtwSpawans;   // 최초 시작 시간
    public GameObject echo;             //게임오브젝트 에코를 담는 변수

    // Update is called once per frame
    private Player player;              //플레이어 캐릭터에 생성
    void Start(){
        player = GetComponent<Player>();        //플레이어 컴포넌트를 받아옴
    } 
    void Update()
    {
        if(player.joystick.Horizontal != 0 || player.joystick.Vertical != 0){
            if(timeBtwSpawns <= 0){
            GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
            Destroy(instance,3f);
            timeBtwSpawns = startTimeBtwSpawans;
            } else {
            timeBtwSpawns -= Time.deltaTime; 
            }
        }   
    }
}
