using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DisplayName : MonoBehaviour
{
    public TMP_Text nam;
    public TMP_InputField inputField;
    private string player_name;
 

    public void Update()
    {
        if (nam.text.Length == 0) { nam.text = Manager.Instance.GetPlayerName(); }
        if (inputField.text.Length == 0) { nam.text = Manager.Instance.GetPlayerName(); }
        else { nam.text = inputField.text;  player_name = inputField.text;}
      
    }
    public void SetName() 
    { 
        nam.text = inputField.text; 
        player_name = nam.text;
        Manager.Instance.SaveName(player_name);
    }
   
}
