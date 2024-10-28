using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private Vector3 mousePos;
    [SerializeField]
    private Vector3 mouseWorldPos;
    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private Grid baseGrid;
    [SerializeField]
    private Vector3Int cellLookedAt;
    [SerializeField]
    private GameObject hexes;
    [SerializeField]
    private GameObject paths;
    private Tilemap pathsMap;
    private ReactToMouse hexesReact;
    private Vector3Int previousCell = new Vector3Int(0, 0, -11);
    [SerializeField]
    private GameObject currentPlayableChar;
    [SerializeField]
    private GameObject UI;
    [SerializeField]
    private GameObject chosenObject;
    [SerializeField]
    private GameObject characterLookedAt;
    private int characterLayer;

    // Start is called before the first frame update
    void Start()
    {
        hexesReact = hexes.GetComponent<ReactToMouse>();
        characterLayer = LayerMask.NameToLayer("Characters");
        pathsMap = paths.GetComponent<Tilemap>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
        if (hit.collider != null)
        {
            //Debug.Log("Mouse over new character");
            characterLookedAt = hit.transform.gameObject;
        }
        else
            characterLookedAt = null;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mouseWorldPos = playerCamera.ScreenToWorldPoint(mousePos) + new Vector3Int(0, 0, 10);
        cellLookedAt = baseGrid.WorldToCell(mouseWorldPos);
        if (pathsMap.GetTile(cellLookedAt) != null)
        {
            if (!cellLookedAt.Equals(previousCell))
            {
                hexesReact.ChangeState("inactive", previousCell);
                hexesReact.ChangeState("active", cellLookedAt);
            }
            previousCell = cellLookedAt;

            if (Input.GetMouseButtonDown(1))
            {
                if (currentPlayableChar != null)
                    currentPlayableChar.transform.position = baseGrid.CellToWorld(cellLookedAt) + new Vector3(0, 0.25f, 0);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            currentPlayableChar = characterLookedAt;
        }
    }
}
