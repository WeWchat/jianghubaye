using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class testscripts : MonoBehaviour
{
    // Start is called before the first frame update

    NavMeshAgent nv;
    Vector3 destination;
    Vector3 vet;
    float x_position = 0;
    float y_position = 0;

    void Start()
    {
        //nv = GetComponent<NavMeshAgent>();
        List<parentClass> grandfatherlist = new List<parentClass>();
        List<parentClass> grandmotherlist = new List<parentClass>();


        List<characterClass> fatherlist = new List<characterClass>();
        List<characterClass> motherlist = new List<characterClass>();

        List<sonClass> sonlist = new List<sonClass>();


        int num = Random.Range(5, 10);



        for (int i = 0; i < num; i++)//生成grandfather
        {
            parentClass grandfather = new parentClass();

            grandfather.sex = 0;//性别

            grandfather.last_name = strfun(allData.alllastname);//姓

            grandfather.name = strfun(allData.allmalename);

            grandfather.age = Random.Range(50, 90);

            grandfather.marry = Random.Range(0, 2);

            grandfather.child = Random.Range(0, 2);

            if (grandfather.child == 0)
            {
                grandfather.childcount = Random.Range(1, 5);
            }


            grandfatherlist.Add(grandfather);
        }

        for (int i = 0; i < grandfatherlist.Count; i++)//生成grandmother
        {
            if (grandfatherlist[i].marry == 0)
            {
                parentClass grandmother = new parentClass();
                grandmother.sex = 1;
                grandmother.last_name = strfun(allData.alllastname);
                grandmother.name = strfun(allData.allfemalename);
                grandmother.age = grandfatherlist[i].age - Random.Range(-10, 10);
                grandmother.husband = grandfatherlist[i].last_name + grandfatherlist[i].name;
                grandfatherlist[i].husband = grandmother.last_name + grandmother.name;
                grandmother.child = grandfatherlist[i].child;
                grandmother.childcount = grandfatherlist[i].childcount;
                grandmotherlist.Add(grandmother);
            }
            if (grandfatherlist[i].marry == 1)
            {
                parentClass grandmother = new parentClass();
                grandmother.sex = 1;
                grandmother.last_name = strfun(allData.alllastname);
                grandmother.name = strfun(allData.allfemalename);
                grandmother.age = Random.Range(50, 90);
                grandmother.child = Random.Range(0, 2);
                grandmother.childcount = Random.Range(1, 6);
                grandmotherlist.Add(grandmother);
            }

        }





        for (int i = 0; i < grandfatherlist.Count; i++)
        {
            if (grandfatherlist[i].child == 0)
            {
                characterClass characterClass = new characterClass();
                characterClass.sex = Random.Range(0, 2);
                if (characterClass.sex == 0)//father
                {
                    characterClass.name = strfun(allData.allmalename);
                    characterClass.age = grandfatherlist[i].age - Random.Range(18, 30);
                    characterClass.marry = Random.Range(0, 2);
                    characterClass.child = Random.Range(0, 2);
                    characterClass.parent = 0;
                    if (grandfatherlist[i].husband != "")
                    {
                        characterClass.parentcount = 2;
                        characterClass.fathername = grandfatherlist[i].last_name + grandfatherlist[i].name;
                        characterClass.mothername = grandfatherlist[i].husband;
                    }
                    else
                    {
                        characterClass.parentcount = 1;
                        characterClass.fathername = grandfatherlist[i].last_name + grandfatherlist[i].name;
                    }


                    fatherlist.Add(characterClass);

                    //print(string.Format("姓名是{0}，年纪是{1}，结婚{2}，孩子{3}，父母数量{4},爸爸是{5}，妈妈是{6}",
                    //    grandfatherlist[i].last_name + characterClass.name, characterClass.age, characterClass.marry, characterClass.child, characterClass.parentcount, characterClass.fathername, characterClass.mothername));




                    //   print(characterClass.name + characterClass.age + characterClass.marry + characterClass.child + characterClass.parent + characterClass.parentcount + characterClass.parentname);
                }
                if (characterClass.sex == 1)//mother
                {
                    characterClass.name = strfun(allData.allfemalename);
                    characterClass.age = grandfatherlist[i].age - Random.Range(18, 30);
                    characterClass.marry = Random.Range(0, 2);
                    characterClass.child = Random.Range(0, 2);
                    characterClass.parent = 0;
                }
                if (grandfatherlist[i].husband != "")
                {
                    characterClass.parentcount = 2;
                    characterClass.fathername = grandfatherlist[i].last_name + grandfatherlist[i].name;
                    characterClass.mothername = grandfatherlist[i].husband;
                }
                else
                {
                    characterClass.parentcount = 1;
                    characterClass.fathername = grandfatherlist[i].last_name + grandfatherlist[i].name;
                }

            }
        }

        for (int i = 0; i < grandmotherlist.Count; i++)
        {
            if (grandmotherlist[i].marry == 1 && grandmotherlist[i].child == 0)
            {

            }
        }

        //for (int i = 0; i < 100; i++)
        //{
        //    print(Random.Range(0, 2));
        //}
        //print(parentlist.Count);
        //print(charalist.Count);


        //for (int i = 0; i < parentlist.Count; i++)
        //{

        //    int jige = -1;
        //    if (parentlist[i].marry == 0)
        //    {
        //        for (int j = 0; j < charalist.Count; j++)
        //        {
        //            if (parentlist[i].last_name + parentlist[i].name == charalist[j].husband)
        //            {
        //                jige = j;
        //            }
        //        }

        //        print(parentlist[i].last_name + parentlist[i].name + "有对象，她是" + charalist[jige].last_name + charalist[jige].name);
        //    }
        //    else if (parentlist[i].marry == 1)
        //    {
        //        print(parentlist[i].last_name + parentlist[i].name + "没有对象");
        //    }

        //}




    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    moveFun();
        //}
    }


    string strfun(string intstr)
    {
        string str = allData.returnFun(intstr)[Random.Range(0, allData.returnFun(intstr).Length - 1)];
        return str;
    }

    //void moveFun()
    //{

    //    destination = Input.mousePosition;
    //    nv.SetDestination(destination);
    //}
}
