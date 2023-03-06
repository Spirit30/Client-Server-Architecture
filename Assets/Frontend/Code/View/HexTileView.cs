using Shared;
using UnityEngine;

namespace Frontend
{
    public class HexTileView : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer view;
        public float Extent => view.bounds.extents.x;

        public HexTile Tile { get; set; }
    }
}