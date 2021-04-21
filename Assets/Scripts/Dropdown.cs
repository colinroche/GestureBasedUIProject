using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropdown : MonoBehaviour
{

    [SerializeField] GameObject AxeReal;
    [SerializeField] GameObject AxeFake;
    [SerializeField] GameObject ClubReal;
    [SerializeField] GameObject ClubFake;
    [SerializeField] GameObject DaggerReal;
    [SerializeField] GameObject DaggerFake;
    [SerializeField] GameObject HammerReal;
    [SerializeField] GameObject HammerFake;
    [SerializeField] GameObject ScytheReal;
    [SerializeField] GameObject ScytheFake;
    [SerializeField] GameObject SpearReal;
    [SerializeField] GameObject SpearFake;
    [SerializeField] GameObject SwordReal;
    [SerializeField] GameObject SwordFake;
    [SerializeField] Dropdown dropdown;

    private int savedVal = 0;

    public void HandleInputData(int val)
    {
        // Reset the current weapon
        if(savedVal == 0){
            AxeReal.SetActive(false);
            AxeFake.SetActive(true);
        }else if(savedVal == 1){
            print("Club");
            ClubReal.SetActive(false);
            ClubFake.SetActive(true);
        }else if(savedVal == 2){
            print("Dagger");
            DaggerReal.SetActive(false);
            DaggerFake.SetActive(true);
        }else if(savedVal == 3){
            print("Hammer");
            HammerReal.SetActive(false);
            HammerFake.SetActive(true);
        }else if(savedVal == 4){
            print("Scythe");
            ScytheReal.SetActive(false);
            ScytheFake.SetActive(true);
        }else if(savedVal == 5){
            print("Spear");
            SpearReal.SetActive(false);
            SpearFake.SetActive(true);
        }else if(savedVal == 6){
            print("Sword");
            SwordReal.SetActive(false);
            SwordFake.SetActive(true);
        }
        // Set new weapon
        if(val == 0){
            savedVal = 0;
            AxeReal.SetActive(true);
            AxeFake.SetActive(false);
        }else if(val == 1){
            savedVal = 1;
            ClubReal.SetActive(true);
            ClubFake.SetActive(false);
        }else if(val == 2){
            savedVal = 2;
            DaggerReal.SetActive(true);
            DaggerFake.SetActive(false);
        }else if(val == 3){
            savedVal = 3;
            HammerReal.SetActive(true);
            HammerFake.SetActive(false);
        }else if(val == 4){
            savedVal = 4;
            ScytheReal.SetActive(true);
            ScytheFake.SetActive(false);
        }else if(val == 5){
            savedVal = 5;
            SpearReal.SetActive(true);
            SpearFake.SetActive(false);
        }else if(val == 6){
            savedVal = 6;
            SwordReal.SetActive(true);
            SwordFake.SetActive(false);
        }

        



    }
}
