using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        int direction = (team == 0) ? 1 : -1;

        // One in front
        if(board[cuurentX, cuurentY + direction] == null)
            r.Add(new Vector2Int(cuurentX, cuurentY + direction));

        // Two in front
        if(board[cuurentX, cuurentY + direction] == null)
        {
            // White Team
            if(team == 0 && cuurentY == 1 && board[cuurentX, cuurentY + (direction * 2)] == null)
                r.Add(new Vector2Int(cuurentX, cuurentY + (direction * 2)));

            // Black Team
            if(team == 1 && cuurentY == 6 && board[cuurentX, cuurentY + (direction * 2)] == null)
                r.Add(new Vector2Int(cuurentX, cuurentY + (direction * 2)));
        }

        // Kill Move (diagonal)
        if(cuurentX != tileCountX -1)
            if(board[cuurentX + 1, cuurentY + direction] != null && board[cuurentX + 1, cuurentY + direction].team != team)
                r.Add(new Vector2Int(cuurentX + 1, cuurentY + direction));

        if(cuurentX != 0)
            if(board[cuurentX - 1, cuurentY + direction] != null && board[cuurentX - 1, cuurentY + direction].team != team)
                r.Add(new Vector2Int(cuurentX - 1, cuurentY + direction));

        return r;
    }

    public override SpecialMove GetSpecialMoves(ref ChessPiece[,] board, ref List<Vector2Int[]> moveList, ref List<Vector2Int> availableMoves)
    {
        int direction = (team == 0) ? 1 : -1;

        if((team == 0 && cuurentY == 6) || (team == 1 && cuurentY == 1))
            return SpecialMove.Promotion;

        // EnPassant
        if(moveList.Count > 0)
        {
            Vector2Int[] lastMove = moveList[moveList.Count - 1];
            if(board[lastMove[1].x, lastMove[1].y].type == ChessPieceType.Pawn)     // If the last piece moved was a pawn
            {
                if(Mathf.Abs(lastMove[0].y - lastMove[1].y) == 2)   // If the last move was a +2 in either direction
                {
                    if(board[lastMove[1].x, lastMove[1].y].team != team)    // If move was from the other team
                    {
                        if(lastMove[1].y == cuurentY)   // If both pawns are at the same Y
                        {
                            if(lastMove[1].x == cuurentX -1)    // Landed Left
                            {
                                availableMoves.Add(new Vector2Int(cuurentX - 1, cuurentY + direction));
                                return SpecialMove.EnPassant;
                            }
                            if(lastMove[1].x == cuurentX +1)    // Landed Right
                            {
                                availableMoves.Add(new Vector2Int(cuurentX + 1, cuurentY + direction));
                                return SpecialMove.EnPassant;
                            }
                            
                        }
                    }
                }
            }
        }
        return SpecialMove.None;
    }
}
