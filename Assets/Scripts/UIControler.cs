using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControler : MonoBehaviour {

    public int TokenCount = 0;

    public Text _Text;

    public void UpdateToken()
    {
        TokenCount += 1;
        _Text.text = "Tokens : " + TokenCount.ToString();
    }

    public void ResetToken()
    {
        TokenCount = 0;
		_Text.text = "Tokens : " + TokenCount.ToString();
    }
}
