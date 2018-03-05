/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourLevelCreater : MonoBehaviour {

    #region Variables
    MiniGameMaster miniGameMaster;
    public Transform parent;
    public Transform recyclePoint;
    public Transform target;
    public float createRate;

    float nextObject;
    int objectType;
    int nextType;

    int pointOffset;
    int realOffset;
    Object obj;

    #endregion

    #region Unity Methods

    void Start()
    {
        miniGameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<MiniGameMaster>();
    }

    void Update () 
	{
        if (!miniGameMaster.IsGameOver)
        {
            if (miniGameMaster.GameStart)
            {
                CreateLevel();
                FollowTarget();
            }

        }

    }
	
    void FollowTarget()
    {
        transform.position = new Vector2(target.position.x, transform.position.y);
    }

    void CreateLevel()
    {
        if (Time.time > nextObject)
        {
            nextObject = Time.time + createRate;

            objectType = Random.Range(0, 3);
            if (objectType == nextType)
            {
                objectType = Random.Range(0, 3);
            }
            nextType = objectType;
  
            switch (nextType)
            {
                case 0:
                    obj = Resources.Load(Define.EasyType1);
                    Debug.Log("Now LevelType is " + obj);
                    //Load Resources
                    break;

                case 1:
                    obj = Resources.Load(Define.EasyType2);
                    Debug.Log("Now LevelType is " + obj);
                    //Load Resources
                    break;

                case 2:
                    obj = Resources.Load(Define.EasyType3);
                    Debug.Log("Now LevelType is " + obj);
                    //Load Resources
                    break;

                default:
                    break;
            }

            //pointOffset = Random.Range(-1, 2);
            //if(pointOffset == realOffset)
            //{
            //    pointOffset = Random.Range(-1, 2);
            //}
            //realOffset = pointOffset;

            //Debug.Log("Now obj is " + obj);
            Vector2 createPoint = new Vector2(parent.position.x, parent.position.y);
            GameObject newObject = Instantiate(obj, createPoint, parent.rotation) as GameObject;
            //newObject.transform.SetParent(parent.transform, true);
            
            if(GameObject.FindGameObjectWithTag("MiniGameObj").transform.position.x <= recyclePoint.position.x)
            {
                Destroy(GameObject.FindGameObjectWithTag("MiniGameObj"));
            }
        }
    }
    #endregion
}
