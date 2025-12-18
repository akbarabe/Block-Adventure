using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class RequestNewShape : MonoBehaviour
{
    public int numberOfRequest = 3;
    public TextMeshProUGUI numberText;

    private int _currentNumberOfRequest;
    private Button _button;
    private bool _isLocked;

    // Start is called before the first frame update
    void Start()
    {
        _currentNumberOfRequest = numberOfRequest;
        numberText.text = _currentNumberOfRequest.ToString();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonDown);
        UnLocked();
    }

    private void OnButtonDown()
    {
        if (_isLocked == false)
        {
            _currentNumberOfRequest--;
            GameEvents.RequestNewShapes();
            GameEvents.CheckIfPlayerLost();

            if (_currentNumberOfRequest <= 0)
            {
                Lock();
            }

            numberText.text = _currentNumberOfRequest.ToString();
        }
    }

    private void Lock()
    {
        _isLocked = true;
        _button.interactable = false;
        numberText.text = _currentNumberOfRequest.ToString();
    }

    private void UnLocked()
    {
        _isLocked = false;
        _button.interactable = true;
    }
}
