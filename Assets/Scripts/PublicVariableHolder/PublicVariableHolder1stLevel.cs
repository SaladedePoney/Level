using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PublicVariableHolder1stLevel : MonoBehaviour {
    
    public PublicVariableHolderNeverUnload HolderNeverUnload;

    public PauseMenu PauseMenu;
    public GameObject Player;
    public Text TokenLevelText;
    public Text LevelName;
    public Canvas PlayerCanvas;
    public GameObject MainCamera;
    public ScreenFader ScreenFader;
    public GameObject AttackSlider;

    private void Awake()
    {
        HolderNeverUnload = GameObject.Find("PublicVariableHolderNeverUnload").GetComponent<PublicVariableHolderNeverUnload>();

        Player = HolderNeverUnload.Player;
        PauseMenu = HolderNeverUnload.PauseMenu;
        TokenLevelText = HolderNeverUnload.TokenLevelText;
        LevelName = HolderNeverUnload.LevelName;
        PlayerCanvas = HolderNeverUnload.PlayerCanvas;
        MainCamera = HolderNeverUnload.MainCamera;
        ScreenFader = HolderNeverUnload.ScreenFader;
        AttackSlider = HolderNeverUnload.AttackSlider;
    }
}
