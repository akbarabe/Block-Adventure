using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSquareImageSelector : MonoBehaviour
{
    public SquareTextureDat squareTextureDat;
    public bool updateImageOnReachedTreshold = false;

    private void OnEnable()
    {
        UpdateSquareColorBaseOnCurrentPoints();

        if (updateImageOnReachedTreshold)
            GameEvents.UpdateSquareColor += UpdateSquaresColor;
    }

    private void OnDisable()
    {
        if (updateImageOnReachedTreshold)
            GameEvents.UpdateSquareColor -= UpdateSquaresColor;
    }

    private void UpdateSquareColorBaseOnCurrentPoints()
    {
        foreach (var squareTexture in squareTextureDat.activeSquareTextures)
        {
            if (squareTextureDat.currentColor == squareTexture.squarecolor)
            {
                GetComponent<Image>().sprite = squareTexture.texture;
            }
        }
    }

    private void UpdateSquaresColor(Config.SquareColor color)
    {
        foreach (var squareTexture in squareTextureDat.activeSquareTextures)
        {
            if (color == squareTexture.squarecolor)
            {
                GetComponent<Image>().sprite = squareTexture.texture;
            }
        }
    }
}
