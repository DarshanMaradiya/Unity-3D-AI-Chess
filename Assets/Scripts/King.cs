using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Chessman
{
    public King()
    {
        value = 900;
    }
    
    public override bool[,] PossibleMoves()
    {
        bool[,] moves = new bool[8, 8];
        int x = currentX;
        int y = currentY;

        // Down
        KingMove(x , y - 1, ref moves);

        // Left
        KingMove(x - 1, y , ref moves);

        // Right
        KingMove(x + 1, y , ref moves);

        // Up
        KingMove(x , y + 1, ref moves);

        // DownLeft
        KingMove(x - 1, y - 1, ref moves);

        // DownRight
        KingMove(x + 1, y - 1, ref moves);

        // UpLeft
        KingMove(x - 1, y + 1, ref moves);

        // UpRight
        KingMove(x + 1, y + 1, ref moves);

        // If King is not yet moved then checking for Castling Move
        if(!isMoved)
        {
            if(isWhite)
            {
                CheckCastlingMoves(BoardManager.Instance.WhiteRook1, BoardManager.Instance.WhiteRook2, ref moves);
            }
            else
            {
                CheckCastlingMoves(BoardManager.Instance.BlackRook1, BoardManager.Instance.BlackRook2, ref moves);
            }
        }
        

        return moves;
    }
    
    private void KingMove(int x, int y, ref bool[,] moves)
    {
        if (x >= 0 && y >= 0 && x <= 7 && y <= 7)
        {
            Chessman piece = BoardManager.Instance.Chessmans[x, y];
            // If the cell is empty
            if (piece == null)
            {
                if(!KingInDanger(x, y))
                    moves[x, y] = true;
            }
            // If the piece is not from same team
            else if (piece.isWhite != isWhite)
            {
                if(!KingInDanger(x, y))
                    moves[x, y] = true;
            }
            // else if the piece is from same team, don't include it
        }
    }

    private void CheckCastlingMoves(Chessman Rook1, Chessman Rook2, ref bool[,] moves)
    {
        int x = currentX;
        int y = currentY;
        Chessman[,] Chessmans = BoardManager.Instance.Chessmans;
        bool conditions;
        bool isInCheck = InDanger();

        if(Rook1 != null)
        {
            // ----------------- King Side (towards (0, 0)) -----------------

            // 1) The Rook1 shoudn't have moved previously
            // 2) There should not be any Chessman in between
            conditions = (!Rook1.isMoved) && 
                              (moves[x - 1, y] && Chessmans[x - 2, y] == null);

            // 3) The King shouldn't be in Check currently
            // Which we already have checked, the result is stored in `bool isInCheck`, hence not checking again
            conditions = conditions && !isInCheck;

            // Allow Castling if conditions are met
            SetCastlingMove(x, y, x - 2, ref moves, conditions);

            // ----------------- King Side Over -----------------
        }
        
        if(Rook2 != null)
        {
            // ----------------- Queen Side (Away from (0, 0)) -----------------    

            // 1) The Rook2 shoudn't have moved previously
            // 2) There should not be any Chessman in between
            conditions = (!Rook2.isMoved) && 
                         (moves[x + 1, y] && Chessmans[x + 2, y] == null && Chessmans[x + 3, y] == null);

            // 3) The King shouldn't be in Check currently
            // Which we already have checked, the result is stored in `bool isInCheck`, hence not checking again
            conditions = conditions && !isInCheck;

            // Allow Castling if conditions are met
            SetCastlingMove(x, y, x + 2, ref moves, conditions);

            // ----------------- Queen Side Over -----------------      
        }
        
    }

    private void SetCastlingMove(int x, int y, int newX, ref bool[,] moves, bool conditions)
    {
        // If Conditions are met then check that
        // After castling, will King be in Danger or not
        if(conditions)
        {
            // Critical Part : 
            // We are about to move King on the chessboard(not in the scene) without yet recieving command
            // To check whether this move will put King in danger/Check State or not
            // So that we can disallowed the move
            // After checking we will undo the move we have made
            // And every change will be undone only in this if condition, in this function
            // Again : this won't have any effect on the scene

            // Leaving the position, making the move, updating co-ordinates
            BoardManager.Instance.Chessmans[x, y] = null;
            BoardManager.Instance.Chessmans[newX, y] = this;
            this.SetPosition(newX, y);

            // We will store the decision in result
            bool inDanger = false;
            // Now checking whether the King is now in danger or not
            inDanger = InDanger();

            // Now Undoing
            BoardManager.Instance.Chessmans[x, y] = this;
            BoardManager.Instance.Chessmans[newX, y] = null;
            this.SetPosition(x, y);

            // If will not in danger then castling move is now allowed
            if(inDanger == false)
                moves[newX, y] = true;
        }
    }

}
