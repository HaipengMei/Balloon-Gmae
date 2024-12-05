using UnityEngine;

public class InstructionControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject instructionText;

    //Make the instruction become visible when you hit instruction bottom
    public void ToggleInstruction(){
        if(instructionText != null){
            instructionText.SetActive(!instructionText.activeSelf);
        }
    }
}
