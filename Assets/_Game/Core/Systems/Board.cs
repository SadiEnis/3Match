using System;
using _Game.Core.Domain;
using Unity.VisualScripting;
using UnityEngine;
using _Game.Data;

namespace _Game.Core.Systems
{
    public class Board : MonoBehaviour
    {
        [Header("Board Settings")] [SerializeField]
        private int width = 8;

        [SerializeField] private int height = 8;
        [SerializeField] private float cellSize = 1f;

        [Header("Board Origin")] [SerializeField]
        private Transform boardRoot;

        private Cell[,] _grid;

        public int Width => width;
        public int Height => height;
        public Cell[,] Grid => _grid;

        [Header("TileSettings")]
        [SerializeField] private TileData[] tileDatas; //spawn edilecek tile tipleri

        [SerializeField] private Transform tileParent;

        private void Start()
        {
            Initialize(width, height);
            SpawnInitialTiles();
        }

        public void Initialize(int w, int h)
        {
            width = w;
            height = h;

            CreateGrid();
        }

        private void CreateGrid()
        {
            _grid = new Cell[width, height];
            Vector3 origin = GerBoardOrigin();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector2Int index = new Vector2Int(x, y);
                    Vector3 worldPosition = origin + new Vector3(x * cellSize, y * cellSize, 0);

                    Cell cell = new Cell(index, worldPosition);
                    _grid[x, y] = cell;
                    Debug.Log(_grid[x, y] + " " + _grid[x, y].WorldPosition);
                }
            }
        }

        private Vector3 GerBoardOrigin()
        {
            float offsetX = (width - 1) * cellSize * .5f;
            float offsetY = (height - 1) * cellSize * .5f;

            Vector3 rootPos = boardRoot != null ? boardRoot.position : transform.position;
            return rootPos - new Vector3(offsetX, offsetY, 0f);
        }

        public Cell GetCell(int x, int y)
        {
            if (!IsInsideBoard(x, y)) return null;
            return _grid[x, y];
            //board içinde null dönmemesi için
        }

        public bool IsInsideBoard(int x, int y)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }

        private void SpawnInitialTiles()
        {
            for (int x = 0; x < width; x++)
                for (int y=0; y < height; y++)
                {
                    SpawnTileAt(x, y);
                }
        }

        private void SpawnTileAt(int x, int y)
        {
            //add tile assests in elements
            Cell cell = GetCell(x, y);
            if (cell == null || !cell.IsEmpty)
                return;
            int randomIndex = UnityEngine.Random.Range(0, tileDatas.Length);
            TileData selectedData = tileDatas[randomIndex];
            
            //prefab instantiate
            GameObject tileObj = Instantiate(selectedData.prefab, cell.WorldPosition, Quaternion.identity, tileParent);
            Tile tile = tileObj.GetComponent<Tile>();
            tile.Initialize(selectedData, randomIndex);
            
            cell.SetTile(tile);
            tile.SetCell(cell);
            
            tile.MoveTo((cell.WorldPosition));
        }
    }
}