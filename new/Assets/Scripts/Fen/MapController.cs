using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public Transform player;
    public GameObject[] things;//预制体
    public int thingsNum;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;//边界
    private void Awake()
    {
        GameObject ui = Resources.Load<GameObject>("Prefabs/UI");
        Instantiate(ui);
    }
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < thingsNum; i++)
        {
            Instantiate(things[Random.Range(0, things.Length)], new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        KuaiJie();
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.transform.tag);
                if (hit.transform.tag == "jiayuan")
                {
                    hit.transform.GetComponent<Collider2D>().isTrigger = false;
                }
            }
        }
    }
    void KuaiJie()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(2);
        }
    }
}
