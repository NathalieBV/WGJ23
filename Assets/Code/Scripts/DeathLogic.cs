using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLogic : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjectsOnGameLost; 

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < gameObjectsOnGameLost.Length; i++)
        {
            gameObjectsOnGameLost[i].gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    public void OnGameLost()
    {
        
    }
}
