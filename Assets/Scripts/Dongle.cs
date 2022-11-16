using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dongle : MonoBehaviour
{
    public int level;
    public bool isDrag;
    Rigidbody2D rigid;
    Animator anim;

    // MonoBehaviour
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        anim.SetInteger("Level", level);
    }

    void Update()
    {
        if(isDrag) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // x축 경계 설정 양쪽 Wall 의 두께 +- 둥글 반지름
            float leftBorder = -4.0f + transform.localScale.x / 2;
            float rightBorder = 4.0f - transform.localScale.y / 2;

            if(mousePos.x < leftBorder) {
                mousePos.x = leftBorder;
            }
            else if(mousePos.x > rightBorder) {
                mousePos.x = rightBorder;
            }

            mousePos.y = 8;
            mousePos.z = 0;
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.01f);
        }

                

    }

    // method
    public void Drag()
    {
        isDrag = true;
    }

    public void Drop()
    {
        isDrag = false;
        rigid.simulated = true;
    }
}
