using IndividualsDirectory.Application.Common;
using IndividualsDirectory.Application.Person.Command.UpdatePersonImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IndividualsDirectory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageController(IMediator mediator, ImageService imageService) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly ImageService _imageService = imageService;

    [HttpPost]
    public async Task<IActionResult> UploadAndAssign(int personId, IFormFile image)
    {
        if (image == null || image.Length == 0)
            return BadRequest("Invalid image file.");

        string imagePath = await _imageService.UploadImageAsync(image);

        var command = new UpdatePersonImageCommand { Id = personId, ImagePath = imagePath };
        var result = await _mediator.Send(command);

        if (!result)
            return NotFound("Person not found or update failed.");

        return Ok(new { Message = "Image uploaded and assigned successfully", ImagePath = imagePath });
    }
}