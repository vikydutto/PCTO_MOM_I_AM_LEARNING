using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuoviPallina : MonoBehaviour
{
    public static bool isWaiting;
    public static Vector3 answer, answer1,answer2,answer3,answer4;
    public float speed;
    private int fase;

    void Start(){
        fase=0;
        isWaiting=false;
        answer1=new Vector3(-68,15,105);
        answer2=new Vector3(71,15,105);
        answer3=new Vector3(-68,40,105);
        answer4=new Vector3(71,40,105);
    }
    void Update()
    {
        if(!isWaiting){
            Vector3 a,b;
            if(fase==0){
                a=transform.position;
                b=new Vector3(0,-10,65);
                transform.position=Vector3.Lerp(a,b,speed);
                if(Mathf.Abs(b.y-transform.position.y)<=speed*2){
                    isWaiting=true;
                    fase=1;
                }
            }else{
                a=transform.position;
                b=answer;
                transform.position=Vector3.Lerp(a,b,speed);
            }
        
        }
    }
}
