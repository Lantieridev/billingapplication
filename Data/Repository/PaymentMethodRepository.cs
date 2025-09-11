using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using BillingApplication.Domain.Entities;
using BillingApplication.Data.Interfaces;
using System.Data;

namespace BillingApplication.Data.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly DapperContext _context;

        public PaymentMethodRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<PaymentMethod> GetByIdAsync(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = "SELECT * FROM FormasPago WHERE Id = @Id AND Activo = 1";
            return await connection.QueryFirstOrDefaultAsync<PaymentMethod>(sql, new { Id = id });
        }

        public async Task<IEnumerable<PaymentMethod>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<PaymentMethod>(
                "sp_FormasPago_GetAll",
                new { SoloActivos = 1 },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<int> AddAsync(PaymentMethod paymentMethod)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                INSERT INTO FormasPago (Nombre, Activo)
                VALUES (@Name, @Active);
                SELECT CAST(SCOPE_IDENTITY() as int)";

            return await connection.ExecuteScalarAsync<int>(sql, new
            {
                Name = paymentMethod.Nombre,
                Active = paymentMethod.Activo
            });
        }

        public async Task UpdateAsync(PaymentMethod paymentMethod)
        {
            using var connection = _context.CreateConnection();
            var sql = "UPDATE FormasPago SET Nombre = @Name WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new
            {
                Id = paymentMethod.Id,
                Name = paymentMethod.Nombre
            });
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = "UPDATE FormasPago SET Activo = 0 WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<PaymentMethod> GetByNameAsync(string name)
        {
            using var connection = _context.CreateConnection();
            var sql = "SELECT * FROM FormasPago WHERE Nombre = @Name AND Activo = 1";
            return await connection.QueryFirstOrDefaultAsync<PaymentMethod>(sql, new { Name = name });
        }
    }
}
