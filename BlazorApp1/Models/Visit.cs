using System;

namespace BlazorApp1.Models;


    public class Visit
    {
        public int Id { get; set; }
        public DateTime DateOfVisit { get; set; }
        public Animal Animal { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
