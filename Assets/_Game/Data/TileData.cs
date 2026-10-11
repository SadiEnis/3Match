using UnityEngine;

namespace _Game.Data
{
    [CreateAssetMenu(fileName = "Tile Data", menuName = "Game/Tile Data")]
    public class TileData : ScriptableObject
    {
        public GameObject prefab;
        public bool isMatchable = true;
        public bool isSwappable = true;
        public bool isSpawnable = true;
        //public int ColorId { get; private set; }
        //colorid tiledata veya runtime'da 
    }
}