using UnityEngine;
using System.Collections;

public class GridItemTarget : GridItemP {

    public override void randValue ()
    {
        color = ( IColor ) ( Random. Range ( 0, ( int ) IColor. Length ) );
        switch ( color )
        {
            case IColor. Green:
                sprite. color = new Color ( 0, 1, 0 );
                break;
            case IColor. Blue:
                sprite. color = new Color ( 0, 0, 1 );
                break;
            case IColor. Red:
                sprite. color = new Color ( 1, 0, 0 );
                break;
        }
    }

}
