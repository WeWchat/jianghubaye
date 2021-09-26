using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MainUIControl : MonoBehaviour
{
    // Start is called before the first frame update

    bool is_kai = true;
    [SerializeField] GameObject startmenu, gamecanvas;
    // float[] f = new float[3];

    #region 基本属性

    string normalPath = "D:/game属性/人物/基本属性";

    #region 性别
    Button[] sexbtn = new Button[2];
    int sexindex = 0;
    int currrentSex = 0;
    #endregion

    #region 姓名


    string anothername;


    string[] female_nameAll;
    string female_name;

    InputField finalName;
    #endregion

    #region 魅力
    Text meili;
    #endregion

    #region 寿命
    Text shouming;
    #endregion

    #region 造诣
    Text zaoyi;
    #endregion

    #endregion

    #region 服装

    string clothesPath = "D:/game属性/人物/服装";

    Text[] clothes = new Text[8];
    Button[] clothesLeftbtn = new Button[8];
    Button[] clothesrightbtn = new Button[8];
    #endregion

    #region 出身   
    string chushen;

    string aihao;

    Text[] chushentext = new Text[3];
    #endregion

    #region 随机按钮
    Button suijibtn;
    Image dynamicimage;
    float imageposition = 410;
    bool imageup = true;
    bool imagedown = false;
    #endregion

    #region 人物属性
    GameObject[] renwushuxing;
    #endregion

    #region 状态属性
    GameObject[] zhuangtaishuxing;
    Image justimage;
    Sprite[] justordark = new Sprite[2];
    #endregion

    #region 修炼属性
    GameObject[] xiulianshuxing;
    #endregion

    #region 战斗属性
    GameObject[] zhandoushuxing;
    #endregion

    #region 确定或取消
    Button[] conorcanbtn = new Button[2];

    #endregion

    void Start()
    {
        #region 基本属性
        #region 性别
        for (int i = 0; i < 2; i++)
        {
            sexbtn[i] = transform.GetChild(0).GetChild(1).GetChild(10 + i).GetComponent<Button>();
            sexbtn[i].onClick.AddListener(delegate { btn_sex(EventSystem.current.currentSelectedGameObject.name); });
        }

        btn_sex("male");
        #endregion

        #region 姓名
        finalName = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).GetComponent<InputField>();
        #endregion

        #region 魅力
        meili = transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>();
        #endregion

        #region 寿命
        shouming = transform.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>();
        #endregion

        #region 造诣
        zaoyi = transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Text>();
        #endregion

        #endregion

        #region 服装
        for (int i = 0; i < 8; i++)
        {
            clothesLeftbtn[i] = transform.GetChild(0).GetChild(1).GetChild(i).GetChild(0).GetComponent<Button>();
            clothesLeftbtn[i].onClick.AddListener(delegate { btn_clothesleft(EventSystem.current.currentSelectedGameObject); });

            clothesrightbtn[i] = transform.GetChild(0).GetChild(1).GetChild(i).GetChild(1).GetComponent<Button>();
            clothesrightbtn[i].onClick.AddListener(delegate { btn_clothesRight(EventSystem.current.currentSelectedGameObject); });

            clothes[i] = transform.GetChild(0).GetChild(1).GetChild(i).GetChild(2).GetComponent<Text>();
        }
        #endregion

        #region 出身

        //for (int i = 0; i < alltedain.Length; i++)
        //{
        //    anothername += alltedain[i] + ",";
        //}
        //File.WriteAllText(tedianpath, anothername);


        for (int i = 0; i < chushentext.Length; i++)
        {
            chushentext[i] = transform.GetChild(0).GetChild(4 + i).GetChild(0).GetComponent<Text>();
        }

        #endregion

        #region 随机按钮
        suijibtn = transform.GetChild(2).GetComponent<Button>();
        suijibtn.onClick.AddListener(delegate { btn_suiji(currrentSex); });

        dynamicimage = transform.GetChild(3).GetComponent<Image>();
        #endregion

        #region 人物属性

        renwushuxing = new GameObject[strs_usestaticfun(allData.allrenwushuxing).Length]; ;
        for (int i = 0; i < renwushuxing.Length; i++)
        {
            renwushuxing[i] = Instantiate(Resources.Load("Prefabs/模板") as GameObject, transform.GetChild(1).GetChild(0).GetChild(1));
            if (strs_usestaticfun(allData.allrenwushuxing)[i].Length == 5)
            {
                renwushuxing[i].transform.GetChild(0).localPosition = new Vector3(350, 1, 0);
            }
            renwushuxing[i].GetComponent<Text>().text = strs_usestaticfun(allData.allrenwushuxing)[i];
            renwushuxing[i].name = strs_usestaticfun(allData.allrenwushuxing)[i];
        }

        #endregion

        #region 状态属性

        zhuangtaishuxing = new GameObject[strs_usestaticfun(allData.allzhuangtaishuxing).Length];

        for (int i = 0; i < zhuangtaishuxing.Length; i++)
        {
            zhuangtaishuxing[i] = Instantiate(Resources.Load("Prefabs/模板") as GameObject, transform.GetChild(1).GetChild(1).GetChild(1));
            if (strs_usestaticfun(allData.allzhuangtaishuxing)[i].Length == 5)
            {
                zhuangtaishuxing[i].transform.GetChild(0).localPosition = new Vector3(350, 1, 0);
            }
            zhuangtaishuxing[i].GetComponent<Text>().text = strs_usestaticfun(allData.allzhuangtaishuxing)[i];
            zhuangtaishuxing[i].name = strs_usestaticfun(allData.allzhuangtaishuxing)[i];
        }

        justordark[0] = Resources.Load<Sprite>("Pictures/zheng");
        justordark[1] = Resources.Load<Sprite>("Pictures/xie");

        justimage = transform.GetChild(0).GetChild(3).GetComponent<Image>();
        #endregion

        #region  修炼属性

        xiulianshuxing = new GameObject[strs_usestaticfun(allData.allxiulianshuxing).Length];


        for (int i = 0; i < xiulianshuxing.Length; i++)
        {
            xiulianshuxing[i] = Instantiate(Resources.Load("Prefabs/模板") as GameObject, transform.GetChild(1).GetChild(2).GetChild(1));
            if (strs_usestaticfun(allData.allxiulianshuxing)[i].Length == 4)
            {
                xiulianshuxing[i].transform.GetChild(0).localPosition = new Vector3(280, 1, 0);
            }
            xiulianshuxing[i].GetComponent<Text>().text = strs_usestaticfun(allData.allxiulianshuxing)[i];
            xiulianshuxing[i].name = strs_usestaticfun(allData.allxiulianshuxing)[i];
        }
        #endregion

        #region  战斗属性

        zhandoushuxing = new GameObject[strs_usestaticfun(allData.allzhandoushuxing).Length];

        for (int i = 0; i < zhandoushuxing.Length; i++)
        {
            zhandoushuxing[i] = Instantiate(Resources.Load("Prefabs/模板") as GameObject, transform.GetChild(1).GetChild(3).GetChild(1));
            int c = strs_usestaticfun(allData.allzhandoushuxing)[i].Length;
            switch (c)
            {
                case 3:
                    {
                        zhandoushuxing[i].transform.GetChild(0).localPosition = new Vector3(240, 1, 0);
                        break;
                    }
                case 4:
                    {
                        zhandoushuxing[i].transform.GetChild(0).localPosition = new Vector3(280, 1, 0);
                        break;
                    }
                case 5:
                    {
                        zhandoushuxing[i].transform.GetChild(0).localPosition = new Vector3(350, 1, 0);
                        break;
                    }
            }
            zhandoushuxing[i].GetComponent<Text>().text = strs_usestaticfun(allData.allzhandoushuxing)[i];
            zhandoushuxing[i].name = strs_usestaticfun(allData.allzhandoushuxing)[i];
        }
        #endregion

        #region 确定或取消
        for (int i = 0; i < 2; i++)
        {
            conorcanbtn[i] = transform.GetChild(4 + i).GetComponent<Button>();
        }
        conorcanbtn[0].onClick.AddListener(btn_queding);
        conorcanbtn[1].onClick.AddListener(btn_quxiao);

        #endregion
        btn_suiji(0);
    }

    // Update is called once per frame
    void Update()
    {
        dynamic();//动态图片
        justFun();//人物正邪

        // print(Input.mousePosition);
    }

    void btn_sex(string sexindex)
    {
        if (sexindex == "male")
        {
            currrentSex = 0;
        }
        else
        {
            currrentSex = 1;
        }

        for (int i = 0; i < 2; i++)
        {
            sexbtn[i].GetComponent<Image>().enabled = !is_kai;
        }

        sexbtn[currrentSex].GetComponent<Image>().enabled = is_kai;
    }

    void btn_clothesleft(GameObject clothestype)
    {
        int equal = -2;
        string path = "D:/game属性/人物/服装/" + clothestype.transform.parent.name + ".txt";
        string[] allcontents = File.ReadAllLines(path);
        for (int i = 0; i < allcontents.Length; i++)
        {
            if (allcontents[i] == clothestype.transform.parent.GetChild(2).GetComponent<Text>().text)
            {
                equal = i;
            }
        }
        equal--;
        if (equal == -1)
        {
            equal = 4;
        }
        clothestype.transform.parent.GetChild(2).GetComponent<Text>().text = allcontents[equal];
    }

    void btn_clothesRight(GameObject clothestype)
    {
        int equal = -2;
        string path = "D:/game属性/人物/服装/" + clothestype.transform.parent.name + ".txt";
        string[] allcontents = File.ReadAllLines(path);
        for (int i = 0; i < allcontents.Length; i++)
        {
            if (allcontents[i] == clothestype.transform.parent.GetChild(2).GetComponent<Text>().text)
            {
                equal = i;
            }
        }
        equal++;
        if (equal == 5)
        {
            equal = 0;
        }
        clothestype.transform.parent.GetChild(2).GetComponent<Text>().text = allcontents[equal];
    }

    void btn_suiji(int sexindex)
    {
        #region 姓名

        if (sexindex == 0)
        {
            finalName.text = str_usestaticfun(allData.alllastname) + str_usestaticfun(allData.allmalename);
        }
        else
        {
            finalName.text = str_usestaticfun(allData.allfemalename) + str_usestaticfun(allData.allfemalename);
        }

        #endregion

        #region 魅力
        meili.text = Random.Range(1, 30).ToString();
        #endregion

        #region 寿命
        shouming.text = Random.Range(50, 99).ToString();
        #endregion

        #region 造诣

        #endregion

        #region 服装

        transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetComponent<Text>().text = str_usestaticfun(allData.allfashi);
        transform.GetChild(0).GetChild(1).GetChild(1).GetChild(2).GetComponent<Text>().text = str_usestaticfun(allData.allfaxing);
        transform.GetChild(0).GetChild(1).GetChild(2).GetChild(2).GetComponent<Text>().text = str_usestaticfun(allData.allmeimao);
        transform.GetChild(0).GetChild(1).GetChild(3).GetChild(2).GetComponent<Text>().text = str_usestaticfun(allData.allbizhi);
        transform.GetChild(0).GetChild(1).GetChild(4).GetChild(2).GetComponent<Text>().text = str_usestaticfun(allData.allyanjing);
        transform.GetChild(0).GetChild(1).GetChild(5).GetChild(2).GetComponent<Text>().text = str_usestaticfun(allData.allzuiba);
        transform.GetChild(0).GetChild(1).GetChild(6).GetChild(2).GetComponent<Text>().text = str_usestaticfun(allData.alllianxing);
        transform.GetChild(0).GetChild(1).GetChild(7).GetChild(2).GetComponent<Text>().text = str_usestaticfun(allData.allyifu);

        #endregion

        #region 出身      

        chushentext[0].text = str_usestaticfun(allData.allchushen);

        chushentext[1].text = str_usestaticfun(allData.allaihao);

        chushentext[2].text = str_usestaticfun(allData.alltedian);
        #endregion

        #region 人物属性
        shuxingsuijiFun(renwushuxing[0], 1, 30);//力量
        shuxingsuijiFun(renwushuxing[1], 1, 30);//福缘
        shuxingsuijiFun(renwushuxing[2], 1, 30);//敏捷
        shuxingsuijiFun(renwushuxing[3], 1, 30);//炼药成功率
        shuxingsuijiFun(renwushuxing[4], 1, 30);//体质
        shuxingsuijiFun(renwushuxing[5], 1, 30);//炼器成功率
        shuxingsuijiFun(renwushuxing[6], 1, 30);//根骨
        #endregion

        #region 状态属性
        shuxingsuijiFun(zhuangtaishuxing[0], 10, 99);//气血
        shuxingsuijiFun(zhuangtaishuxing[1], 0, 0);//真气
        shuxingsuijiFun(zhuangtaishuxing[2], 100, 100);//食物
        shuxingsuijiFun(zhuangtaishuxing[3], -100, 100);//正邪
        shuxingsuijiFun(zhuangtaishuxing[4], 10, 300);//负重
        #endregion

        #region 修炼属性
        shuxingsuijiFun(xiulianshuxing[0], 1, 100);//剑法资质
        shuxingsuijiFun(xiulianshuxing[1], 1, 100);//奇门资质
        shuxingsuijiFun(xiulianshuxing[2], 1, 100);//刀法资质
        shuxingsuijiFun(xiulianshuxing[3], 1, 100);//内力资质
        shuxingsuijiFun(xiulianshuxing[4], 1, 100);//长兵资质
        shuxingsuijiFun(xiulianshuxing[5], 1, 100);//轻功资质
        shuxingsuijiFun(xiulianshuxing[6], 1, 100);//暗器资质
        shuxingsuijiFun(xiulianshuxing[7], 0, 50);//实战历练
        shuxingsuijiFun(xiulianshuxing[8], 1, 100);//拳脚资质
        #endregion

        #region 战斗属性
        shuxingxiangguanFun(zhandoushuxing[0], renwushuxing[0], 1);//外功攻击力    力量 
        shuxingxiangguanFun(zhandoushuxing[1], renwushuxing[2], 1);//闪避         敏捷
        shuxingxiangguanFun(zhandoushuxing[2], renwushuxing[6], 1);//内功攻击力    根骨
        shuxingxiangguanFun(zhandoushuxing[3], renwushuxing[0], 1);//挥砍防御力    力量
        shuxingxiangguanFun(zhandoushuxing[4], renwushuxing[0], 1);//格挡         力量
        shuxingxiangguanFun(zhandoushuxing[5], renwushuxing[2], 1);//攻速         敏捷
        shuxingxiangguanFun(zhandoushuxing[6], renwushuxing[0], 1);//戳刺防御力    力量
        shuxingxiangguanFun(zhandoushuxing[7], renwushuxing[2], 1);//反击         敏捷
        shuxingxiangguanFun(zhandoushuxing[8], renwushuxing[2], 1);//精准         敏捷
        shuxingxiangguanFun(zhandoushuxing[9], renwushuxing[0], 1);//钝击防御力    力量
        shuxingxiangguanFun(zhandoushuxing[10], renwushuxing[1], 1);//连击        福缘
        shuxingxiangguanFun(zhandoushuxing[11], renwushuxing[4], 1);//暴击率      体质
        shuxingxiangguanFun(zhandoushuxing[12], renwushuxing[4], 1);//毒性防御力   体质
        shuxingxiangguanFun(zhandoushuxing[13], renwushuxing[4], 1);//气血恢复    体质
        shuxingxiangguanFun(zhandoushuxing[14], renwushuxing[4], 1);//暴击伤害    体质
        shuxingxiangguanFun(zhandoushuxing[15], renwushuxing[6], 1);//内功防御力  根骨
        shuxingxiangguanFun(zhandoushuxing[16], renwushuxing[6], 1);//内力恢复    根骨

        #endregion
    }

    void shuxingsuijiFun(GameObject game, int min, int max)
    {
        game.transform.GetChild(0).GetComponent<Text>().text = Random.Range(min, max).ToString();
    }

    void shuxingxiangguanFun(GameObject resoult, GameObject orignal, int rate)
    {
        resoult.transform.GetChild(0).GetComponent<Text>().text = (int.Parse(orignal.transform.GetChild(0).GetComponent<Text>().text) * rate).ToString();
    }

    void dynamic()
    {
        float movespeed = 0.3f;
        if (imageposition <= 410.5)
        {
            imagedown = false;
            imageup = true;
        }
        if (imageposition >= 431.5)
        {
            imagedown = true;
            imageup = false;
        }

        if (imagedown)
        {
            imageposition -= movespeed;
        }
        else
        {
            imageposition += movespeed;
        }
        dynamicimage.transform.localPosition = new Vector3(41.1f, imageposition, 0);
    }

    void justFun()
    {
        if (int.Parse(zhuangtaishuxing[3].transform.GetChild(0).GetComponent<Text>().text) < 0)
        {
            justimage.sprite = justordark[1];
        }
        else
        {
            justimage.sprite = justordark[0];
        }
    }

    void btn_queding()
    {
        string recordPath = "D:/game属性/人物/数值/";

        #region 基本信息
        string jibenpath = recordPath + "基本信息.txt";
        string[] jibencontent = new string[8];
        if (currrentSex == 0)
        {
            jibencontent[0] = "男";
        }
        else
        {
            jibencontent[0] = "女";
        }

        jibencontent[1] = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).GetComponent<InputField>().text;
        jibencontent[2] = transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text;
        jibencontent[3] = transform.GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>().text;
        jibencontent[4] = transform.GetChild(0).GetChild(0).GetChild(3).GetChild(0).GetComponent<Text>().text;

        jibencontent[5] = transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<Text>().text;
        jibencontent[6] = transform.GetChild(0).GetChild(5).GetChild(0).GetComponent<Text>().text;
        jibencontent[7] = transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<Text>().text;


        File.WriteAllLines(jibenpath, jibencontent);

        #endregion

        #region 衣服
        string clothespath = recordPath + "服装.txt";
        string[] clothescontent = new string[9];

        for (int i = 0; i < clothescontent.Length - 1; i++)
        {
            clothescontent[i] = transform.GetChild(0).GetChild(1).GetChild(i).GetChild(2).GetComponent<Text>().text;
        }

        if (int.Parse(zhuangtaishuxing[3].transform.GetChild(0).GetComponent<Text>().text) < 0)
        {
            clothescontent[8] = "邪";
        }
        else
        {
            clothescontent[8] = "正";
        }
        File.WriteAllLines(clothespath, clothescontent);
        #endregion

        #region 属性
        recordFun("人物属性.txt", 7, 0);
        recordFun("状态属性.txt", 5, 1);
        recordFun("修炼属性.txt", 9, 2);
        recordFun("战斗属性.txt", 17, 3);
        #endregion

        gamecanvas.gameObject.SetActive(is_kai);
        gameObject.transform.parent.gameObject.SetActive(!is_kai);
    }

    void btn_quxiao()
    {
        startmenu.gameObject.SetActive(is_kai);
        transform.parent.gameObject.SetActive(!is_kai);
    }

    void recordFun(string path, int length, int childindex)
    {
        string anotherpath = "D:/game属性/人物/数值/" + path;
        string[] content = new string[length];
        for (int i = 0; i < length; i++)
        {
            content[i] = transform.GetChild(1).GetChild(childindex).GetChild(1).GetChild(i).GetChild(0).GetComponent<Text>().text;
        }
        File.WriteAllLines(anotherpath, content);
    }

    string str_usestaticfun(string intstr)
    {
        string str = allData.returnFun(intstr)[Random.Range(0, allData.returnFun(intstr).Length - 1)];
        return str;
    }
    string[] strs_usestaticfun(string intstr)
    {
        string[] strs = allData.returnFun(intstr);
        return strs;
    }
}
