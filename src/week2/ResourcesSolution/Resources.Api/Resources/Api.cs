using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Resources.Api.Resources;


// Get a 200 Ok when you do a GET /resources
public class Api(IValidator<ResourceListItemCreateModel> validator) : ControllerBase
{

    [HttpGet("/resources")]
    public async Task<ActionResult> GetAllResources()
    {
        var fakeData = new List<ResourceListItemModel>()
    {
        new ResourceListItemModel()
        {
          Id = Guid.NewGuid(),
          Title = "Learn .NET",
          Description = "Microsoft's .NET Educational Site",
          CreatedBy = "bob@aol.com",
          CreatedOn = DateTime.Now,
          Link = "https://dotnet.microsoft.com/en-us/learn",
          Tags = [".NET","Microsoft", "APIS"]
        }
    };
        return Ok(fakeData);
    }

    [HttpPost("/resources")]
    public async Task<ActionResult> AddResourceItem([FromBody] ResourceListItemCreateModel request)
    {

        var validations = await validator.ValidateAsync(request);

        if (validations.IsValid == false)
        {
            return BadRequest(validations.ToDictionary()); // more on that later.
        }
        var fakeResponse = new ResourceListItemModel
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            CreatedBy = "sue@aol.com", // ??
            CreatedOn = DateTime.Now,
            Link = request.Link,
            Tags = request.Tags,
        };
        return Ok(fakeResponse);
    }
}
