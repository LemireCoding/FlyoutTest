using System;
using System.Collections.Generic;
using System.Text;
using FlyoutTest.Data_Access;
using SQLite;
namespace FlyoutTest.Models
{
   public class Movie : IDatabaseItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
     
        public string Genre { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
       
    }
}
