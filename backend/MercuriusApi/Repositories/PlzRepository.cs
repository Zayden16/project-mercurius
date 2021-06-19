using System;
using System.Collections.Generic;
using System.Linq;
using MercuriusApi.DataAccess;
using MercuriusApi.Models;
using MercuriusApi.Repositories.Interface;

namespace MercuriusApi.Repositories
{
    public class PlzRepository : IPlzRepository
    {
        private readonly PostgreSqlContext _context;

        public PlzRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddPlzRecord(Plz plz)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Plz.FirstOrDefault(x => x.Plz_Id == plz.Plz_Id);

                if (entity != null)
                    throw new Exception($"Entity with id: '{plz.Plz_Id}' already exists.");

                _context.Plz.Add(plz);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void DeletePlzRecord(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Plz.FirstOrDefault(t => t.Plz_Id == id);

                if (entity == null)
                    throw new Exception($"Entity with {id} not found.");

                _context.Plz.Remove(entity);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public Plz GetPlzSingleRecord(int id)
        {
            return _context.Plz.FirstOrDefault(t => t.Plz_Id == id);
        }

        public List<Plz> GetPlzRecords()
        {
            return _context.Plz.ToList();
        }
    }
}