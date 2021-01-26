using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWinner : MonoBehaviour
{
	public static UpdateWinner Instance { set; get; }

	public Text winner;

	private bool updated = false;

    // Start is called before the first frame update
    void Update()
    {
    	if(!updated)
    	{
    		if(BoardManager.Instance.isWhiteTurn)
	    		winner.text = "Black Team Wins!!";
	    	else
	    		winner.text = "White Team Wins!!";

	    	updated = true;
    	}
	    	
    }
}
