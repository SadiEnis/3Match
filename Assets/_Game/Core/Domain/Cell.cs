using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Core.Domain
{
    public class Cell
    {
        public Vector2Int Index { get; private set; }
        public Vector3 WorldPosition { get; private set; }

        public Tile CurrentTile { get; private set; }
        // public CellModifier Modifier { get; private set; }
        public bool IsEmpty => CurrentTile == null;

        public Cell(Vector2Int index, Vector3 worldPosition)
        {
            Index = index;
            WorldPosition = worldPosition;
        }

        public void SetTile(Tile tile)
        {
            CurrentTile = tile;
        }

        public void ClearTile()
        {
            CurrentTile = null;
        }

        // public void SetModifier(CellModifier modifier)
        // {
        //     Modifier = modifier;
        // }
    }
}