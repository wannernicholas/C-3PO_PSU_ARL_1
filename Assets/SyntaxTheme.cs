using UnityEngine;
[CreateAssetMenu()]

public class SyntaxTheme : ScriptableObject
{
    public Color comment = Color.green;
    public Color loopKeyword = Color.blue;
    public Color conditionKeyword = Color.blue;
    public Color mathOperator = Color.red;
    public Color value = Color.white;
    public Color parentheses = Color.white;
    public Color curlyBrackets = Color.white;
    public Color comparisonOperator = Color.red;
    public Color assignment = Color.white;
    public Color variable = Color.cyan;

}
