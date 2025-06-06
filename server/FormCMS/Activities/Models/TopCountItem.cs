using FormCMS.Core.Assets;
using FormCMS.Core.Descriptors;
using FormCMS.Utils.RecordExt;
using Humanizer;

namespace FormCMS.Activities.Models;

public record TopCountItem(
    string I,
    string EntityName, 
    long RecordId,
    long Count,
    string Title, 
    string Image, 
    string Url, 
    string PublishedAt,
    Dictionary<string,long> Counts
    );

public static class TopCountItemHelper
{
    public static void LoadMetaData(LoadedEntity entity, Record item ,Record? queryResult)
    {
        item[nameof(TopCountItem.Url).Camelize()] = entity.PageUrl  + item[nameof(TopCountItem.RecordId).Camelize()];
        if (queryResult == null) return;
        if (queryResult.ByJsonPath<string>(entity.BookmarkTitleField, out var title) && title is not null)
        {
            item[nameof(TopCountItem.Title).Camelize()] = title;
        }

        if (queryResult.ByJsonPath<Asset>(entity.BookmarkImageField, out var asset) && asset is not null)
        {
            item[nameof(TopCountItem.Image).Camelize()] = asset.Url;
        }

        if (queryResult.ByJsonPath<DateTime>(entity.BookmarkPublishTimeField, out var publishTime))
        {
            item[nameof(TopCountItem.PublishedAt).Camelize()] = publishTime;
        }
    }
}