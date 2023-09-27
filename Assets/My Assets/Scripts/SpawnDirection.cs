using UnityEngine;

public class SpawnDirection : MonoBehaviour
{
    [SerializeField] private Directions _directions;

    public Directions ChosenDirection =>
        _directions;
}
public enum Directions
{
    Left = -1,
    Right = 1
}