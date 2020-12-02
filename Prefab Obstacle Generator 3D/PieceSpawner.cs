using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    public PieceType type;
    private Piece currentPiece;

    public void Spawn()
    {
        int amtObj = 0;
        switch (type)
        {
            case PieceType.rock:
                amtObj = LevelManager.Instance.rocks.Count;
                break;
            case PieceType.trap:
                amtObj = LevelManager.Instance.traps.Count;
                break;
            case PieceType.enemy:
                amtObj = LevelManager.Instance.enemys.Count;
                break;
            case PieceType.woodlog:
                amtObj = LevelManager.Instance.woodlogs.Count;
                break;
            case PieceType.wall:
                amtObj = LevelManager.Instance.walls.Count;
                break;
            case PieceType.barrier:
                amtObj = LevelManager.Instance.barriers.Count;
                break;
            case PieceType.ramp:
                amtObj = LevelManager.Instance.ramps.Count;
                break;
        }

        currentPiece = LevelManager.Instance.GetPiece(type, Random.Range(0, amtObj));
        currentPiece.gameObject.SetActive(true);
        currentPiece.transform.SetParent(transform, false);
    }

    public void DeSpawn()
    {
        currentPiece.gameObject.SetActive(false);
    }
}
