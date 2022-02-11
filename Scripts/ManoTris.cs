using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ManoTris : MonoBehaviour
{
    public GameObject palmo;
    public GameObject dito;
    private float sx,sy,sz,dx,dy,dz;
    public CursoreTris cursore;
    private float x;
    private float y;
    void Update()
    {
        sx=palmo.transform.position.x;
        sy=palmo.transform.position.y;
        sz=palmo.transform.position.z;
        dx=dito.transform.position.x;
        dy=dito.transform.position.y;
        dz=dito.transform.position.z;

        x= ((sx+75.0f)*2400/450.0f)-130;
        y= (sy+40)*1500/220-140;
        cursore.setX(x);
        cursore.setY(y);

    }

    public bool isManoChiusa(){
        return Mathf.Sqrt((sx-dx)*(sx-dx)+(sy-dy)*(sy-dy)+(sz-dz)*(sz-dz))<10;
    }
}
