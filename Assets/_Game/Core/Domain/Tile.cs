using UnityEngine;
using _Game.Data;

namespace _Game.Core.Domain
{
    public class Tile : MonoBehaviour
    {
        public TileData Data { get; private set; }
        public Cell CurrentCell { get; private set; }
        public int ColorId { get; private set; }
        
        // private List<TileBehavior> behaviors = new();
        public void Initialize(TileData data, int colorId)
        {
            if (data == null)
                throw new System.ArgumentNullException("data");
            {
                Data = data;
                ColorId = colorId;
            }
            //crash engellenmesi için
        }

        public void SetCell(Cell cell)
        {
            CurrentCell = cell;
        }

        public void MoveTo(Vector3 worldPos)
        {
            transform.position = worldPos;
        }

        public void DestroyTile()
        {
            Destroy(gameObject);
            // yerine TilePool.Release(this); şekli kullanılabilir
        }

        // public void AddBehavior(TileBehavior behavior)
        // {
        //     behaviors.Add(behavior);
        // }
    }
}