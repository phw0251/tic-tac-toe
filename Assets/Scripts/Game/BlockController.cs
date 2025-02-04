﻿using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] private Block[] blocks;
    
    public delegate void OnBlockClicked(int row, int col);
    public OnBlockClicked OnBlockClickedDelegate;

    public void InitBlocks()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].InitMarker(i, blockIndex =>
            {
                var clickedRow = blockIndex / 3;
                var clickedCol = blockIndex % 3;
                
                OnBlockClickedDelegate?.Invoke(clickedRow, clickedCol);
            });
        }
    }
    
    /// <summary>
    /// 특정 Block에 마커 표시하는 함수
    /// </summary>
    /// <param name="markerType">마커 타입</param>
    /// <param name="row">Row</param>
    /// <param name="col">Col</param>
    public void PlaceMarker(Block.MarkerType markerType, int row, int col)
    {
        // row, col을 index로 변환
        var markerIndex = row * 3 + col;
        
        // Block에게 마커 표시
        blocks[markerIndex].SetMarker(markerType);
    }
}