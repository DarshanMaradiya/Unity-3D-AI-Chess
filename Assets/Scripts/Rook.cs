using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Chessman
{
    public Rook()
    {
        value = 50;
    }
    
    public override bool[,] PossibleMoves()
    {
        bool[,] moves = new bool[8, 8];
        int x = currentX;
        int y = currentY;

        // Down
        while(y-- > 0)
        {
            if (!RookMove(x, y, ref moves))
                break;
        }

        x = currentX;
        y = currentY;
        // Right
        while (x++ < 7)
        {
            if (!RookMove(x, y, ref moves))
                break;
        }

        x = currentX;
        y = currentY;
        // Left
        while (x-- > 0)
        {
            if (!RookMove(x, y, ref moves))
                break;
        }

        x = currentX;
        y = currentY;
        // Up
        while (y++ < 7)
        {
            if(!RookMove(x, y, ref moves))
                break;
        }

        return moves;
    }

    private bool RookMove(int x, int y, ref bool[,] moves)
    {
        Chessman piece = BoardManager.Instance.Chessmans[x, y];
        // If the cell is empty
        if (piece == null)
        {
            if(!this.KingInDanger(x, y))
                moves[x, y] = true;
            return true;    // Keep on looping
        }
        // If the piece is from opponent team
        else if (piece.isWhite != isWhite)
        {
            if(!this.KingInDanger(x, y))
                moves[x, y] = true;
        }

        // Else if the piece is from same team, do nothing
        
        return false;   // Stop the looping
    }
}