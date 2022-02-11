using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ManoCampoDaTennis : MonoBehaviour
{
    public GameObject palmo;
    public GameObject dito;
    private float sx,sy,sz,dx,dy,dz;
    private float x=0,y=0;
    public CursoreCampoDaTennis cursore;

    void Update()
    {
        sx=palmo.transform.position.x;
        sy=palmo.transform.position.y;
        sz=palmo.transform.position.z;
        dx=dito.transform.position.x;
        dy=dito.transform.position.y;
        dz=dito.transform.position.z;

        x= (sx+90)*1920/60-1920;
        y= (sy+70)*1080/55f-1080;
        cursore.setX(x);
        cursore.setY(y);

    }

    public bool isManoChiusa(){
        return Mathf.Sqrt((sx-dx)*(sx-dx)+(sy-dy)*(sy-dy)+(sz-dz)*(sz-dz))<8;
    }
}
