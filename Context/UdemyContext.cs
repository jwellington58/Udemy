using Microsoft.EntityFrameworkCore;
using Udemy.Models;

namespace Udemy.Context
{
    public class UdemyContext : DbContext
    {   
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Make> Makes{get;set;}
        public DbSet<Feature> Features{get;set;}
        public DbSet<Model> Models{ get; set;}
        public UdemyContext(DbContextOptions<UdemyContext> options) : base(options)
        {}
        
        //Para adicionar uma chave composta
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //Aidiciono uma chave composta na minha Tabela VehicleFeature
            modelBuilder.Entity<VehicleFeature>().HasKey(vf =>
                new {vf.VehicleId, vf.FeatureId});
        }
    }
}