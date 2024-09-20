using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
   public override List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        // Top Right
        int x = cuurentX + 1;
        int y = cuurentY + 2;
        if(x < tileCountX && y < tileCountY)
            if(board[x, y] == null || board[x, y].team != team)
                r.Add(new Vector2Int(x, y));

        // Right Top
        x = cuurentX + 2;
        y = cuurentY + 1;
        if(x < tileCountX && y < tileCountY)
            if(board[x, y] == null || board[x, y].team != team)
                r.Add(new Vector2Int(x, y));

        // Top Left
        x = cuurentX - 1;
        y = cuurentY + 2;
        if(x >= 0 && y < tileCountY)
            if(board[x, y] == null || board[x, y].team != team)
                r.Add(new Vector2Int(x, y));

        // Left Top
        x = cuurentX - 2;
        y = cuurentY + 1;
        if(x >= 0 && y < tileCountY)
            if(board[x, y] == null || board[x, y].team != team)
                r.Add(new Vector2Int(x, y));

        // Bottom Right
        x = cuurentX + 1;
        y = cuurentY - 2;
        if(x < tileCountX && y >= 0)
            if(board[x, y] == null || board[x, y].team != team)
                r.Add(new Vector2Int(x, y));

        // Right Bottom
        x = cuurentX + 2;
        y = cuurentY - 1;
        if(x < tileCountX && y >= 0)
            if(board[x, y] == null || board[x, y].team != team)
                r.Add(new Vector2Int(x, y));

        // Bottom Left
        x = cuurentX - 1;
        y = cuurentY - 2;
        if(x >= 0 && y >= 0)
            if(board[x, y] == null || board[x, y].team != team)
                r.Add(new Vector2Int(x, y));

        // Left Bottom
        x = cuurentX - 2;
        y = cuurentY - 1;
        if(x >= 0 && y >= 0)
            if(board[x, y] == null || board[x, y].team != team)
                r.Add(new Vector2Int(x, y));

        return r;
    } 
}
