using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.Dto;
using Models;

//namespace Data.Contexts.MemoryContexts
//{
//    public class NutrientIntakeContextMemory
//    {
//        private static List<INutrientIntake> _nutrientIntakes;
//        private static bool _added;
//
//        public NutrientIntakeContextMemory()
//        {
//            if (_added) return;
//            var _articleContextMemory = new ArticleContextMemory();
//            
//            _nutrientIntakes = new List<INutrientIntake>
//            {
//                new NutrientIntakeDto
//                {
//                    Id = 1,
//                    Amount = 0.3,
//                    Nutrient = new NutrientContextMemory().Read(1),
//                    ArticleId = 1
//                },
//                new NutrientIntakeDto
//                {
//                    Id = 2,
//                    Amount = 0.001,
//                    Nutrient = new NutrientContextMemory().Read(1),
//                    ArticleId = 1
//                }
//            };
//
//            _added = true;
//        }
//    }
//}