using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager2 : MonoBehaviour
{
    public TextMeshProUGUI infoText;

    public void ShowVelociraptorInfo()
    {
        infoText.text =
            "Velociraptor\n\n" +
            "Period: Late Cretaceous\n" +
            "Diet: Carnivore\n" +
            "Fact: Feathered predator with a sickle-shaped claw.";
    }

    public void ShowStegosaurusInfo()
    {
        infoText.text =
            "Stegosaurus\n\n" +
            "Period: Late Jurassic\n" +
            "Diet: Herbivore\n" +
            "Fact: Had large plates and a spiked tail.";
    }

    public void ShowPachyInfo()
    {
        infoText.text =
            "Pachycephalosaurus\n\n" +
            "Period: Late Cretaceous\n" +
            "Diet: Herbivore\n" +
            "Fact: Had a thick domed skull.";
    }
}

