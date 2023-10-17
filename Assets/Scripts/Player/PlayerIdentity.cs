using UnityEngine;

public class PlayerIdentity : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private ColorRandomizer _randomSentry;

    private void Start()
    {
        _sprite.color = PickColor();
    }

    private Color PickColor()
    {
        var hexColor = "#" + _randomSentry.GenerateRandomColor(6);
        if (ColorUtility.TryParseHtmlString(hexColor, out var resultColor))
        {
            return resultColor;
        }
        return Color.white;
    }

}
