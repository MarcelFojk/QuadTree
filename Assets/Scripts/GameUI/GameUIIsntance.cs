using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIIsntance : Singleton<GameUIIsntance>
{
    public TextMeshProUGUI textUI;

    private void Awake()
    {
        AssignIsntance(this);
    }
}
