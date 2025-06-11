using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public static class GameFormula 
{
    public static Vector2 CalculateDirection(Vector2 dir)
    {
        if (dir.sqrMagnitude > 1) dir /= Mathf.Sqrt(dir.sqrMagnitude);return dir;      
    }

}
