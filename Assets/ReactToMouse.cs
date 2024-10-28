using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ReactToMouse : MonoBehaviour
{
    [System.Serializable]
    public struct HexState
    {
        public string name;
        public Tile tile;
    }
    [SerializeField]
    private HexState[] hexStates;
    private Dictionary<string, Tile> hexStateFromName;
    [SerializeField]
    private Tilemap hexes;

    // Start is called before the first frame update
    void Start()
    {
        hexStateFromName = new Dictionary<string, Tile>();
        hexes = gameObject.GetComponent<Tilemap>();
        foreach (var state in hexStates)
        {
            hexStateFromName.Add(state.name, state.tile);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeState(string stateName, Vector3Int cellPos)
    {
        if (stateName == "inactive")
        {
            hexes.SetTile(cellPos, null);
        }
        else
            hexes.SetTile(cellPos, hexStateFromName[stateName]);
    }
}
