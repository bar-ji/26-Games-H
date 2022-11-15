using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    [SerializeField] private Piece[] pieces;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private float height;

    [SerializeField] private UIManager uiManager;

    bool canSpawn = true;

    void Start()
    {
        SpawnPiece();
    }

    public void SpawnPiece()
    {
        if(!canSpawn) return;

        int randIndex = Random.Range(0, pieces.Length);

        int rotation = Random.Range(0, 4);

        Piece p = Instantiate(pieces[randIndex], new Vector3(0, height, 0), Quaternion.Euler(0, rotation * 90, 0));
        p.Init(this);

        uiManager.UpdateScore(1);
    }

    public void EndGame()
    {
        uiManager.EndGame();
        canSpawn = false;
    }


}
