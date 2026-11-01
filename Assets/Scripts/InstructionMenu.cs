using UnityEngine;

public class InstructionMenu : MonoBehaviour
{
    [SerializeField] private GameObject instructionPanel;

    public void OpenInstructions()
    {
        instructionPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseInstructions()
    {
        instructionPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
