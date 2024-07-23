using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindOptions : MonoBehaviour
{
    [SerializeField]private Button optionsButton;
    private Pause options;
    private void Start()
    {
        optionsButton.onClick.AddListener(() => {
            options = FindObjectOfType<Pause>(true);
            options.gameObject.SetActive(true);
            });

    }
}
