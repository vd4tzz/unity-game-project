using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoardSaveLoadManager : BoardSaveLoadManager<BlackBoardController>
{
    protected override void Awake()
    {
        boardSaveFile = "black-board.json";
        base.Awake();
    }
}
