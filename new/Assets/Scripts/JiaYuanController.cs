using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiaYuanController : MonoBehaviour
{
    private float mainTime;
    public float clickTime;
    private float twoClickTime;
    private int count;
    private void Awake()
    {
        GameObject ui = Resources.Load<GameObject>("Prefabs/UI");
        Instantiate(ui);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //MouseJianCe();
    }
    //检测鼠标长按或者双击
    void MouseJianCe()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (mainTime == 0.0f)
            {
                mainTime = Time.time;
            }
            if (Time.time - mainTime > 1.5f)
            {
                Debug.Log("长按");
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "jiayuan")
                    {
                        Debug.Log("长按");//长按时执行的动作放这里
                    }
                }
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (Time.time - mainTime < 0.2f)
            {//当鼠标抬起时，检测按下到抬起的时间，如果小于2.0f就判断为点击。

                if (twoClickTime != 0 && Time.time - twoClickTime < 0.2f)
                {
                    count = 2;
                }
                else
                {
                    count++;
                    if (count == 1)
                    {
                        clickTime = Time.time;
                    }
                }
                if (count == 2
                    && ((clickTime != 0 && Time.time - clickTime < 0.2f) || (twoClickTime != 0 && Time.time - twoClickTime < 0.2f)))
                {//如果两次点击事件小于0.2f就判断为双击
                 //双击时执行的代码块
                    count = 0;
                    Debug.Log("双击");
                }
                if (count == 2 && (Time.time - clickTime > 0.2f || Time.time - twoClickTime > 0.2f))
                {
                    twoClickTime = Time.time;
                    count = 0;
                }
                mainTime = 0.0f;
            }
            else
            {
                mainTime = 0.0f;
            }
        }
    }
    void JianZao()
    {

    }
}
