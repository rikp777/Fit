using System;
using System.Collections.Generic;
using System.Linq;
using Data.Contexts.Interfaces;
using Data.Dto;
using Models;

namespace Data.Contexts.MemoryContexts
{
    public class DishContectMemory : IDishContext
    {
        private static List<IDish> _dishes;
        private static bool _added;

        public DishContectMemory()
        {
            if (_added) return;
            var articleDishDtos = new ArticleContextMemory()
                .List()
                .Select(article => new ArticleDishDto
                {
                    Article = new ArticleContextMemory().Read(1),
                    Amount = 5
                }).ToList();
            
            _dishes = new List<IDish>
            {
                new DishDto
                {
                    Id = 1,
                    Name = "Fruithapje",
                    ArticleDishes = articleDishDtos                   
                }
               
            };
            _added = true;
        }
        private static DishDto InterfaceToDto(IDish dish)
        {     
            var dishDto = new DishDto
            {
                Id = dish.Id,
                Name = dish.Name,
                ArticleDishes = dish.ArticleDishes
            };
            return dishDto;
        }

        
        
        
        
        public bool Create(IDish dish)
        {        
            if (_dishes.SingleOrDefault(u => u.Name == dish.Name) != null) return false;
             
            var dishDto = InterfaceToDto(dish);
            dishDto.Id = _dishes.Count;
                     
            _dishes.Add(dishDto);
            
            return true;
        }

        
        
        
        
        public IDish Read(int id)
        {
            var dishes = _dishes.FirstOrDefault(d => d.Id == id);
            return dishes;
        }
        public IDish Read(string name)
        {
            var dishes = _dishes.FirstOrDefault(d => d.Name == name);
            return dishes;
        }
        public IDish Read(IDish dish)
        {
            var dishes = _dishes.FirstOrDefault(d => d.Id == dish.Id);
            return dishes;
        }

        
        
            
        
        public bool Update(IDish dish)
        {
            try
            {
                _dishes[dish.Id - 1] = InterfaceToDto(dish);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        
        
        
        
        public bool Delete(int id)
        {
            try
            {
                _dishes.Remove(_dishes.SingleOrDefault(u => u.Id == id));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        
        
        
        
        public IEnumerable<IDish> List()
        {
            return _dishes;
        }
    }
    
}