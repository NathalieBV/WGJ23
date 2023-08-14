using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderValue : MonoBehaviour
{
    [SerializeField] public float addingValue;
    [SerializeField] public Vector2 addingRange;
    private void Start()
    {
        addingValue = Random.Range(addingRange.x, addingRange.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        GameStateManager.managerState.ModifyValue_(addingValue);
    }
 

    void Update()
    {
        
    }
}
