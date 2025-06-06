namespace FormCMS;
public class ImageCompressionOptions
{
    public int MaxWidth { get; set; } = 1200;
    public int Quality { get; set; } = 75;
}

public sealed class RouteOptions
{
    public string ApiBaseUrl { get; set; } = "/api";
    public string PageBaseUrl { get; set; } = "";
}

public sealed class SystemSettings
{
    public const string PageCachePolicyName = "CmsPageCachePolicy";
    public const string QueryCachePolicyName = "CmsQueryCachePolicy";

    public bool EnableClient { get; set; } = true;
    public bool MapCmsHomePage { get; set; } = true;
    public string GraphQlPath { get; set; } = "/graph";
    public TimeSpan EntitySchemaExpiration { get; set; } = TimeSpan.FromMinutes(1);
    public TimeSpan PageSchemaExpiration { get; set; } = TimeSpan.FromMinutes(1);
    public TimeSpan QuerySchemaExpiration { get; set; } = TimeSpan.FromMinutes(1);

    public int DatabaseQueryTimeout { get; set; } = 30;
    public ImageCompressionOptions ImageCompression { get; set; } = new();
    public RouteOptions RouteOptions { get; set; } = new();
    public string[] KnownPaths { get; set; } = [];
}