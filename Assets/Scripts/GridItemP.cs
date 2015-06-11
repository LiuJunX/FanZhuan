using UnityEngine;
using System.Collections;

public class GridItemP : MonoBehaviour {

    public enum IColor
    {
        Green,
        Blue,
        Red,
        Length
    }

    protected SpriteRenderer sprite;
    protected IColor color;

	void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer> ();
        randValue ();
    }

    public virtual void randValue()
    {
        color = (IColor) (Random.Range(0, (int)IColor.Length));
        switch(color)
        {
            case IColor.Green:
                sprite. color = new Color ( 0, 1, 0, 0.4f );
                break;
            case IColor. Blue:
                sprite. color = new Color ( 0, 0, 1, 0.4f );
                break;
            case IColor. Red:
                sprite. color = new Color ( 1, 0, 0, 0.4f );
                break;
        }
    }


}
