using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField] private GameObject door; // Reference to the door GameObject that this keypad controls
    private bool doorOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        // Implement the interaction logic for the keypad here
        doorOpen = !doorOpen; // Toggle the door state for demonstration
        door.GetComponent<Animator>().SetBool("IsOpened", doorOpen);
    }
}