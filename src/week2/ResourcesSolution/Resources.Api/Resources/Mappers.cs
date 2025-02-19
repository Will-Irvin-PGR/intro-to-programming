
using System.Runtime.Serialization;
using Riok.Mapperly.Abstractions;

namespace Resources.Api.Resources;

//public static class EntityMappers
//{
//    public static ResourceListItemModel MapToResource(this ResourceListItemEntity entity)
//    {
//        return new ResourceListItemModel
//        {
//            Id = entity.Id,
//            Title = entity.Title,
//            Description = entity.Description,
//            CreatedBy = entity.CreatedBy,
//            CreatedOn = entity.CreatedOn,
//            Link = entity.Link,
//            Tags = entity.Tags,
//        };
//    }
//}

[Mapper]
public static partial class EntityMappers
{
    [MapperIgnoreTarget(nameof(ResourceListItemEntity.Id))]
    [MapperIgnoreTarget(nameof(ResourceListItemEntity.CreatedOn))]
    [MapperIgnoreTarget(nameof(ResourceListItemEntity.CreatedBy))]
    public static partial ResourceListItemEntity MapFromEntity(this ResourceListItemCreateModel entity);
    public static partial ResourceListItemModel MapToResource(this ResourceListItemEntity entity);

    public static partial IQueryable<ResourceListItemModel> ProjectToResponse(this IQueryable<ResourceListItemEntity> entity);
}