using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories.Interfaces
{
    public interface IAuditLogRepository : IGenericRepository<AuditLog>
    {
        Task LogAsync(int? userId, string action, string entityName, int? entityId,
            string? oldValues = null, string? newValues = null, string? ipAddress = null);
        Task<List<AuditLog>> GetRecentLogsAsync(int count = 50);
    }
}
