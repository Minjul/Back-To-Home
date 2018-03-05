/*
* Copyright Minjul (Minjui)
* Mail: cscz1234@gmail.com 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsCreater : MonoBehaviour {

    #region Variables
    public Transform parent;
    public Transform recyclePoint;
    public float createRate;

    float nextCloud;
    int cloudType;
    int nextType;

    int pointOffset;
    int realOffset;
    Object obj;

    #endregion
	
	#region Unity Methods

	void Update () 
	{
        CreateClouds();
    }
	
    void CreateClouds()
    {
        if (Time.time > nextCloud)
        {
            nextCloud = Time.time + createRate;

            //每一次讀取的雲朵都要不一樣
            cloudType = Random.Range(0, 5);
            if (cloudType == nextType)
            {
                cloudType = Random.Range(0, 5);
            }
            nextType = cloudType;
  
            switch (nextType)
            {
                case 0:
                    obj = Resources.Load(Define.MemClouds1Path);
                    //Debug.Log("Now obj is " + obj);
                    //Load Resources
                    break;

                case 1:
                    obj = Resources.Load(Define.MemClouds2Path);
                    //Debug.Log("Now obj is " + obj);
                    //Load Resources
                    break;

                case 2:
                    obj = Resources.Load(Define.MemClouds3Path);
                    //Debug.Log("Now obj is " + obj);
                    //Load Resources
                    break;

                case 3:
                    obj = Resources.Load(Define.MemClouds4Path);
                    //Debug.Log("Now obj is " + obj);
                    //Load Resources
                    break;

                case 4:
                    obj = Resources.Load(Define.MemClouds5Path);
                    //Debug.Log("Now obj is " + obj);
                    //Load Resources
                    break;

                default:
                    break;
            }

            pointOffset = Random.Range(-1, 2);
            if(pointOffset == realOffset)
            {
                pointOffset = Random.Range(-1, 2);
            }
            realOffset = pointOffset;

            //Debug.Log("Now obj is " + obj);
            Vector2 createPoint = new Vector2(parent.position.x, parent.position.y + realOffset);
            GameObject newCloud = Instantiate(obj, createPoint, parent.rotation) as GameObject;
            newCloud.transform.SetParent(parent.transform, true);
            
            if(GameObject.FindGameObjectWithTag("Clouds").transform.position.x <= recyclePoint.position.x)
            {
                Destroy(GameObject.FindGameObjectWithTag("Clouds"));
            }
        }
    }
    #endregion
}
