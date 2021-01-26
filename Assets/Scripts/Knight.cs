using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Chessman
{
    public Knight()
    {
        value = 30;
    }

    public override bool[,] PossibleMoves()
    {
        bool[,] moves = new bool[8, 8];
        int x = currentX;
        int y = currentY;

        // DownLeft
        KnightMove(x - 1, y - 2, ref moves);

        // DownRight
        KnightMove(x + 1, y - 2, ref moves);

        // RightDown
        KnightMove(x + 2, y - 1, ref moves);

        // RightUp
        KnightMove(x + 2, y + 1, ref moves);

        // LeftDown
        KnightMove(x - 2, y - 1, ref moves);

        // LeftUp
        KnightMove(x - 2, y + 1, ref moves);

        // UpLeft
        KnightMove(x - 1, y + 2, ref moves);

        // UpRight
        KnightMove(x + 1, y + 2, ref moves);

        return moves;
    }

    private void KnightMove(int x, int y, ref bool[,] moves)
    {
        if (x >= 0 && y >= 0 && x <= 7 && y <= 7)
        {
            Chessman piece = BoardManager.Instance.Chessmans[x, y];

            // If the cell is empty
            if (piece == null)
            {
                if(!this.KingInDanger(x, y))
                    moves[x, y] = true;
            }

            // If the piece is not from same team
            else if (piece.isWhite != isWhite)
            {
                if(!this.KingInDanger(x, y))
                    moves[x, y] = true;
            }

            // else if the piece is from same team, don't include it
        }
    }
}
