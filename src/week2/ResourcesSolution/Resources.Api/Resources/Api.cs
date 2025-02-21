using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using Marten;
using Microsoft.AspNetCore.Mvc;

namespace Resources.Api.Resources;


// Get a 200 Ok when you do a GET /resources
public class Api(IValidator<ResourceListItemCreateModel> validator, IDocumentSession session, INotifytheSecurityReviewTeam _securityReviewTeam) : ControllerBase
{

    [HttpGet("/resources")]
    public async Task<ActionResult> GetAllResources()
    {
        var response = await session.Query<ResourceListItemEntity>()
           .ProjectToResponse().ToListAsync();
        return Ok(response);
    }

    [HttpPost("/resources")]
    public async Task<ActionResult> AddResourceItem(
    [FromBody] ResourceListItemCreateModel request,
    [FromServices] UserInformationProvider userInfo)
    {


        var validations = await validator.ValidateAsync(request);

        if (validations.IsValid == false)
        {
            return BadRequest(validations.ToDictionary()); // more on that later.
        }


        var entityToSave = request.MapFromEntity();


        entityToSave.CreatedBy = await userInfo.GetUserNameAsync();
        session.Store(entityToSave);
        await session.SaveChangesAsync();
        if (request.Tags.Any(t => t == "security"))
        {
            // send an HTTP request to an API that doesn't even exist yet, and take the code that doesn't exist yet, and store it in the database
            // and add a property to the response that says "pendingSecurityReview"
            string securityReviewId = await _securityReviewTeam.NotifyForSecurityReview(entityToSave.Id);
            entityToSave.SecurityReviewId = securityReviewId;
        }


        var response = entityToSave.MapToResource();
        if (entityToSave.SecurityReviewId != null)
        {
            response.IsBeingReviewedForSecurity = true;
        }


        return Ok(response);
    }

    // Before last day
    //[HttpPost("/resources")]
    //public async Task<ActionResult> AddResourceItem([FromBody] ResourceListItemCreateModel request)
    //{

    //    var validations = await validator.ValidateAsync(request);

    //    if (validations.IsValid == false)
    //    {
    //        return BadRequest(validations.ToDictionary()); // more on that later.
    //    }

    //    // Do Business Stuff
    //    // Create, store entity in database

    //    //var entityToSave = new ResourceListItemEntity
    //    //{
    //    //    Id = Guid.NewGuid(),
    //    //    Description = request.Description,
    //    //    Link = request.Link,
    //    //    Tags = request.Tags,
    //    //    LinkText = request.LinkText,
    //    //    Title = request.Title,
    //    //    CreatedBy = "sue@aol.com",
    //    //    CreatedOn = DateTime.Now,
    //    //};

    //    // Does the same as above (see mapper class)
    //    var entityToSave = request.MapFromEntity();
    //    entityToSave.CreatedBy = "sue@aol.com";

    //    session.Store(entityToSave);
    //    await session.SaveChangesAsync();

    //    //var response = new ResourceListItemModel
    //    //{
    //    //    Id = entityToSave.Id,
    //    //    Title = entityToSave.Title,
    //    //    Description = entityToSave.Description,
    //    //    CreatedBy = entityToSave.CreatedBy,
    //    //    CreatedOn = entityToSave.CreatedOn,
    //    //    Link = entityToSave.Link,
    //    //    Tags = entityToSave.Tags,
    //    //};
    //    // Below call does above reassignment using the code in Mappers file
    //    var response = entityToSave.MapToResource();

    //    // TODO: Make this 201 code
    //    return Ok(response);
    //}
}

public class UserInformationProvider
{
    public async Task<string> GetUserNameAsync()
    {
        return "sue@aol.com";
    }
}

public interface INotifytheSecurityReviewTeam
{
    Task<string> NotifyForSecurityReview(Guid id);
}