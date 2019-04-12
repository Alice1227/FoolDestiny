using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawn : MonoBehaviour
{

    public GameObject Obj_Creat;//要生成的物件
    public float f_Time = 3f; //生成間隔
    public Transform Tran_CreatPoint;//物件要生成的位置
    public Vector3 V3_Random;//隨機生成位置
    private float time = 0f;//計時器
    private int count = 0;//計數器

    public Vector3 random()
    {
        float index = Random.Range(0f, 132f);
        float x = -20f;
        float y = 30f;
        float z = -14f;
        
        if (0f < index && index <= 26f)
        {
            z += index;
        }
        else if(26f < index && index <= 66f)
        {
            z = 12f;
            index -= 26f;
            x += index;
        }
        else if(66f< index && index <= 92f)
        {
            x = 20f;
            index -= 66f;
            z += index;
        }
        else
        {
            index -= 92f;
            x += index;
        }
        Vector3 random = new Vector3(x, y, z);
        return random;
    }

    // Use this for initialization
    void Start()
    {
        time = f_Time;
    }

    // Update is called once per frame
    void Update()
    {
        V3_Random = random();

        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
			Instantiate (Obj_Creat, V3_Random, Quaternion.identity);
            time = f_Time;
            count++;
        }

        if(count == 3 && f_Time > 1f)
        {
            f_Time -= 1f;
            count = 0;
        }
    }
}
