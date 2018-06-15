using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public static class ActionMaster {
	public enum Action {Tidy, Reset, EndTurn, EndGame, Undefined};
	
	public static Action NextAction (List<int> rolls) {
		Action nextAction = Action.Undefined;
		
		for (int i = 0; i < rolls.Count; i++) { // Step through rolls

			// Last roll
			if (i == 21 - 1) {
				nextAction = Action.EndGame;
			} 
			// Last frame strike
			else if ( i == 19 - 1 && rolls[i] == 10 ){ 
				nextAction = Action.Reset;
			}
			else if ( i == 20 - 1 ) {
				if (((rolls[19 - 1] + rolls[20 - 1]) % 10 == 0) && rolls[i] != 0) { // Strike or Strikes
					nextAction = Action.Reset;
				} else if (rolls [19 - 1] + rolls[20 - 1] >= 10) {  // 21 roll awarded
					nextAction = Action.Tidy;
				} else {
					nextAction = Action.EndGame;
				}
			} 
			// First bowl of frame
			else if (i % 2 == 0) { 
				if (rolls[i] == 10) { // Strike
					rolls.Insert (i, 0); // Insert virtual 0 after strike
					nextAction = Action.EndTurn;
				} else {
					nextAction = Action.Tidy;
				}
			} 
			// Second bowl of frame
			else { 
				nextAction = Action.EndTurn;
			}
		}
		
		return nextAction;
	}
}