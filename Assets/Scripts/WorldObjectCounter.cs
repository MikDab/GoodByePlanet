using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectCounter : MonoBehaviour
{
    /*   
       public StringVariable Pollution, Nature;
       public IntVariable TreeCount, FactoryCount, CutTreesCount, TrashCount, FireCount, TotalSpotCount, PolutionCount;
       SpotController[] All;

       void Start()
       {
           All = FindObjectsOfType<SpotController>();
           TotalSpotCount.Value = All.Length;
       }

       void Update()
       {
           TreeCount.Value = 0;
           FactoryCount.Value = 0;
           CutTreesCount.Value = 0;
           TrashCount.Value = 0;
           FireCount.Value = 0;

           int total = All.Length;

           foreach (SpotController spot in All)
           {
               if (spot.CurrentlyEnabled != null)
               {
                   if (spot.CurrentlyEnabled.name.Equals("Tree"))
                   {
                       TreeCount.Value++;
                   }
                   else if(spot.CurrentlyEnabled.name.Equals("Factory"))
                   {
                       FactoryCount.Value++;
                   }
                   else if (spot.CurrentlyEnabled.name.Equals("Fire"))
                   {
                       FireCount.Value++;
                   }
                   else if (spot.CurrentlyEnabled.name.Equals("Cut Trees"))
                   {
                       CutTreesCount.Value++;
                   }
                   else if (spot.CurrentlyEnabled.name.Equals("Trash"))
                   {
                       TrashCount.Value++;
                   }
               }
           }
           PolutionCount.Value = CalculatePollution();
           Pollution.Value = PolutionCount.Value + "/" + total + " Pollution";
           Nature.Value = TreeCount.Value.ToString() + "/" + total + " Trees";
       }

       public int CalculatePollution()
       {
           return FactoryCount.Value + TrashCount.Value + FireCount.Value + CutTreesCount.Value - TreeCount.Value;
       }

       public void AddPolution()
       {
           PolutionCount.Value++;
       }

       public void ReducePolution()
       {
           PolutionCount.Value--;
       }
       */
}
