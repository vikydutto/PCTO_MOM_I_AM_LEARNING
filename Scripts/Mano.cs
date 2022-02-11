using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Mano : MonoBehaviour
{
    public GameObject palmo;
    public GameObject dito;
    private float sx,sy,sz,dx,dy,dz;
    public Cursore cursore;

    // Update is called once per frame
    void Update()
    {
        sx=palmo.transform.position.x;
        sy=palmo.transform.position.y;
        sz=palmo.transform.position.z;
        dx=dito.transform.position.x;
        dy=dito.transform.position.y;
        dz=dito.transform.position.z;

        float x= (sx+624.2f)*1920/0.2f-1920;
        float y= (sy+472.14f)*1080/0.10f-1080;
        cursore.setX(x);
        cursore.setY(y);

       //Debug.Log(sy.ToString()+"---"+y.ToString()); 
       /*if(isManoChiusa()){
           Debug.Log("Mano chiusa!!");
           playButton.GetComponent<Button>().onClick.Invoke();
       }*/

    }

    public bool isManoChiusa(){
        return Mathf.Sqrt((sx-dx)*(sx-dx)+(sy-dy)*(sy-dy)+(sz-dz)*(sz-dz))<120f;
    }
}
