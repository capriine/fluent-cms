using System.Text.Json;
using System.Web;
using FluentResults;
using FormCMS.Utils.DisplayModels;
using FormCMS.Utils.HttpClientExt;

namespace FormCMS.Activities.ApiClient;

public class ActivityApiClient(HttpClient client)
{
    public Task<Result<Record[]>> PageCounts()
        => client.GetResult<Record[]>($"/page-counts?n={7}".ActivityUrl());
    
    public Task<Result<Record[]>> VisitCounts(bool authed)
        => client.GetResult<Record[]>($"/visit-counts?authed={authed}&n={7}".ActivityUrl());
    
    public Task<Result<Record[]>> ActivityCounts()
        => client.GetResult<Record[]>($"/activity-counts?n={7}".ActivityUrl());
    
    public Task Visit(string url)
        => client.GetResult($"/visit?url={HttpUtility.UrlEncode(url)}".ActivityUrl());
    
    public Task<Result<ListResponse>> List(string type,string qs)
        => client.GetResult<ListResponse>($"/list/{type}?{qs}".ActivityUrl());

    public Task<Result> Delete(long id)
        => client.PostResult($"/delete/{id}".ActivityUrl(), new { });
    
    public Task<Result<JsonElement>> Get(string entityName, long recordId)
    {
        var url = $"/{entityName}/{recordId}".ActivityUrl();
        return client.GetResult<JsonElement>(url);
    }
    
    public Task<Result<JsonElement[]>> TopList(string entityName, int offset, int limit)
    {
        var url = $"/top/{entityName}/?offset={offset}&limit={limit}".ActivityUrl();
        return client.GetResult<JsonElement[]>(url);
    }

    public Task<Result<long>> Toggle(string entityName, long recordId, string activityType, bool active)
    {
        var url = $"/toggle/{entityName}/{recordId}?type={activityType}&active={active}".ActivityUrl();
        return client.PostResult<long>(url, new object());
    }

    public Task<Result<long>> Record(string entityName, long recordId, string activityType)
    {
        var url = $"/record/{entityName}/{recordId}?type={activityType}".ActivityUrl();
        return client.PostResult<long>(url, new object());
    }
}