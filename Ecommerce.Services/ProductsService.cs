﻿using Ecommerce.Database;
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Ecommerce.Services // services are used to communicate between the Web and the Database
{
    public class ProductsService
    {
        public void SaveProduct(Product product)
        {
            using (var context = new CBContext()) // create an object of 'CBContext' 
            {
                // keep category unchanged becasue we dont want to create another category with every product that we add
                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged; 

                context.Products.Add(product); // add 'category' argument to the database 'Categories', will be stored in memory not in database yet
                context.SaveChanges(); // will save it into the database
            }

        }

        public List<Product> GetProducts()
        {
            using (var context = new CBContext())
            {
                // 'Include' method will include the 'Category' for every product
                return context.Products.Include(x => x.Category).ToList(); // return the Products from the database as a list

            }
  
      


        }

        public Product GetProduct(int ID)
        {
            using (var context = new CBContext())
            {
                return context.Products.Find(ID); // return the category from the categories database based on the ID

            }

        }

        public void UpdatepProduct(Product product)
        {
            using (var context = new CBContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified; // updates the categories database
                context.SaveChanges(); 

            }

        }

        public void DeleteProduct(int ID)
        {
            using (var context = new CBContext())
            {
                var productToRemove = context.Products.Find(ID); // find the category to remove based on the ID parameter

                context.Products.Remove(productToRemove); // remove that category
                context.SaveChanges();

            }

        }
    }
}