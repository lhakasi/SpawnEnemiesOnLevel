using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField] private float _delay;

    void Start() =>    
        Destroy(gameObject, _delay);    
}