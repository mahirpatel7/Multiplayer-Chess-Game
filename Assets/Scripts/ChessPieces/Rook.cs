using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        // Down
        for (int i = cuurentY - 1; i >= 0; i--)
        {
            if(board[cuurentX, i] == null)
                r.Add(new Vector2Int(cuurentX, i));

            if(board[cuurentX, i] != null)
            {
                if(board[cuurentX, i].team != team)
                    r.Add(new Vector2Int(cuurentX, i));

                break;
            }
        }

        // Up
        for (int i = cuurentY + 1; i < tileCountY; i++)
        {
            if(board[cuurentX, i] == null)
                r.Add(new Vector2Int(cuurentX, i));

            if(board[cuurentX, i] != null)
            {
                if(board[cuurentX, i].team != team)
                    r.Add(new Vector2Int(cuurentX, i));

                break;
            }
        }

        // Left
        for (int i = cuurentX - 1; i>=0; i--)
        {
            if(board[i, cuurentY] == null)
                r.Add(new Vector2Int(i, cuurentY));

            if(board[i, cuurentY] != null)
            {
                if(board[i, cuurentY].team != team)
                    r.Add(new Vector2Int(i, cuurentY));

                break;
            }
        }

        // Left
        for (int i = cuurentX + 1; i < tileCountY; i++)
        {
            if(board[i, cuurentY] == null)
                r.Add(new Vector2Int(i, cuurentY));

            if(board[i, cuurentY] != null)
            {
                if(board[i, cuurentY].team != team)
                    r.Add(new Vector2Int(i, cuurentY));

                break;
            }
        }

        return r;
    }
}
