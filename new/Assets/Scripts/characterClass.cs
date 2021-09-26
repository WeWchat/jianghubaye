using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;



public class parentClass
{

    public int sex = 0;
    public string last_name = "";
    public string name = "";
    public int age = 0;
    public int marry = 0;//0代表有  1代表无
    public string husband = "";
    public int child = 0;
    public int childcount = 0;
    public string[] childname = { };

}
public class characterClass : parentClass
{
    // public 

    public int parent;
    public int parentcount = 0;
    public string fathername = "";
    public string mothername = "";



}




public class sonClass : characterClass
{
    public string grandfather;
    public string grandmother;

}


public class PlayerInfo
{
    public string id;
    public string tedian;
    public string miaoshu;
}

public class Root
{
    public List<PlayerInfo> cheng;
    public List<PlayerInfo> hong;
    public List<PlayerInfo> hui;
    public List<PlayerInfo> lan;
    public List<PlayerInfo> lv;
    public List<PlayerInfo> zi;
}
