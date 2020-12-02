using UnityEngine;

public enum PieceType
{
    none = -1,
    rock = 0,
    trap = 1,
    enemy = 2,
    woodlog = 3,
    wall = 4,
    barrier = 5,
    ramp = 6,
}

public class Piece : MonoBehaviour
{
    public PieceType type;
    public int visualIndex;
}
