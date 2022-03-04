using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeClass 
{
    public Vector2Int coordinates;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public NodeClass connectedTo;

    public NodeClass(Vector2Int _coordinates, bool _isWalkable)
    {
        _coordinates = coordinates;
        _isWalkable = isWalkable;
    }
}
