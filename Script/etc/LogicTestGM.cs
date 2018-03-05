/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicTestGM : MonoBehaviour {
    #region Popetey

    private bool developerMod = true;
    public bool DeveloperMod
    {
        get
        {
            return developerMod;
        }
        set
        {
            developerMod = value;
        }
    }

    #endregion

    #region Variables

    public float timeSpeed = 1;

    public float cloudRate;
    public float carRate;

    public Transform cloudGeneratePos;
    public Transform carGeneratePos;
    //public Transform NPCGeneratePos;
    public Transform parent;
    public Transform recyclePos;

    Object cloudObject;
    Object carObject;
    //Object npcObject;

    float gameTime;
    float cloudTimer = 0;
    float carTimer = 0;
    #endregion

    #region Unity Methods

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update () 
	{
        ChangeGameSpeed();
        ChangeDevMod();
        CarType();
        ObjectRecycle();
        CloudType();
    }

    void GameTime()
    {
        gameTime = Time.time;
    }

    void ChangeGameSpeed()
    {
        Time.timeScale = timeSpeed;
    }

    void ChangeDevMod()
    {
        if (Input.GetKeyDown(KeyCode.F8))
        {
            if (developerMod)
            {
                developerMod = false;
            }
            else if (!developerMod)
            {
                developerMod = true;
            }
            Debug.Log(developerMod);
        }
    }

    //以停用
    void CloudType()
    {
        if (Time.time> cloudTimer)
        {
            Debug.Log("Try to create cloud");
            cloudTimer = Time.time + cloudRate;
            int cloudType = Random.Range(0, 3);
            switch (cloudType)
            {
                case 0:
                    cloudObject = Resources.Load(Define.Clouds1Path);
                    //Debug.Log("Now obj is " + obj);
                    //Load Resources
                    break;

                case 1:
                    cloudObject = Resources.Load(Define.Clouds2Path);
                    //Debug.Log("Now obj is " + obj);
                    //Load Resources
                    break;

                case 2:
                    cloudObject = Resources.Load(Define.Clouds3Path);
                    //Debug.Log("Now obj is " + obj);
                    //Load Resources
                    break;
                default:
                    break;
            }
            ObjectCreater(cloudObject, cloudGeneratePos);
        }
    
    }

    void CarType()
    {
        if (Time.time > carTimer)
        {
            carTimer = Time.time + carRate;
            int carType = Random.Range(0, 4);
            switch (carType)
            {
                case 0:
                    carObject = Resources.Load(Define.Car1);
                    //Debug.Log("Now obj is " + obj);
                    //Load Resources
                    break;

                case 1:
                    carObject = Resources.Load(Define.Car2);
                    //Debug.Log("Now obj is " + obj);
                    //Load Resources
                    break;

                case 2:
                    carObject = Resources.Load(Define.Car3);
                    //Debug.Log("Now obj is " + obj);
                    //Load Resources
                    break;
                case 3:
                    carObject = Resources.Load(Define.Car4);
                    //Debug.Log("Now obj is " + obj);
                    //Load Resources
                    break;
                default:
                    break;
            }
            ObjectCreater(carObject, carGeneratePos);
        }
    }

    void NpcType()
    {

    }

    void ObjectCreater(Object obj, Transform createPos)
    {
        //car
        //npc
        //cloud
        //先在一個Function隨機種類，再傳到另一個Function進行生成
        GameObject newObject = Instantiate(obj, createPos.position, createPos.rotation) as GameObject;
        newObject.transform.SetParent(parent.transform, true);
    }

    void ObjectRecycle()
    {
        GameObject generateObject = GameObject.FindGameObjectWithTag("GenerateObject");
        if (generateObject == null)
        {
            Debug.Log("Wait for object to Generate");
        }
        else
        {
            float distance = (generateObject.transform.position.x - recyclePos.position.x);
            if (distance <= 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("GenerateObject"));
            }
        }

    }
    #endregion
}
