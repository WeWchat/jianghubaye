using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public static class function
{
    public static string readtext(string path)//读取文字
    {
        string m_str = null;
        string[] strs = File.ReadAllLines(path);
        for (int i = 0; i < strs.Length; i++)
        {
            m_str += strs[i];
        }
        return m_str;
    }


    public static void writetext(string path, string content)//写入文字
    {
        FileStream file = new FileStream(path, FileMode.Create);
        byte[] bts = System.Text.Encoding.UTF8.GetBytes(content);
        file.Write(bts, 0, bts.Length);
        if (file != null)
        {
            file.Flush();
            file.Close();
            file.Dispose();
        }
    }

    public static void createDir(string path)//创建文件夹
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    public static void createfile(string path)
    {
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
    }

    public static string[] searchdir(string dirpath)//找到该文件下所有的文件夹
    {
        DirectoryInfo dir = new DirectoryInfo(dirpath);
        DirectoryInfo[] inf = dir.GetDirectories();
        string[] d_file = new string[inf.Length];

        foreach (DirectoryInfo f in inf)
        {
            if (f.Extension.Equals(""))
            {
                for (int t = 0; t < inf.Length; t++)
                {
                    d_file[t] = inf[t].Name;
                }
            }
        }
        return d_file;
    }



    public static string[] searchFile(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] inf = dir.GetFiles();
        string[] d_file = new string[inf.Length];

        foreach (FileInfo f in inf)
        {

            for (int t = 0; t < inf.Length; t++)
            {
                d_file[t] = inf[t].Name;
            }

        }
        return d_file;
    }
    public static string[] searchfile(string filepath, string houzhui)//找文件目录下所有含有该后缀的文件
    {
        DirectoryInfo dir = new DirectoryInfo(filepath);
        FileInfo[] inf = dir.GetFiles();
        string[] d_file = new string[inf.Length];
        string[] file = new string[inf.Length];
        foreach (FileInfo f in inf)
        {
            if (f.Extension.Equals(houzhui))
            {
                for (int t = 0; t < inf.Length; t++)
                {
                    d_file[t] = inf[t].Name;
                }
            }
        }
        for (int z = 0; z < inf.Length; z++)
        {
            file[z] = GetRemoveSuffixString(d_file[z], houzhui);
        }
        return file;
    }

    public static string[] youhouzhuiwenjian(string filepath, string houzhui)
    {
        DirectoryInfo dir = new DirectoryInfo(filepath);
        FileInfo[] inf = dir.GetFiles();
        string[] d_file = new string[inf.Length];
        string[] file = new string[inf.Length];
        foreach (FileInfo f in inf)
        {
            if (f.Extension.Equals(houzhui))
            {
                for (int t = 0; t < inf.Length; t++)
                {
                    d_file[t] = inf[t].Name;
                }
            }
        }

        return d_file;
    }


    public static string GetRemoveSuffixString(string val, string str)//去掉文件后缀名
    {
        string strRegex = @"(" + str + ")" + "$";
        return Regex.Replace(val, strRegex, "");
    }

    public static void deletefile(DirectoryInfo dirs)//删除文件及其子目录
    {
        if (dirs == null || (!dirs.Exists))
        {
            return;
        }
        DirectoryInfo[] subDir = dirs.GetDirectories();
        if (subDir != null)
        {
            for (int i = 0; i < subDir.Length; i++)
            {
                if (subDir[i] != null)
                {
                    deletefile(subDir[i]);
                }
            }
            subDir = null;
        }
        FileInfo[] files = dirs.GetFiles();
        if (files != null)
        {
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i] != null)
                {
                    files[i].Delete();
                    files[i] = null;
                }
            }
            files = null;
        }
    }

    public static string[] readText(string path, char a)//讲一段字符以a分开并返回分开后的字符串
    {
        string[] textAll;
        string text = readtext(path);
        textAll = text.Split(a);
        return textAll;
    }

    public static void open(string path)//打开链接
    {
        if (File.Exists(path))
        {
            Application.OpenURL(path);
        }
    }


    public static Sprite LoadByIo(string url)//读取本地图片
    {
        double startTime = (double)Time.time;
        FileStream fileStream = new FileStream(url, FileMode.Open, FileAccess.Read);//创建文件读取流
        byte[] bytes = new byte[fileStream.Length];//创建文件长度缓冲区
        fileStream.Read(bytes, 0, (int)fileStream.Length);//读取文件
        fileStream.Close();//释放文件读取流
        fileStream.Dispose();//释放本机屏幕资源

        int width = 300;
        int height = 372;
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(bytes);

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        startTime = (double)Time.time - startTime;

        return sprite;
    }

}
