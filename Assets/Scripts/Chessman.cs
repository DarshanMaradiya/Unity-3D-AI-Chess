using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Chessman : MonoBehaviour
{
    public int currentX { set; get; }
    public int currentY { set; get; }
    public bool isWhite;
    public int value;
    public bool isMoved = false;

    public Chessman Clone()
    {
       return (Chessman) this.MemberwiseClone();
    }

    public void SetPosition(int x, int y)
    {
        currentX = x;
        currentY = y;
    }

    public virtual bool[,] PossibleMoves()
    {
        bool[,] arr = new bool[8,8];
        for(int i=0; i<8; i++)
        {
            for(int j=0; j<8; j++)
            {
                arr[i, j] = false;
            }
        }
        return arr;
    }

    public bool InDanger()
    {
        Chessman piece = null;

        int x = currentX;
        int y = currentY;

        // Down
        if(y - 1 >= 0)
        {
            piece = BoardManager.Instance.Chessmans[x, y - 1];
            // If the cell is not empty and and the piece is from opponent and is King
            if(piece != null && piece.isWhite != isWhite &&  piece.GetType() == typeof(King))
                return true;
        }
        while (y-- > 0)
        {
            piece = BoardManager.Instance.Chessmans[x, y];
            // If the cell is empty
            if (piece == null)
                continue;
            
            // If the piece is from same team
            else if (piece.isWhite == isWhite)
                break;

            // Else if the piece is from opponent team
            if(piece.GetType() == typeof(Rook) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Rook/Queen Down");
                return true;
            }

            break;
        }

        x = currentX;
        y = currentY;
        // Right
        if(x + 1 <= 7)
        {
            piece = BoardManager.Instance.Chessmans[x + 1, y];
            // If the cell is not empty and and the piece is from opponent and is King
            if(piece != null && piece.isWhite != isWhite &&  piece.GetType() == typeof(King))
                return true;
        }
        while (x++ < 7)
        {
            piece = BoardManager.Instance.Chessmans[x, y];
            // If the cell is empty
            if (piece == null)
                continue;
            
            // If the piece is from same team
            else if (piece.isWhite == isWhite)
                break;

            // Else if the piece is from opponent team
            if(piece.GetType() == typeof(Rook) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Rook/Queen Right");
                return true;
            }

            break;
        }

        x = currentX;
        y = currentY;
        // Left
        if(x - 1 >= 0)
        {
            piece = BoardManager.Instance.Chessmans[x - 1, y];
            // If the cell is not empty and and the piece is from opponent and is King
            if(piece != null && piece.isWhite != isWhite &&  piece.GetType() == typeof(King))
                return true;
        }
        while (x-- > 0)
        {
            piece = BoardManager.Instance.Chessmans[x, y];
            // If the cell is empty
            if (piece == null)
                continue;
            
            // If the piece is from same team
            else if (piece.isWhite == isWhite)
                break;

            // Else if the piece is from opponent team
            if(piece.GetType() == typeof(Rook) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Rook/Queen Left");
                return true;
            }

            break;
        }

        x = currentX;
        y = currentY;
        // Up
        if(y + 1 <= 7)
        {
            piece = BoardManager.Instance.Chessmans[x, y + 1];
            // If the cell is not empty and and the piece is from opponent and is King
            if(piece != null && piece.isWhite != isWhite &&  piece.GetType() == typeof(King))
                return true;
        }
        while (y++ < 7)
        {
            piece = BoardManager.Instance.Chessmans[x, y];
            // If the cell is empty
            if (piece == null)
                continue;
            
            // If the piece is from same team
            else if (piece.isWhite == isWhite)
                break;

            // Else if the piece is from opponent team
            if(piece.GetType() == typeof(Rook) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Rook/Queen Up");
                return true;
            }

            break;
        }

        x = currentX;
        y = currentY;
        // Left to right Down Diagonal
        if(x + 1 <= 7 && y - 1 >= 0 && isWhite)
        {
            piece = BoardManager.Instance.Chessmans[x + 1, y - 1];
            // If the cell is not empty and and the piece is from opponent and is Pawn
            if(piece != null && piece.isWhite != isWhite && piece.GetType() == typeof(Pawn))
                return true;
        }
        if(x + 1 <= 7 && y - 1 >= 0)
        {
            piece = BoardManager.Instance.Chessmans[x + 1, y - 1];
            // If the cell is not empty and and the piece is from opponent and is King
            if(piece != null && piece.isWhite != isWhite &&  piece.GetType() == typeof(King))
                return true;
        }
        while (x++ < 7 && y-- > 0)
        {
            piece = BoardManager.Instance.Chessmans[x, y];
            // If the cell is empty
            if (piece == null)
                continue;
            
            // If the piece is from same team
            else if (piece.isWhite == isWhite)
                break;

            // Else if the piece is from opponent team
            if(piece.GetType() == typeof(Bishup) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Bishup/Queen LR Down");
                return true;
            }

            break;
        }

        x = currentX;
        y = currentY;
        // Left to right Up Diagonal
        if(x + 1 <= 7 && y + 1 <= 7 && !isWhite)
        {
            piece = BoardManager.Instance.Chessmans[x + 1, y + 1];
            // If the cell is not empty and and the piece is from opponent and is Pawn
            if(piece != null && piece.isWhite != isWhite && piece.GetType() == typeof(Pawn))
                return true;
        }
        if(x + 1 <= 7 && y + 1 <= 7)
        {
            piece = BoardManager.Instance.Chessmans[x + 1, y + 1];
            // If the cell is not empty and and the piece is from opponent and is King
            if(piece != null && piece.isWhite != isWhite &&  piece.GetType() == typeof(King))
                return true;
        }
        while (x++ < 7 && y++ < 7)
        {
            piece = BoardManager.Instance.Chessmans[x, y];
            // If the cell is empty
            if (piece == null)
                continue;
            
            // If the piece is from same team
            else if (piece.isWhite == isWhite)
                break;

            // Else if the piece is from opponent team
            if(piece.GetType() == typeof(Bishup) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Bishup/Queen LR Up");
                return true;
            }

            break;
        }

        x = currentX;
        y = currentY;
        // Right to left Down Diagonal
        if(x - 1 >= 0 && y - 1 >= 0 && isWhite)
        {
            piece = BoardManager.Instance.Chessmans[x - 1, y - 1];
            // If the cell is not empty and and the piece is from opponent and is Pawn
            if(piece != null && piece.isWhite != isWhite && piece.GetType() == typeof(Pawn))
                return true;
        }
        if(x - 1 >= 0 && y - 1 >= 0)
        {
            piece = BoardManager.Instance.Chessmans[x - 1, y - 1];
            // If the cell is not empty and and the piece is from opponent and is King
            if(piece != null && piece.isWhite != isWhite &&  piece.GetType() == typeof(King))
                return true;
        }
        while (x-- > 0 && y-- > 0)
        {
            piece = BoardManager.Instance.Chessmans[x, y];
            // If the cell is empty
            if (piece == null)
                continue;
            
            // If the piece is from same team
            else if (piece.isWhite == isWhite)
                break;

            // Else if the piece is from opponent team
            if(piece.GetType() == typeof(Bishup) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Bishup/Queen RL Down");
                return true;
            }

            break;
        }

        x = currentX;
        y = currentY;
        // Right to left Up Diagonal
        if(x - 1 >= 0 && y + 1 <= 7 && !isWhite)
        {
            piece = BoardManager.Instance.Chessmans[x - 1, y + 1];
            // If the cell is not empty and and the piece is from opponent and is Pawn
            if(piece != null && piece.isWhite != isWhite && piece.GetType() == typeof(Pawn))
                return true;
        }
        if(x - 1 >= 0 && y + 1 <= 7)
        {
            piece = BoardManager.Instance.Chessmans[x - 1, y + 1];
            // If the cell is not empty and and the piece is from opponent and is King
            if(piece != null && piece.isWhite != isWhite &&  piece.GetType() == typeof(King))
                return true;
        }
        while (x-- > 0 && y++ < 7)
        {
            piece = BoardManager.Instance.Chessmans[x, y];
            // If the cell is empty
            if (piece == null)
                continue;
            
            // If the piece is from same team
            else if (piece.isWhite == isWhite)
                break;

            // Else if the piece is from opponent team
            if(piece.GetType() == typeof(Bishup) || piece.GetType() == typeof(Queen))
            {
                Debug.Log("Threat from Bishup/Queen RL Up");
                return true;
            }

            break;
        }

        x = currentX;
        y = currentY;
        // Knight Threats
        // DownLeft
        if(KnightThreat(x - 1, y - 2))
            return true;

        // DownRight
        if(KnightThreat(x + 1, y - 2))
            return true;

        // RightDown
        if(KnightThreat(x + 2, y - 1))
            return true;

        // RightUp
        if(KnightThreat(x + 2, y + 1))
            return true;

        // LeftDown
        if(KnightThreat(x - 2, y - 1))
            return true;

        // LeftUp
        if(KnightThreat(x - 2, y + 1))
            return true;

        // UpLeft
        if(KnightThreat(x - 1, y + 2))
            return true;

        // UpRight
        if(KnightThreat(x + 1, y + 2))
            return true;

        return false;
    }

    public bool KnightThreat(int x, int y)
    {
        if (x >= 0 && y >= 0 && x <= 7 && y <= 7)
        {
            Chessman piece = BoardManager.Instance.Chessmans[x, y];
            // If the cell is empty
            if (piece == null)
                return false;

            // If the piece is from same team
            if (piece.isWhite == isWhite)
                return false;

            // The piece is from Opponent team
            // If the opponent piece is Knight
            if(piece.GetType() == typeof(Knight))
            {
                Debug.Log("Threat from Knight");
                return true;        // Yes, there is a Knight threat
            }
        }

        return false;
    }

    public bool KingInDanger(int x, int y)
    {
        // Critical Part : 
        // We are about to move piece on the chessboard(not in the scene) without yet recieving command
        // To check whether this move will put King in danger/Check State or not
        // So that we can disallowed the move
        // After checking we will undo the move we have made
        // And every change will be undone only in this function
        // Again : this won't have any effect on the scene

        // ------------- Backup start -------------
        // Storing the reference of chessman where we are about to move
        Chessman tmpChessman = BoardManager.Instance.Chessmans[x, y];
        int tmpCurrentX = currentX;
        int tmpCurrentY = currentY;
        // ------------- Backup end -------------

        // Leaving the position, making the move, updating co-ordinates
        BoardManager.Instance.Chessmans[currentX, currentY] = null;
        BoardManager.Instance.Chessmans[x, y] = this;
        this.SetPosition(x, y);

        // We will store the decision in result
        bool result = false;
        // Now checking whether the King is in danger now or not
        if(isWhite)
            result = BoardManager.Instance.WhiteKing.InDanger();
        else
            result = BoardManager.Instance.BlackKing.InDanger();

        // Now Undoing
        this.SetPosition(tmpCurrentX, tmpCurrentY);
        BoardManager.Instance.Chessmans[tmpCurrentX, tmpCurrentY] = this;
        BoardManager.Instance.Chessmans[x, y] = tmpChessman;
        

        // Return the result
        return result;
    }
}
