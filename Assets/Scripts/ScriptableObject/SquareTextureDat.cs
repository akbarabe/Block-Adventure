using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class SquareTextureDat : ScriptableObject
{
    [System.Serializable]
    public class TextureData
    {
        public Sprite texture;
        public Config.SquareColor squarecolor;
    }

    public int tresholdVal = 10;
    private const int startTreshholdVal = 10;
    public List<TextureData> activeSquareTextures;

    public Config.SquareColor currentColor;
    private Config.SquareColor _nextColor;

    public int GetCurrentColorIndex()
    {
        var currentIndex = 0;

        for (int index = 0; index < activeSquareTextures.Count; index++)
        {
            if (activeSquareTextures[index].squarecolor == currentColor)
            {
                currentIndex = index;
            }
        }

        return currentIndex;
    }

    public void UpdateColors(int current_score)
    {
        currentColor = _nextColor;
        var currentColorIndex = GetCurrentColorIndex();
        if (currentColorIndex == activeSquareTextures.Count - 1)
            _nextColor = activeSquareTextures[0].squarecolor;
        else
            _nextColor = activeSquareTextures[currentColorIndex + 1].squarecolor;

        tresholdVal = startTreshholdVal + current_score;
    }

    public void SetStartColor()
    {
        tresholdVal = startTreshholdVal;
        currentColor = activeSquareTextures[0].squarecolor;
        _nextColor = activeSquareTextures[1].squarecolor;
    }

    private void Awake()
    {
        SetStartColor();
    }

    private void OnEnable()
    {
        SetStartColor();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
