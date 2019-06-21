using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Game : MonoBehaviour
{
    private List<Pet> selectedPets = new List<Pet>();
    private Pet.Type currentPetType;

    [SerializeField] private Spawner spawner;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Pet pet;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject != null)
            {
                pet = hit.collider.GetComponent<Pet>();
                if (pet != null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        StartSelection(pet);
                    }
                    else
                    {
                        Drag(pet);
                    }
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Up();
        }
    }

    private void StartSelection(Pet pet)
    {
        currentPetType = pet.type;
        SelectPet(pet);      
    }

    private void Drag(Pet pet)
    {
        if (selectedPets.Count > 0)
        {
            if (!selectedPets.Contains(pet))
            {
                if (Vector2.Distance(pet.transform.position, selectedPets.Last().transform.position) < 2.5f &&
                    pet.type == currentPetType)
                {
                    SelectPet(pet);
                }
            }
            else
            {
                if (selectedPets.Count > 1 && pet == selectedPets[selectedPets.Count - 2])
                {
                    DeselectPet(selectedPets.Last());
                }
            }
        }
    }

    private void SelectPet(Pet pet)
    {
        selectedPets.Add(pet);
        pet.Select();
    }

    private void DeselectPet(Pet pet)
    {
        selectedPets.Remove(pet);
        pet.Deselect();
    }

    private void Up()
    {
        if (selectedPets.Count > 2)
        {
            foreach (Pet pet in selectedPets)
            {
                pet.Destroy();
            }
            spawner.Spawn(selectedPets.Count);
        }
        else
        {
            foreach (Pet pet in selectedPets)
            {
                pet.Deselect();
            }          
        }
        
        selectedPets.Clear();
    }


}
