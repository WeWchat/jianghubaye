using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.IO;
using UnityEngine.EventSystems;
public class startUI : MonoBehaviour
{
    // Start is called before the first frame update
    Button[] mainbtn = new Button[5];
    [SerializeField] GameObject createCanvas, gamecanvas;
    bool is_kai = true;


    DirectoryInfo d_info;
    DirectoryInfo[] d_info2;

    Sprite[] sp = new Sprite[2];


    void Start()
    {
        for (int i = 0; i < mainbtn.Length; i++)
        {
            mainbtn[i] = transform.GetChild(1).GetChild(i).GetComponent<Button>();
        }
        mainbtn[0].onClick.AddListener(btn_newStart);
        mainbtn[1].onClick.AddListener(btn_load);
        mainbtn[2].onClick.AddListener(btn_award);
        mainbtn[3].onClick.AddListener(btn_setting);
        mainbtn[4].onClick.AddListener(btn_exit);

        gameinit();

        d_info = new DirectoryInfo("D:/game属性/人物");
        d_info2 = d_info.GetDirectories();

        sp[0] = Resources.Load<Sprite>("Pictures/正常外框");
        sp[1] = Resources.Load<Sprite>("Pictures/点击框");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void btn_newStart()
    {
        createCanvas.gameObject.SetActive(is_kai);
        transform.parent.gameObject.SetActive(!is_kai);
    }

    void btn_load()
    {
        transform.GetChild(2).gameObject.SetActive(is_kai);
        StartCoroutine(open());

    }

    void btn_award()
    {

    }

    void btn_setting()
    {

    }

    void btn_exit()
    {

    }

    void gameinit()
    {

    }

    IEnumerator open()
    {
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(2).GetChild(0).DOScale(new Vector3(1, 1, 1), 0.5f);
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(is_kai);

        if (transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).childCount == 0)
        {
            for (int i = 0; i < d_info2.Length; i++)
            {
                readRecord(i);
            }

            transform.GetChild(2).GetChild(1).GetChild(1).GetComponent<Button>().onClick.AddListener(btn_closerecord);

        }
        else { 
        //transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetComponent<scrol>
        }

    }

    void readRecord(int index)
    {
        GameObject gb = Instantiate(Resources.Load("Prefabs/renwudangan") as GameObject, transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0));
        gb.GetComponent<Image>().sprite = sp[0];
        gb.GetComponent<Image>().SetNativeSize();
        gb.GetComponent<Button>().onClick.AddListener(btn_cundang);
        gb.name = d_info2[index].Name;
        gb.transform.GetChild(0).GetComponent<Text>().text = d_info2[index].Name;
        gb.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = returnstr(d_info2[index].Name, 0);
        gb.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { btn_delete(EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.name); });
        gb.transform.GetChild(3).GetComponent<Text>().text = returnstr(d_info2[index].Name, 1);
        gb.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = returnstr(d_info2[index].Name, 2);
        gb.transform.GetChild(5).GetComponent<Text>().text = returnstr(d_info2[index].Name, 3);

    }

    string returnstr(string str, int index)
    {
        string[] strs = File.ReadAllLines(string.Format("D:/game属性/人物/{0}/存档数据.txt", str));
        return strs[index];
    }

    void btn_delete(string str)
    {
        DirectoryInfo df = new DirectoryInfo(string.Format("D:/game属性/人物/{0}", str));
        function.deletefile(df);
        Directory.Delete(string.Format("D:/game属性/人物/{0}", str));
        for (int i = 0; i < transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).childCount; i++)
        {
            Destroy(transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(i).gameObject);
        }
        d_info = new DirectoryInfo("D:/game属性/人物");
        d_info2 = d_info.GetDirectories();

        for (int i = 0; i < d_info2.Length; i++)
        {
            readRecord(i);
        }
    }

    void btn_closerecord()
    {
        transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(!is_kai);
        transform.GetChild(2).GetChild(0).DOScale(new Vector3(1, 0, 1), 0.5f);
        StartCoroutine(close());
    }

    IEnumerator close()
    {
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(2).gameObject.SetActive(!is_kai);
    }

    void btn_cundang()
    {
        for (int i = 0; i < transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).childCount; i++)
        {
            transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(i).GetComponent<Image>().sprite = sp[0];
            transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(i).GetComponent<Image>().SetNativeSize();
        }
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = sp[1];
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().SetNativeSize();
        print("进入主场景了");
    }
}
