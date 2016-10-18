﻿using CoreBusinessObjects;
using CoreBusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class ApiContext : DbContext
    {
        #region Properties

        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Team> Teams { get; set; }

        #endregion // Properties

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options"></param>
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {

        }

        #endregion // Constructors
    }
}
