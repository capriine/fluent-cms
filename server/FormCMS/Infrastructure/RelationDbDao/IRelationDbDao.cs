using System.Data;
using FormCMS.Utils.DataModels;
using SqlKata.Execution;

namespace FormCMS.Infrastructure.RelationDbDao;

public interface IRelationDbDao
{
    ValueTask<TransactionManager> BeginTransaction();
    bool InTransaction();
    internal Task<T> ExecuteKateQuery<T>(Func<QueryFactory,IDbTransaction?, Task<T>> queryFunc);
    Task<Column[]> GetColumnDefinitions(string table, CancellationToken ct);
    Task CreateTable(string table, IEnumerable<Column> cols, CancellationToken ct = default);
    Task AddColumns(string table, IEnumerable<Column> cols, CancellationToken ct = default);
    Task CreateForeignKey(string table, string col, string refTable, string refCol, CancellationToken ct);
    Task CreateIndex(string table, string[] fields, bool isUniq, CancellationToken ct);
    Task<bool> UpdateOnConflict(string tableName, Record data, string []keyField, CancellationToken ct);
    Task BatchUpdateOnConflict(string tableName, Record[]records, string[] keyField, CancellationToken ct);
    
    Task<long> Increase(string tableName, Record keyConditions, string valueField,long initVal, long delta, CancellationToken ct);

    Task<Dictionary<string,T>> FetchValues<T>(
        string tableName,
        Record? keyConditions,
        string? inField, IEnumerable<object>? inValues,
        string valueField,
        CancellationToken cancellationToken = default
    ) where T : struct;
    
    Task<long> MaxId(string tableName, string fieldName,CancellationToken ct = default);
    string CastDate(string field);
}