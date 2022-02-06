using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Button[] actionButtons;

    private KeyCode action1, action2;
    // Start is called before the first frame update
    void Start()
    {
        action1 = KeyCode.Alpha1;
        action2 = KeyCode.Alpha2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(action1))
        {
            actionButtonClick(0);
        }

        if (Input.GetKeyDown(action2))
        {
            actionButtonClick(1);
        }
    }

    private void actionButtonClick(int btnIndex)
    {
        actionButtons[btnIndex].onClick.Invoke();
    }
}
