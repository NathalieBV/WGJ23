using UnityEngine;

public class ColliderAddCAP : MonoBehaviour
{
    [SerializeField] public float addingValue;
    [SerializeField] public Vector2 addingRange;
    private void Start()
    {
        addingValue = Random.Range(addingRange.x, addingRange.y);
    }

    private void OnCollisionEnter(Collision collision)
    {
       // GameStateManager.managerState.AddValue_CAP(addingValue);
    }

    void Update()
    {

    }
}
