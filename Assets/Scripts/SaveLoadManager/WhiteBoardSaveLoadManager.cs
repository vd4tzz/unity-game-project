using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoardSaveLoadManager : BoardSaveLoadManager<WhiteBoardController>
{
    protected override void Awake()
    {
        base.boardSaveFile = "white-board.json";
        base.Awake();
    }
}
