using System;
using System.Collections.Generic;
using DocLogicielleAPI.DTO;

namespace DocLogicielleAPI.Data
{
    public static class SourceData
    {
        public static List<Voiture> Voitures()
        {
            List<Voiture> voitures = new List<Voiture>() {
                new Voiture {
                    Id = 1,
                    Nom = "Voiture 1",
                    Type = "BMW",
                    Puissance = 300,
                },
                new Voiture {
                    Id = 2,
                    Nom = "Voiture 2",
                    Type = "AUDI",
                    Puissance = 120,
                },
                new Voiture {
                    Id = 3,
                    Nom = "Voiture 3",
                    Type = "MERCEDES",
                    Puissance = 320,
                }
            };
            return voitures;
        }

    }
}
