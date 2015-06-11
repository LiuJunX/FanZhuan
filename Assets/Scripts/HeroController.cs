using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

    public float speedX = 5;
    public float speedYDefault = 15;
    public float speedY = 0;
    public bool isMoveDown = true;
    public float heigth = 5;
    public Vector3 changeDirPos;
    public float changeDirPassTime;

    void Awake()
    {
        ChangeDir ();
    }

    void ChangeDir()
    {
        changeDirPos = this. transform. position;
        changeDirPassTime = 0;
        isMoveDown = !isMoveDown;
        speedY = speedYDefault * ( isMoveDown ? -1 : 1 );
    }

	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(0))
        {
            ChangeDir ();
            return;
        }
        changeDirPassTime += Time.deltaTime;
        this. transform. position =  changeDirPos + new Vector3 ( speedX * changeDirPassTime, speedY * changeDirPassTime );
        if(this.transform.position.y >= heigth)
        {
            this. transform. position = new Vector3(this.transform.position.x , heigth, this.transform.position.z);
        } else if ( this. transform. position. y <= - heigth )
        {
            this. transform. position = new Vector3 ( this. transform. position. x, - heigth, this. transform. position. z );
        } else
        {
            Debug. Log ( this. transform. position. y );
        }
	}

}
