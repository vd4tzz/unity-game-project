using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownBoardSaveLoadManager : BoardSaveLoadManager<BrownBoardController>
{
    protected override void Awake()
    {
        base.boardSaveFile = "brown-board.json";
        base.Awake();
    }
}
