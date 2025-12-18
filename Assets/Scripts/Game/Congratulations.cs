using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congratulations : MonoBehaviour
{
    public List<GameObject> writings;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.ShowCongratulations += ShowCongratulations;
    }

    private void OnDisable()
    {
        GameEvents.ShowCongratulations -= ShowCongratulations;
    }

    private void ShowCongratulations()
    {
        var index = UnityEngine.Random.Range(0, writings.Count);
        writings[index].SetActive(true);
    }
}
