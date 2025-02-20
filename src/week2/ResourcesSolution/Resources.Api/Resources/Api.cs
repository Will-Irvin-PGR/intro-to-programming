using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using Marten;
using Microsoft.AspNetCore.Mvc;

namespace Resources.Api.Resources;


// Get a 200 Ok when you do a GET /resources
public class Api(IValidator<ResourceListItemCreateModel> validator, IDocumentSession session) : ControllerBase
{

    [HttpGet("/resources")]
    public async Task<ActionResult> GetAllResources()
    {
        var response = await session.Query<ResourceListItemEntity>()
           .ProjectToResponse().ToListAsync();
        return Ok(response);
    }

    [HttpPost("/resources")]
    public async Task<ActionResult> AddResourceItem([FromBody] ResourceListItemCreateModel request)
    {

        var validations = await validator.ValidateAsync(request);

        if (validations.IsValid == false)
        {
            return BadRequest(validations.ToDictionary()); // more on that later.
        }

        // Do Business Stuff
        // Create, store entity in database

        //var entityToSave = new ResourceListItemEntity
        //{
        //    Id = Guid.NewGuid(),
        //    Description = request.Description,
        //    Link = request.Link,
        //    Tags = request.Tags,
        //    LinkText = request.LinkText,
        //    Title = request.Title,
        //    CreatedBy = "sue@aol.com",
        //    CreatedOn = DateTime.Now,
        //};
        var entityToSave = request.MapFromEntity();
        entityToSave.CreatedBy = "sue@aol.com";

        session.Store(entityToSave);
        await session.SaveChangesAsync();

        //var response = new ResourceListItemModel
        //{
        //    Id = entityToSave.Id,
        //    Title = entityToSave.Title,
        //    Description = entityToSave.Description,
        //    CreatedBy = entityToSave.CreatedBy,
        //    CreatedOn = entityToSave.CreatedOn,
        //    Link = entityToSave.Link,
        //    Tags = entityToSave.Tags,
        //};
        // Below call does above reassignment using the code in Mappers file
        var response = entityToSave.MapToResource();

        // TODO: Make this 201 code
        return Ok(response);
    }
}
