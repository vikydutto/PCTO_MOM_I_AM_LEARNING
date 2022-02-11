using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursoreCampoDaTennis : MonoBehaviour
{
    public ManoCampoDaTennis hand;
    public GameObject r1, r2,r3,r4;
    private float x;
    private float y;
    void Start()
    {
        y = gameObject.transform.position.y;
        x = gameObject.transform.position.x;
    }
    void Update()
    {
        gameObject.transform.position = new Vector3(x, y, transform.position.z);
        if(isOnRisposta1()){
            
        }
    }

    public void setX(float x)
    {
        this.x = x;
    }

    public void setY(float y)
    {
        this.y = y;
    }

    public float getX()
    {
        return x;
    }

    public float getY()
    {
        return y;

    }

    public bool isOnQ(GameObject q)
    {
        float width = q.GetComponent<RectTransform>().rect.width;
        float height = q.GetComponent<RectTransform>().rect.height;
        float cordx = q.transform.position.x*10;
        float cordy = q.transform.position.y*10;
        return gameObject.transform.position.x*10 > cordx - width / 2 && gameObject.transform.position.x*10 < cordx + width / 2 && gameObject.transform.position.y*10 > cordy - height / 2 && gameObject.transform.position.y *10< cordy + height / 2;
    }
    public bool isOnRisposta1()
    {
        return isOnQ(r1);
    }

   public bool isOnRisposta2()
    {
        return isOnQ(r2);
    }

    public bool isOnRisposta3()
    {
        return isOnQ(r3);
    }

    public bool isOnRisposta4()
    {
        return isOnQ(r4);
    }
}