using UnityEngine;
using System.Collections;

public class ItemsManager : MonoBehaviour {

    public GridItemP itemPrefab;
    public GridItemP itemPrefabP;

    public ConfigXorY configX;
    public ConfigXorY configY;
    public GameObject testCube;

    public GridItemP[,] items;

    void Awake()
    {
        configX. Init ();
        configY. Init ();
    }

	// Use this for initialization
	void Start () {
        items = new GridItemP[ configX. num, configX. num ];
        for(int i = 0; i < configX.num; i ++)
        {
            for(int j = 0; j < configY.num; j ++)
            {
                GridItemP item = GameObject. Instantiate<GridItemP> ( itemPrefab );
                item. transform. parent = this. transform;
                item. transform. localPosition = new Vector2 ( configY. IndexPosition ( j ), -configX. IndexPosition ( i ) );
                item. name = "item["+ i + "," + j + "]";

                item = GameObject. Instantiate<GridItemP> ( itemPrefabP );
                item. transform. parent = this. transform;
                item. transform. localPosition = new Vector2 ( configY. IndexPosition ( j ), -configX. IndexPosition ( i ) );
                item. name = "tar_item["+ i + "," + j + "]";
            }
        }
        cubeInitPos = testCube. transform. position;
	}

    Vector2 cubeInitPos;
    Vector2 downPoint;
    int downIndexX;
    int downIndexY;
    SlideDirection slideDir = SlideDirection. None;

	// Update is called once per frame
	void Update () {
        Vector2 mousePosWorld = Camera. main. ScreenToWorldPoint (Input.mousePosition);
        int mouseRow = configX. pointIndex ( mousePosWorld. y );
        int mouseCol = configY. pointIndex ( mousePosWorld. x );
        if ( mouseRow == -1 || mouseCol == -1 )
        {
            return;        
        }
        if ( Input. GetMouseButtonDown ( 0 ) )
        {
            downPoint = mousePosWorld;
            downIndexX = mouseRow;
            downIndexY = mouseCol;
            slideDir = SlideDirection. None;
        } else if ( Input. GetMouseButton (0) )
        {
            Vector2 deltaPos = ( mousePosWorld - downPoint );
            switch(slideDir)
            {
                case SlideDirection.None:
                    if ( deltaPos. sqrMagnitude > 0.2f )
                    {
                        if ( deltaPos. x * deltaPos. x > deltaPos. y * deltaPos. y )
                        {
                            slideDir = SlideDirection. X;
                        } else
                        {
                            slideDir = SlideDirection. Y;
                        }
                    }
                    break;
                case SlideDirection.X:
                    testCube. transform. position = cubeInitPos + new Vector2(deltaPos.x, 0);
                    break;
                case SlideDirection.Y:
                    testCube. transform. position = cubeInitPos + new Vector2(0, deltaPos.y);
                    break;
            }
            
        } else if ( Input. GetMouseButtonUp (0) )
        {
            slideDir = SlideDirection. None;
            testCube.transform.position = cubeInitPos;
        }
	}
}

[System.Serializable]
public class ConfigXorY
{
    public int num = 10;
    public float itemLength = 1;
    public float anchor = 0;
    float fullLength;
    float firstItemCenter;
    float begin;
    float end;
    public void Init()
    {
        fullLength = num * itemLength;
        end = fullLength * 0.5f;
        begin = - end;
        firstItemCenter = -(fullLength - itemLength) * 0.5f;
    }
    public float IndexPosition(int index)
    {
        return firstItemCenter + itemLength * index;
    }
    public int pointIndex(float point)
    {
        if ( point < begin || point > end )
            return -1;
        int index = (int)((point - begin) / itemLength);
        return index;
    }
}

public enum SlideDirection
{
    None,
    X,
    Y
}
