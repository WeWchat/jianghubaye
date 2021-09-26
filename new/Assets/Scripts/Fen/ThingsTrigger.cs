using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingsTrigger : MonoBehaviour
{
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "heliu")
        {
            transform.position = new Vector2(pos.x - 2, pos.y - 2);
            Debug.Log("生成错误");
            Debug.Log(transform.name);
            Debug.Log(pos);
        }
    }
}
