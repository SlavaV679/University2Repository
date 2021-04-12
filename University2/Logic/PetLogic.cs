using System.Collections.Generic;
using University.Models;

namespace University.Logic
{
    public class PetLogic
    {
        public List<Pet> GeneratePets()
        {
            return new List<Pet>
            {
                new Pet(1, "Marusia", "Cat", 1.235, 1),
                new Pet(2, "Zhuzha", "Dog", 2.540, 5),
                new Pet(3, "Senia", "Cat", 1.301,7 ),
                new Pet(4, "Druzhok", "Dog", 2.150, 8),
                new Pet(5, "Eva", "Dog", 0.890, 9)
            };
        } 
    }
}