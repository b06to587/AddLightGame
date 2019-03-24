using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//아이템이나 물체를 회전하는 스크립트
public class Item : MonoBehaviour
{
    public float speed;         //돌아가는 속도

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f,speed * Time.deltaTime);     //시간에따라 일정한 속도로 회전
    }
}
